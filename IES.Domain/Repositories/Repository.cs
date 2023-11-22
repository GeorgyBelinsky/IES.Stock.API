using IES.DataContext.DataContext;
using IES.Domain.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


namespace IES.Domain.Repositories
{
    public class Repository<T> : IRepository<T> where T : class
    {
        protected readonly IESEducationContext _stockContext;
        public Repository(IESEducationContext educationContext)
        {
            _stockContext = educationContext;
        }
        public void Create(T entity)
        {
            _stockContext.Set<T>().Add(entity);
        }

        public List<T> GetAll()
        {
            return _stockContext.Set<T>().ToList();
        }

        public async Task<IEnumerable<T>> GetAllAsync()
        {
            var users =  await _stockContext.Set<T>().ToListAsync();
            return users;
        }

        public int SaveChanges()
        {
            return _stockContext.SaveChanges();

        }
        
        public  T GetById(int id)
        {
            return _stockContext.Set<T>().Find(id);
        }

        public async Task<T> GetByIdAsync(int id)
        {
            return await _stockContext.Set<T>().FindAsync(id);
        }

        

        public void Remove(T entity)
        {
            _stockContext.Set<T>().Remove(entity);
        }

        public void Update(T entity)
        {
            _stockContext.Set<T>().Update(entity);
        }
    }
}
