using System.Collections.Generic;
using System.Linq;
using WPFMVVMCrudDDD.Domain.Models;
using WPFMVVMCrudDDD.Domain.Repositories;

namespace WPFMVVMCrudDDD.Repository
{
    public class ProductRepository : IProductRepository
    {
        private readonly ApplicationDbContext _context;

        public ProductRepository(ApplicationDbContext context)
        {
            _context = context;
        }
        public int Add(Product newItem)
        {
            _context.Products.Add(newItem);
            return _context.SaveChanges();
        }

        public IEnumerable<Product> GetAllItems()
        {
            return _context.Products;
        }

        public Product GetById(int id)
        {
            return _context.Products.SingleOrDefault(a => a.Id == id);
        }

        public Product Remove(int id)
        {
            Product product = _context.Products.SingleOrDefault(a => a.Id == id);
            if (product != null)
            {
                _context.Products.Remove(product);
                _context.SaveChanges();
            }
            return product;
        }

        public Product Update(Product newItem)
        {
            Product existing = _context.Products.SingleOrDefault(a => a.Id == newItem.Id);
            if (existing != null)
            {
                existing.Name = newItem.Name;
                _context.SaveChanges();
            }

            return existing;
        }
    }
}
