using System.Collections.Generic;

namespace Arena.Domain.Interfaces.Repositories
{
    public interface IRepository<T> where T : class
    {
        IEnumerable<T> List();
    }
}