using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;

namespace RepoPractice.Models.DAL.Product
{
    public class GenericRepository<T> : IRepository<T> where T : class
    {
        private ShoppingCartDBContext _context;
        private DbSet<T> dbEntity;

        public GenericRepository()
        {
            _context= new ShoppingCartDBContext();
            dbEntity = _context.Set<T>();
        }

        public void Add(T model)
        {
            dbEntity.Add(model);
        }

        public void Delete(int modelId)
        {
            T model = dbEntity.Find(modelId);
            dbEntity.Remove(model);
        }

        public IEnumerable<T> GetAll()
        {
            return dbEntity.ToList();
        }

        public T GetAllById(int modelId)
        {
            return dbEntity.Find(modelId);
        }

        public void Save()
        {
            _context.SaveChanges();
        }

        public void Update(T model)
        {
            _context.Entry(model).State= EntityState.Modified;
        }

    }
}