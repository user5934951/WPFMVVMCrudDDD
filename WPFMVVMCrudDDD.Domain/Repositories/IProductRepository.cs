using System.Collections.Generic;
using WPFMVVMCrudDDD.Domain.Models;

namespace WPFMVVMCrudDDD.Domain.Repositories
{
    public interface IProductRepository
    {
        IEnumerable<Product> GetAllItems();
        int Add(Product newItem);
        Product Update(Product newItem);
        Product GetById(int id);
        Product Remove(int id);
    }
}