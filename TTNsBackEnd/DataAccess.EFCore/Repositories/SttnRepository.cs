using DataAccess.EFCore.Interfaces;
using Domain;
using Microsoft.EntityFrameworkCore;

namespace DataAccess.EFCore.Repositories
{
    public class SttnRepository : GenericRepository<Sttn>, ISttnRepository
    {
        public SttnRepository(TtnContext context) : base(context) { }

        public async Task<IEnumerable<Sttn>> GetBySysn(int sysn, bool includeDeleted)
        {
            if (includeDeleted)
            {
                return await _dbSet.Where(x => x.SYSN == sysn).ToListAsync();
            }
            else
            {
                return await _dbSet.Where(x => x.SYSN == sysn && x.F_DEL == 0)
                    .ToListAsync();
            }
        }

        public async Task RemoveBySysn(int sysn)
        {
            var entities = await GetBySysn(sysn, false);
            foreach (var entity in entities)
            {
                entity.F_DEL = 1;
            }
        }
    }
}