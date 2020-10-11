using System;
using System.Collections.Generic;
using System.Text;
using WPFMVVMCrudDDD.Domain.Models;

namespace WPFMVVMCrudDDD.Domain.Contracts
{
    public interface IProductService
    {
        IEnumerable<Product> GetAllItems();
        int Add(Product newItem);
        Product Update(Product newItem);
        Product GetById(int id);
        Product Remove(int id);
    }
}
