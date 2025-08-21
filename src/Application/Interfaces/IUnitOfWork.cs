using Application.Interfaces.Repositories;

namespace Application.Interfaces;

public interface IUnitOfWork
{
    IApplicantRepository Applicants { get; }
    Task<int> SaveChangesAsync(CancellationToken ct = default);
}
