using Domain.Entities;

namespace Domain.Interfaces;

public interface IEmployerRepository : IRepository<User>
{
    Task<IEnumerable<Vacancy>> GetPostedVacanciesAsync(int employerId);
}