using PruebaCRUDServer.Models;
using PruebaCRUDServer.Models.DTO;

namespace PruebaCRUDServer.Services
{
    public interface ICategoriaService
    {
        public Task<Response<List<Categoria>>> GetCategorias();
        public Task<Response<CategoriaDTO>> CreateCategoria(CategoriaDTO categoria);
        public Task<Response<CategoriaDTO>> UpdateCategoria(int id, CategoriaDTO categoria);
        public Task<Response<bool>> DeleteCategoria(int id);

    }
}
