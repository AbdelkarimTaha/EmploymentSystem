namespace Application.Interfaces;

public interface IApplicationService
{
    Task<object> SearchVacanciesAsync(string searchQuery);
    Task<object> ApplyForVacancyAsync(string applicantId, string vacancyId);
}
