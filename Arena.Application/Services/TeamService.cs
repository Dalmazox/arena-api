using Arena.Domain.Entities;
using Arena.Domain.Interfaces.Services;
using Arena.Domain.Interfaces.UnitOfWork;
using System.Collections.Generic;

namespace Arena.Application.Services
{
    public class TeamService : ITeamService
    {
        private readonly IUnitOfWork _uow;

        public TeamService(IUnitOfWork uow)
        {
            _uow = uow;
        }

        public IEnumerable<Team> List()
        {
            return _uow.Teams.List();
        }
    }
}
