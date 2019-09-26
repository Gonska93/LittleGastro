using Back.Application.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Back.Application.Data.Repositories
{
    public interface IProductRepository
    {
        Task<IEnumerable<Product>> GetAll();
        Task Create(Product product);
        Task Update(Product product);
        Task Delete(int id);
        Task<Product> GetById(int id);
    }
}
