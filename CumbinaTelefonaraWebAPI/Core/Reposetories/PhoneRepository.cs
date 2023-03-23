using CumbinaTelefonaraWebAPI.Data;
using CumbinaTelefonaraWebAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace CumbinaTelefonaraWebAPI.Core.Reposetories
{
    public class PhoneRepository : GenericReposetory<Phone>, IPhoneRepository
    {
        public PhoneRepository(AppDbContext context, ILogger logger) : base(context, logger)
        {

            
        }

        public async Task<IEnumerable<Phone?>> GetPhonesByModel(string model)
        {
            try
            {
                return await _context.Phones.Where(x => x.Model.ToLower().Equals(model.ToLower())).ToListAsync();
            }
            catch (Exception e)
            {

                throw;
            }
        }
    }
}
