using System;
using System.Collections.Generic;
using System.Text;
using WPFMVVMCrudDDD.Domain.Contracts;
using WPFMVVMCrudDDD.Domain.Models;
using WPFMVVMCrudDDD.Domain.Repositories;

namespace WPFMVVMCrudDDD.Domain.Services
{
    public class ProductService : IProductService
    {
        private readonly IProductRepository _repository;

        public ProductService(IProductRepository repository)
        {
            _repository = repository;
        }
        public int Add(Product newItem)
        {
            return _repository.Add(newItem);
        }

        public IEnumerable<Product> GetAllItems()
        {
            return _repository.GetAllItems();
        }

        public Product GetById(int id)
        {
            return _repository.GetById(id);
        }

        public Product Remove(int id)
        {
            return _repository.Remove(id);
        }

        public Product Update(Product newItem)
        {
            return _repository.Update(newItem);
        }
    }
}
