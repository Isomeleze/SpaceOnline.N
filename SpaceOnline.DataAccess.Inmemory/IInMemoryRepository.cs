using SpaceOnline.Core.Models;
using System.Linq;

namespace SpaceOnline.DataAccess.Inmemory
{
    public interface IInMemoryRepository<T> where T : BaseEntity
    {
        IQueryable<T> Collection();
        void Commit();
        void Delete(string Id);
        T Find(string Id);
        void Insert(T t);
        void Update(T t);
    }
}