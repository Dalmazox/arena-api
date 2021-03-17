using Arena.Domain.Entities;
using System.Collections.Generic;

namespace Arena.Domain.Interfaces.Services
{
    public interface ITeamService
    {
        IEnumerable<Team> List();
    }
}
