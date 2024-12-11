using Domain.Entities;
using Domain.Interfaces;
using Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repositories;

public class ApplicantRepository : Repository<User>, IApplicantRepository
{
    private readonly ApplicationDbContext _context;

    public ApplicantRepository(ApplicationDbContext context) : base(context)
    {
        _context = context;
    }

    public async Task<IEnumerable<Vacancy>> GetAppliedVacanciesAsync(int applicantId)
    {
        return await _context.Applications
            .Where(a => a.ApplicantId == applicantId.ToString())
            .Include(a => a.Vacancy)
            .Select(a => a.Vacancy)
            .ToListAsync();
    }
}