using CumbinaTelefonaraWebAPI.Models;

namespace CumbinaTelefonaraWebAPI.Core
{
    public interface IPhoneRepository : IGenericRepository<Phone>
    {
        Task<IEnumerable<Phone?>> GetPhonesByModel(string model);
    }
}
