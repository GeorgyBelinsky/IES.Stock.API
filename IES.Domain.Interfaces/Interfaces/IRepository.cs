using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Reflection;

namespace IES.Domain.Interfaces
{
    public interface IRepository<T> where T : class
    {
        Task<IEnumerable<T>> GetAllAsync();
        List<T> GetAll();
        Task<T> GetByIdAsync(int id);
        
        T GetById(int id);
        void Remove(T entity);
        void Create(T entity);
        void Update(T entity);
        public int SaveChanges();
    }
}
