using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BirthClinicMongoDB.Repositories.Interfaces
{
    public interface IBaseRepository<TEntity> where TEntity: class
    {
        Task Create(TEntity obj);
        void Update(TEntity obj);
        void Delete(string id);
        void DeleteById(string id);
        Task<TEntity> Get(string id);
        Task<IEnumerable<TEntity>> Get();
    }
}
