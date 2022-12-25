using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using RepoPractice.Models;

namespace RepoPractice.Models.DAL.Product
{
    public class ProductRepository : IProductRepository
    {
        private ShoppingCartDBContext _context;
        public ProductRepository(ShoppingCartDBContext ProductContext)
        {
            this._context = ProductContext;
        }
        public IEnumerable<ProductModel> GetProducts()
        {
            return _context.ProductSet.ToList();
        }

        private bool disposed = false;
        protected virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    _context.Dispose();
                }
            }
            this.disposed = true;
        }
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}