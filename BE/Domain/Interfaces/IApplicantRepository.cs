using Domain.Entities;

namespace Domain.Interfaces;

public interface IApplicantRepository : IRepository<User>
{
    Task<IEnumerable<Vacancy>> GetAppliedVacanciesAsync(int applicantId);
}