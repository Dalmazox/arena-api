using Arena.Domain.Interfaces.Repositories;
using Arena.Domain.Interfaces.UnitOfWork;
using Arena.Infra.Data.Context;
using Arena.Infra.Data.Repositories;
using System;

namespace Arena.Infra.Data.UoW
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly ArenaContext _context;
        private ITeamRepository _teams;

        public ITeamRepository Teams => _teams ??= new TeamRepository(_context);

        public UnitOfWork(ArenaContext context)
        {
            _context = context;
        }

        #region Dispose
        private bool _disposed = false;

        protected virtual void Dispose(bool disposing)
        {
            if (_disposed) return;
            if (disposing)
            {
                _context?.Dispose();
            }

            _disposed = true;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
        #endregion
    }
}
