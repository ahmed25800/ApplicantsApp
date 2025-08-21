using Domain.Entities;

namespace Application.Interfaces.Repositories;
public  interface IApplicantRepository
{
    Task<List<Applicant>> GetAllAsync(CancellationToken ct);
    Task<Applicant?> GetAsync(int id, CancellationToken ct);
    Task<Applicant?> GetByEmail(string email, CancellationToken ct);
    Task AddAsync(Applicant applicant, CancellationToken ct);
    Task DeleteAsync(Applicant applicant, CancellationToken ct);
    Task<int> SaveChangesAsync(CancellationToken ct);
}

