using Application.Dtos;

namespace Application.Interfaces;

public interface IEmployerService
{
    Task<object> CreateVacancyAsync(string employerId, VacancyDto vacancyDto);
    Task<object> UpdateVacancyAsync(string vacancyId, VacancyDto vacancyDto);
    Task<object> DeleteVacancyAsync(string vacancyId);
    Task<object> GetApplicantsForVacancyAsync(string vacancyId);
}
