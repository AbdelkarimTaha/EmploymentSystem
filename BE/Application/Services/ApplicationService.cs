using Application.Interfaces;
using Domain.Entities;
using Domain.Interfaces;

namespace Application.Services
{
    public class ApplicationService : IApplicationService
    {
        private readonly IApplicantRepository _applicantRepository;
        private readonly IRepository<Vacancy> _vacancyRepository;
        private readonly IRepository<Domain.Entities.Application> _applicationRepository;

        public ApplicationService(
            IApplicantRepository applicantRepository,
            IRepository<Vacancy> vacancyRepository,
            IRepository<Domain.Entities.Application> applicationRepository)
        {
            _applicantRepository = applicantRepository;
            _vacancyRepository = vacancyRepository;
            _applicationRepository = applicationRepository;
        }

        public async Task<object> SearchVacanciesAsync(string searchQuery)
        {
            return await _applicantRepository.SearchAsync(searchQuery);
        }

        public async Task<object> ApplyForVacancyAsync(string applicantId, string vacancyId)
        {
            var vacancy = await _vacancyRepository.GetByIdAsync(Guid.Parse(vacancyId));
            if (vacancy == null || !vacancy.IsActive)
            {
                return "Vacancy not found or is inactive.";
            }

            var existingApplication = await _applicationRepository.GetAllAsync();
            if (existingApplication.Any(a => a.ApplicantId == applicantId && a.VacancyId == Guid.Parse(vacancyId)))
            {
                return "You have already applied for this vacancy.";
            }

            var totalApplications = await _applicationRepository.GetAllAsync();
            if (totalApplications.Count(a => a.VacancyId == Guid.Parse(vacancyId)) >= vacancy.MaxApplications)
            {
                return "The maximum number of applications for this vacancy has been reached.";
            }

            // Apply for the vacancy
            var application = new Domain.Entities.Application
            {
                Id = Guid.NewGuid(),
                ApplicantId = applicantId,
                VacancyId = Guid.Parse(vacancyId),
            };

            await _applicationRepository.AddAsync(application);

            return new { Message = "Application submitted successfully." };
        }
    }
}
