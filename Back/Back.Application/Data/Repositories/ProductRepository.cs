using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Back.Application.Entities;
using Back.Application.Exceptions;
using Microsoft.EntityFrameworkCore;

namespace Back.Application.Data.Repositories
{
    /// <summary>
    /// Class responsible for CRUD operations on database through EF DbContext class.
    /// </summary>
    public class ProductRepository : IProductRepository
    {
        private readonly ApplicationDbContext _context;

        public ProductRepository(ApplicationDbContext context)
        {
            this._context = context;
        }

        /// <summary>
        /// Add product to the database.
        /// </summary>
        /// <param name="product">product object representation</param>
        /// <exception cref="IllegalNameException">if name is used</exception>
        /// <exception cref="DbEntityOperationException">if entity could not be add</exception>
        /// <exception cref="DbEntityOperationException">if changes could not be saved</exception>
        public async Task Create(Product product)
        {
            var IsNameUsed = await _context.Product.Where(p => p.Name == product.Name).AnyAsync();

            if(IsNameUsed)
            {
                throw new IllegalNameException();
            }

            var tracker = _context.Product.Add(product);

            if(tracker.State != EntityState.Added)
            {
                throw new DbEntityOperationException(ExceptionMessage.AddFailed);
            }

            var savingResult = await _context.SaveChangesAsync();


            if (savingResult == 0)
            {
                throw new DbEntityOperationException(ExceptionMessage.SavingChangesFailed);
            }
        }

        /// <summary>
        /// Delete product from the database.
        /// </summary>
        /// <param name="id">products id to delete</param>
        /// <exception cref="KeyNotFoundException">if product with provided id does not exist in the database</exception>
        /// <exception cref="DbEntityOperationException">if entity could not be deleted</exception>
        /// <exception cref="DbEntityOperationException">if changes could not be saved</exception>
        public async Task Delete(int id)
        {
            var productExist = await _context.Product.Where(p => p.Id == id).AnyAsync();
            
            if(!productExist)
            {
                throw new KeyNotFoundException(ExceptionMessage.IncorrectId);
            }

            var product = await _context.Product.Where(p => p.Id == id).FirstAsync();
            var tracker = _context.Product.Remove(product);

            if(tracker.State != EntityState.Deleted)
            {
                throw new DbEntityOperationException(ExceptionMessage.DeleteFailed);
            }

            var savingResult = await _context.SaveChangesAsync();

            if(savingResult == 0)
            {
                throw new DbEntityOperationException(ExceptionMessage.SavingChangesFailed);
            }
        }

        /// <summary>
        /// Update products information in the database.
        /// </summary>
        /// <param name="product">product object representation with modified fields</param>
        /// <exception cref="IllegalNameException">if products new name is already used</exception>
        /// <exception cref="DbEntityOperationException">if entity could not be modified</exception>
        /// <exception cref="DbEntityOperationException">if changes could not be saved</exception>
        public async Task Update(Product product)
        {
            var IsNameUsed = _context.Product.Where(p => p.Id != product.Id)
                                             .Where(p => p.Name == product.Name)
                                             .Any();

            var productInDb = _context.Product.Where(p => p.Id == product.Id).AsNoTracking().FirstOrDefault();

            if (IsNameUsed)
            {
                throw new IllegalNameException();
            }

            if(productInDb == null)
            {
                throw new KeyNotFoundException();
            }
            else if(product.Equals(productInDb))
            {
                throw new DbEntityOperationException(ExceptionMessage.NoChanges);
            }

            var tracker = _context.Product.Update(product);

            if (tracker.State != EntityState.Modified)
            {
                throw new DbEntityOperationException(ExceptionMessage.UpdateFailed);
            }


            int savingResult = await _context.SaveChangesAsync();

            if (savingResult == 0)
            {
                throw new DbEntityOperationException(ExceptionMessage.SavingChangesFailed);
            }
        }

        /// <summary>
        /// Get all products from the database.
        /// </summary>
        /// <returns>
        /// <list type="Product">list with all product records from the database.</list>
        /// </returns>
        public async Task<IEnumerable<Product>> GetAll()
        {
            return await _context.Product.ToListAsync();
        }

        /// <summary>
        /// Get all products from the database.
        /// </summary>
        /// <returns>
        /// <list type="Product">list with all product records from the database.</list>
        /// </returns>
        public async Task<Product> GetById(int id)
        {
            return _context.Product.Where(p => p.Id == id).FirstOrDefault();
        }
    }
}
