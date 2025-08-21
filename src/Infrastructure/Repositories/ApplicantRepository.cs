using Application.Interfaces.Repositories;
using Domain.Entities;
using Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repositories;
public class ApplicantRepository(AppDbContext _context) : IApplicantRepository
{
    public async Task<List<Applicant>> GetAllAsync(CancellationToken ct) => await _context.Applicants.AsNoTracking().ToListAsync(ct);
    public async Task<Applicant?> GetAsync(int id, CancellationToken ct) => await _context.Applicants.FirstOrDefaultAsync(a => a.Id == id, ct);
    public async Task AddAsync(Applicant applicant, CancellationToken ct) => await _context.Applicants.AddAsync(applicant, ct);
    public Task DeleteAsync(Applicant applicant, CancellationToken ct) { _context.Applicants.Remove(applicant); return Task.CompletedTask; }
    public Task<int> SaveChangesAsync(CancellationToken ct) => _context.SaveChangesAsync(ct);

    public async Task<Applicant?> GetByEmail(string email, CancellationToken ct) => await _context.Applicants.FirstOrDefaultAsync(a => a.EmailAdress.Equals(email), ct);

}

