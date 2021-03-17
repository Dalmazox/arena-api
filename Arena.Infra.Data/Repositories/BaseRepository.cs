using Arena.Domain.Interfaces.Repositories;
using Arena.Infra.Data.Context;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;

namespace Arena.Infra.Data.Repositories
{
    public abstract class BaseRepository<T> : IRepository<T> where T : class
    {
        private readonly ArenaContext _context;
        private readonly DbSet<T> _dbSet;

        public BaseRepository(ArenaContext context)
        {
            _context = context;
            _dbSet = _context.Set<T>();
        }

        public IEnumerable<T> List()
        {
            return _dbSet.ToList();
        }
    }
}
