using Arena.Domain.Entities;
using Arena.Domain.Interfaces.Repositories;
using Arena.Infra.Data.Context;

namespace Arena.Infra.Data.Repositories
{
    public class TeamRepository : BaseRepository<Team>, ITeamRepository
    {
        public TeamRepository(ArenaContext context) : base(context)
        {
        }
    }
}
