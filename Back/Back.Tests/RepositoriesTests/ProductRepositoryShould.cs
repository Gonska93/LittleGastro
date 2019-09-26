using Back.Application.Data;
using Back.Application.Data.Repositories;
using Back.Application.Entities;
using Back.Application.Exceptions;
using Microsoft.EntityFrameworkCore;
using Moq;
using NUnit.Framework;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Tests.RepositoryTests
{
    public class ProductRepositoryShould
    {
        ProductRepository productRepository;
        ApplicationDbContext _context;
        int startingProductsQuantity = 10;

        [SetUp]
        public void Setup()
        {
            var options = new DbContextOptionsBuilder<ApplicationDbContext>()
                        .UseInMemoryDatabase(databaseName: "TestLittleBarDB")
                        .Options;


            var products = GetTestList();

            using(var context = new ApplicationDbContext(options))
            {
                products.ForEach(p => context.Product.Add(p));
                context.SaveChanges();
            }

            _context = new ApplicationDbContext(options);

            this.productRepository = new ProductRepository(_context);
        }

        [TearDown]
        public void Clean()
        {
            _context.Database.EnsureDeleted();
        }

        [Test]
        public void CreateProductWithExistingName_Throws_IllegalNameException()
        {
            // Arrange
            var productWithExistingName = new Product { Id = startingProductsQuantity + 1, Name = "Test: 1", Price = 1 };

            // Assert
            Assert.ThrowsAsync<IllegalNameException>(() => productRepository.Create(productWithExistingName));
        }

        [Test]
        public void CreateProductAddsItToTheDatabase()
        {
            // Arrange
            var product = new Product { Id = startingProductsQuantity + 1, Name = "Test5", Price = 4 };

            // Act
            productRepository.Create(product).Wait();
            var productsQuantity = GetCurrentProductsAmount();

            // Assert
            Assert.AreEqual(startingProductsQuantity + 1, productsQuantity);
        }

        [Test]
        public void DeletingProductWithIncorrectId_Throws_DbEntityOperationException()
        {
            // Arrange
            var testingId = 100;

            // Assert
            Assert.ThrowsAsync<KeyNotFoundException>(() => productRepository.Delete(testingId));
        }

        [Test]
        public void DeletingProductWithExistingId_SuccessfullyDeletesIt()
        {
            // Arrange
            var existingId = 1;

            // Act
            productRepository.Delete(existingId).Wait();
            var productsQuantity = GetCurrentProductsAmount();

            // Assert
            Assert.AreEqual(startingProductsQuantity - 1, productsQuantity);
        }

        [Test]
        public void UpdatingProductWithAlreadyExistingName_Throws_IllegalNameException()
        {
            // Arrange
            var currentList = GetTestList();
            var existingProduct = currentList.First();
            var productToModify = currentList.Last();
            // changing products to update name to already existing name
            productToModify.Name = existingProduct.Name;

            // Assert
            Assert.ThrowsAsync<IllegalNameException>(() => productRepository.Update(productToModify));
        }

        [Test]
        public void RequestingUpdateProductWithNoChanges_Throws_DbEntityOperationException()
        {
            // Arrange
            var currentList = GetTestList();
            var existingProduct = currentList.First();

            // Assert
            Assert.ThrowsAsync<DbEntityOperationException>(() => productRepository.Update(existingProduct));
        }

        [Test]
        public void RequestingUpdateProductWithIncorrectId_Throws_KeyNotFoundException()
        {
            // Arrange
            var currentList = GetTestList();
            var existingProduct = currentList.First();
            existingProduct.Name = "NewName";
            existingProduct.Id = startingProductsQuantity * 2;

            // Assert
            Assert.ThrowsAsync<KeyNotFoundException>(() => productRepository.Update(existingProduct));
        }

        private List<Product> GetTestList()
        {
            var products = new List<Product>();

            for(int i = 1; i <= startingProductsQuantity; i++)
            {
                products.Add(new Product { Id = i, Name = "Test: " + i, Price = i });
            };

            return products;
        }

        private int GetCurrentProductsAmount()
        {
            Task<IEnumerable<Product>> existingProducts = productRepository.GetAll();
            existingProducts.Wait();

            return existingProducts.Result.Count();
        }
    }
}