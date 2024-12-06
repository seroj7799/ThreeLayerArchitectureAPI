using DataAccessLayer.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Repository
{
    public interface IProductRepository
    {
        Task<IEnumerable<Product>> GetAllProducts();

        Product GetById(int id);

        void Add(Product product);

        void Delete(Product product);

        void Update(Product product);

    }
}
