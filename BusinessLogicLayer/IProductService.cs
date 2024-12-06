using BusinessLogicLayer.DTO;
using DataAccessLayer.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogicLayer
{
    public interface IProductService
    {
        Task<IEnumerable<ProductDTO>> GetAllProducts();

        ProductDTO GetProductById(int id);

        void AddProduct(ProductDTO product);

        void DeleteProduct(int id);

        void UpdateProduct(int id,ProductDTO product);

    }
}
