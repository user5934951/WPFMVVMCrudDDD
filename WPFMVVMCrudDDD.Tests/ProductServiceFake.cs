using System;
using System.Collections.Generic;
using System.Linq;
using WPFMVVMCrudDDD.Domain.Contracts;
using WPFMVVMCrudDDD.Domain.Models;

namespace WPFMVVMCrudDDD.Tests
{
    public class ProductServiceFake : IProductService
    {
        private readonly List<Domain.Models.Product> _productsList;
        public ProductServiceFake()
        {
            _productsList = new List<Domain.Models.Product>()
            {
                new Domain.Models.Product() { Id = 1, Name = "Prod1" },
                new Domain.Models.Product() { Id = 2, Name = "Prod2" },
                new Domain.Models.Product() { Id = 3, Name = "Prod3" },
                new Domain.Models.Product() { Id = 4, Name = "Prod4" }
            };
        }
        public int Add(Domain.Models.Product newItem)
        {
            int newId = _productsList[_productsList.Count - 1].Id + 1;
            newItem.Id = newId;
            _productsList.Add(newItem);
            return newId;
        }

        public IEnumerable<Domain.Models.Product> GetAllItems()
        {
            return _productsList;
        }

        public Domain.Models.Product GetById(int id)
        {
            return _productsList.SingleOrDefault(a => a.Id == id);
        }

        public Product Remove(int id)
        {
            var existing = _productsList.SingleOrDefault(a => a.Id == id);
            _productsList.Remove(existing);
            return existing;
        }

        public Domain.Models.Product Update(Domain.Models.Product newItem)
        {
            var existing = _productsList.SingleOrDefault(a => a.Id == newItem.Id);
            if (existing != null)
            {
                existing.Name = newItem.Name;
            }

            return existing;
        }
    }
}
