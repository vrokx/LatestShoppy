using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using RepoPractice.Models;

namespace RepoPractice.Models.DAL.Product
{
    public interface IProductRepository : IDisposable
    {
        IEnumerable<ProductModel> GetProducts();
    }
}