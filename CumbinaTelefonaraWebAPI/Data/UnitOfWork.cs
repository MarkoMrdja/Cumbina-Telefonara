using CumbinaTelefonaraWebAPI.Core;
using CumbinaTelefonaraWebAPI.Core.Reposetories;

namespace CumbinaTelefonaraWebAPI.Data
{
    public class UnitOfWork : IUnitOfWork, IDisposable
    {
        private readonly AppDbContext _context;

        public IPhoneRepository Phones { get; private set; }

        public UnitOfWork(
            AppDbContext context,
            ILoggerFactory loggerFactory)
        {
            _context = context;
            var _logger = loggerFactory.CreateLogger("logs");

            Phones = new PhoneRepository(_context, _logger);
        }

        public async Task CompleteAsync()
        {
            await _context.SaveChangesAsync();
        }

        public void Dispose()
        {
            _context.Dispose();
        }
    }
}
