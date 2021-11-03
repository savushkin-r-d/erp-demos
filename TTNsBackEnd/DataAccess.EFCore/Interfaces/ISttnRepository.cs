using Domain;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DataAccess.EFCore.Interfaces
{
    public interface ISttnRepository : IGenericRepository<Sttn>
    {
        Task<IEnumerable<Sttn>> GetBySysn(int sysn, bool includeDeleted);

        Task RemoveBySysn(int sysn);
    }
}