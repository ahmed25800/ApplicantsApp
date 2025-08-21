using Application.Interfaces;
using Application.Interfaces.Repositories;
using Infrastructure.Repositories;

namespace Infrastructure.Data;

public class UnitOfWork(AppDbContext _context) : IUnitOfWork , IDisposable
{
    private IApplicantRepository? _applicantsRepository;
    public IApplicantRepository Applicants
    { get {

            if (_applicantsRepository == null) _applicantsRepository = new ApplicantRepository(_context);
            return _applicantsRepository;
        } 
    }
    public async Task<int> SaveChangesAsync(CancellationToken ct = default)
    {
        return await _context.SaveChangesAsync(ct);
    }
    public void Dispose()
    {
        Dispose(true);
        GC.SuppressFinalize(this); // Prevent finalizer from running
    }
    private bool _disposed = false;
    protected virtual void Dispose(bool disposing)
    {
        if (!_disposed)
        {
            if (disposing)
            {
                _context.Dispose(); // free managed resources
            }
            // free unmanaged resources here if any
            _disposed = true;
        }
    }

    ~UnitOfWork()
    {
        Dispose(false); // called by GC if Dispose wasn't called manually
    }

    
}
