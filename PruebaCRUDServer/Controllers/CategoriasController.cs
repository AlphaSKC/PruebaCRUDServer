using Microsoft.AspNetCore.Mvc;
using PruebaCRUDServer.Models.DTO;
using PruebaCRUDServer.Services;

namespace PruebaCRUDServer.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CategoriasController : ControllerBase
    {
        private readonly ICategoriaService _categoriaService;
        public CategoriasController(ICategoriaService categoriaService)
        {
            _categoriaService = categoriaService;
        }

        [HttpGet]
        public async Task<IActionResult> GetCategorias()
        {
            try
            {
                var response = await _categoriaService.GetCategorias();
                return Ok(response);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost]
        public async Task<IActionResult> CreateCategoria(CategoriaDTO request)
        {
            try
            {
                var response = await _categoriaService.CreateCategoria(request);
                return Ok(response);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateCategoria(int id, CategoriaDTO request)
        {
            try
            {
                var response = await _categoriaService.UpdateCategoria(id, request);
                return Ok(response);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCategoria(int id)
        {
            try
            {
                var response = await _categoriaService.DeleteCategoria(id);
                return Ok(response);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
