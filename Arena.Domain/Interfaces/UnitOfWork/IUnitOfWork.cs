using Arena.Domain.Interfaces.Repositories;
using System;

namespace Arena.Domain.Interfaces.UnitOfWork
{
    public interface IUnitOfWork : IDisposable
    {
        ITeamRepository Teams { get; }
    }
}
