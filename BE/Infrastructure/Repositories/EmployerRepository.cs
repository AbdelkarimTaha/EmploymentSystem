using Domain.Entities;
using Domain.Interfaces;
using Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repositories;

public class EmployerRepository : Repository<User>, IEmployerRepository
{
    private readonly ApplicationDbContext _context;

    public EmployerRepository(ApplicationDbContext context) : base(context)
    {
        _context = context;
    }

    public async Task<IEnumerable<Vacancy>> GetPostedVacanciesAsync(int employerId)
    {
        return await _context.Vacancies
            .Where(v => v.EmployerId == employerId.ToString())
            .ToListAsync();
    }
}