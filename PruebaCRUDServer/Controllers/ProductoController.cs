using Microsoft.AspNetCore.Mvc;
using PruebaCRUDServer.Models.DTO;
using PruebaCRUDServer.Services;

namespace PruebaCRUDServer.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ProductoController : ControllerBase
    {
        private readonly IProductoService _productoService;

        public ProductoController(IProductoService productoService)
        {
            _productoService = productoService;
        }

        [HttpGet]
        public async Task<IActionResult> GetProductos()
        {
            try
            {
                var response = await _productoService.GetProductos();
                return Ok(response);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost]
        public async Task<IActionResult> CreateProducto(ProductoDTO request)
        {
            try
            {
                var response = await _productoService.CreateProducto(request);
                return Ok(response);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateProducto(int id, ProductoDTO request)
        {
            try
            {
                var response = await _productoService.UpdateProducto(id, request);
                return Ok(response);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteProducto(int id)
        {
            try
            {
                var response = await _productoService.DeleteProducto(id);
                return Ok(response);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
