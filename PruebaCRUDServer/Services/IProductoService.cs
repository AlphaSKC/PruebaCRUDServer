using PruebaCRUDServer.Models;
using PruebaCRUDServer.Models.DTO;

namespace PruebaCRUDServer.Services
{
    public interface IProductoService
    {
        public Task<Response<List<Producto>>> GetProductos();
        public Task<Response<ProductoDTO>> CreateProducto(ProductoDTO producto);
        public Task<Response<ProductoDTO>> UpdateProducto(int id, ProductoDTO producto);
        public Task<Response<bool>> DeleteProducto(int id);
    }
}
