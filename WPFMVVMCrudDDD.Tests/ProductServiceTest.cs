using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using WPFMVVMCrudDDD.Domain.Contracts;
using WPFMVVMCrudDDD.Domain.Models;
using Xunit;

namespace WPFMVVMCrudDDD.Tests
{
    public class ProductServiceTest
    {
        IProductService _service;

        public ProductServiceTest()
        {
            _service = new ProductServiceFake();
        }

        [Fact]
        public void Get_WhenCalled_ReturnsOkResult()
        {
            // Act
            var okResult = _service.GetAllItems();

            // Assert
            Assert.IsType<List<Product>>(okResult);
        }

        [Fact]
        public void Get_WhenCalled_ReturnsAllItems()
        {
            // Act
            var allItemsList = _service.GetAllItems();

            // Assert
            var items = Assert.IsType<List<Product>>(allItemsList);
            Assert.Equal(4, items.Count);
        }

        [Fact]
        public void GetById_UnknownIdPassed_ReturnsNull()
        {
            // Act
            var result = _service.GetById(78975543);

            // Assert
            Assert.Null(result);
        }

        [Fact]
        public void GetById_ExistingIdPassed_ReturnsOkResult()
        {
            // Arrange
            int id = 1;

            // Act
            var okResult = _service.GetById(id);

            // Assert
            Assert.IsType<Product>(okResult);
        }

        [Fact]
        public void Add_ValidObjectPassed_ReturnsNewId()
        {
            // Arrange
            Product testItem = new Product()
            {
                Name = "Prod1",
            };

            // Act
            int newId = _service.Add(testItem);

            // Assert

            Assert.True(newId > -1);
        }

        [Fact]
        public void Remove_NotExistingIdPassed_ReturnsNull()
        {
            // Arrange
            var id = 98948949;

            // Act
            var nullItem = _service.Remove(id);

            // Assert
            Assert.Null(nullItem);
        }

        [Fact]
        public void Remove_ExistingIdPassed_ReturnsRemovedTaskItem()
        {
            // Arrange
            var existingId = 2;

            // Act
            var productItem = _service.Remove(existingId);

            // Assert
            Assert.IsType<Product>(productItem);
        }

        [Fact]
        public void Remove_ExistingIdPassed_RemovesOneItem()
        {
            // Arrange
            var existingId = 2;

            // Act
            var productItem = _service.Remove(existingId);

            // Assert
            Assert.Equal(3, _service.GetAllItems().Count());
        }

        [Fact]
        public void Update_NotExistingItemPassed_ReturnsNull()
        {
            // Arrange
            Product pItem = new Product();
            pItem.Id = 98948949;
            pItem.Name = "NewUpdate1";

            // Act
            var nullItem = _service.Update(pItem);

            // Assert
            Assert.Null(nullItem);
        }

        [Fact]
        public void Update_ExistingItemPassed_ReturnsUpdatedTaskItem()
        {
            // Arrange
            Product pItem = new Product();
            pItem.Id = 1;
            pItem.Name = "NewUpdate1";

            // Act
            var updatedItem = _service.Update(pItem);

            // Assert
            Assert.IsType<Product>(updatedItem);
        }
    }
}
