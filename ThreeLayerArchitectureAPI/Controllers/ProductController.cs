using BusinessLogicLayer;
using BusinessLogicLayer.DTO;
using Microsoft.AspNetCore.Mvc;

namespace ThreeLayerArchitectureAPI.Controllers
{
    [ApiController,Route("product")]
    public class ProductController : Controller
    {
        private readonly IProductService _BLL;
        public ProductController(IProductService BBL)
        {
            _BLL = BBL;
        } 

        [HttpGet]
        [Route("getProducts")]
        public Task<IEnumerable<ProductDTO>> GetProducts()
        {
            var result = _BLL.GetAllProducts();
            return result;
        }


        [HttpGet]
        [Route("getProduct/{id:int}")]
        public ActionResult<ProductDTO> GetProduct(int id)
        {
            var result = _BLL.GetProductById(id);

            if(result == null)
            {
                return NotFound("Invalid Product Id");
            }
            return Ok(result);

        }

        [HttpPost]
        [Route("addProduct")]
        public ActionResult AddProduct(ProductDTO data)
        {
            try
            {
                _BLL.AddProduct(data);
                return Ok("product added successfully!");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpDelete]
        [Route("deleteProduct/{id:int}")]
        public ActionResult DeleteProduct(int id)
        {
            try
            {
                _BLL.DeleteProduct(id);
                return Ok("product deleted successfully!");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }


        [HttpPut]
        [Route("updateProduct/{id:int}")]
        public ActionResult UpdateProduct(int id, ProductDTO data)
        {
            try
            {
                _BLL.UpdateProduct(id, data);
                return Ok("product updated successfully!");

            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

        }
    }
}
