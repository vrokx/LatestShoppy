using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using RepoPractice.Models;

namespace RepoPractice.Models.DAL.Product
{
    public interface IRepository<T> where T : class
    {
        IEnumerable<T> GetAll();
        T GetAllById(int modelId);
        void Delete(int modelId);
        void Add (T model);
        void Update (T model);
        void Save();

    }
}