using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccessLayer.Repository;
using DataAccessLayer.Entities;
using AutoMapper;
using BusinessLogicLayer.DTO;

namespace BusinessLogicLayer
{
    public class ProductService : IProductService
    {
        private readonly IProductRepository _productRepository;
        private Mapper _productMapper;
        public ProductService(IProductRepository productRepository)
        {
            _productRepository = productRepository;
            var configProduct =
                new MapperConfiguration(cfg => cfg.CreateMap<Product, ProductDTO>().ReverseMap());

            _productMapper = new Mapper(configProduct);
        }

        public async Task<IEnumerable<ProductDTO>> GetAllProducts()
        {
            IEnumerable<Product> productsEntity = await _productRepository.GetAllProducts();
            IEnumerable<ProductDTO> productsDTO =
                _productMapper.Map<IEnumerable<Product>, IEnumerable<ProductDTO>>(productsEntity);
            return productsDTO;
        }

        public ProductDTO GetProductById(int id) 
        {
            var productEntity =  _productRepository.GetById(id);
            ProductDTO productDTO = _productMapper.Map<Product, ProductDTO>(productEntity);
            return productDTO;
        }

        public void AddProduct(ProductDTO product)
        {
            Product productEntity = _productMapper.Map<ProductDTO,Product>(product);
            _productRepository.Add(productEntity);
        }

        public void DeleteProduct(int id)
        {
            var productToDelete = _productRepository.GetById(id);
            if(productToDelete != null)
            {
                _productRepository.Delete(productToDelete);
            }
            else
            {
                throw new Exception("Product not found");
            }
            
        }

        public void UpdateProduct(int id,ProductDTO product)
        {
            var productToUpdate = _productRepository.GetById(id);
            if (productToUpdate != null)
            {
                productToUpdate.Name = product.Name;
                productToUpdate.Description = product.Description;
                _productRepository.Update(productToUpdate);
            }
            else
            {
                throw new Exception("Product not found");
            }

        }

    }
}
