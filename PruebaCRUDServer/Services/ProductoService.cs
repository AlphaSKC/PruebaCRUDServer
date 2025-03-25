using Dapper;
using Microsoft.EntityFrameworkCore;
using PruebaCRUDServer.Context;
using PruebaCRUDServer.Models;
using PruebaCRUDServer.Models.DTO;
using System.Data;

namespace PruebaCRUDServer.Services
{
    public class ProductoService : IProductoService
    {
        private readonly AppDbContext _context;
        public ProductoService(AppDbContext context)
        {
            _context = context;
        }

        public async Task<Response<List<Producto>>> GetProductos()
        {
            try
            {
                using (var connection = _context.Database.GetDbConnection())
                {
                    var productos = await connection.QueryAsync<Producto>("spGetProductos", commandType: CommandType.StoredProcedure);
                    return new Response<List<Producto>>(true, "Se han encontrado estos productos", productos.ToList());
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Sucedió un error: " + ex.Message);
            }
        }

        public async Task<Response<ProductoDTO>> CreateProducto(ProductoDTO request)
        {
            try
            {
                var parameters = new DynamicParameters();
                parameters.Add("Nombre", request.Nombre);
                parameters.Add("Descripcion", request.Descripcion);
                parameters.Add("Precio", request.Precio);
                parameters.Add("Stock", request.Stock);
                parameters.Add("CategoriaID", request.CategoriaID);

                using (var connection = _context.Database.GetDbConnection())
                {
                    var producto = await connection.QueryFirstOrDefaultAsync<ProductoDTO>("spCreateProducto", parameters, commandType: CommandType.StoredProcedure);
                    return new Response<ProductoDTO>(true, "Se ha creado el producto", producto!);
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Sucedió un error: " + ex.Message);
            }
        }

        public async Task<Response<ProductoDTO>> UpdateProducto(int id, ProductoDTO request)
        {
            try
            {
                var parameters = new DynamicParameters();
                parameters.Add("ProductoID", id);
                parameters.Add("Nombre", request.Nombre);
                parameters.Add("Descripcion", request.Descripcion);
                parameters.Add("Precio", request.Precio);
                parameters.Add("Stock", request.Stock);
                parameters.Add("CategoriaID", request.CategoriaID);
                using (var connection = _context.Database.GetDbConnection())
                {
                    var producto = await connection.QueryFirstOrDefaultAsync<ProductoDTO>("spUpdateProducto", parameters, commandType: CommandType.StoredProcedure);
                    return new Response<ProductoDTO>(true, "Se ha actualizado el producto de manera exitosa", producto!);
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Sucedió un error: " + ex.Message);
            }
        }

        public async Task<Response<bool>> DeleteProducto(int id)
        {
            try
            {
                var parameters = new DynamicParameters();
                parameters.Add("ProductoID", id);
                using (var connection = _context.Database.GetDbConnection())
                {
                    var result = await connection.ExecuteAsync("spDeleteProducto", parameters, commandType: CommandType.StoredProcedure);
                    return new Response<bool>(true, "Se ha eliminado el producto de manera exitosa");
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Sucedió un error: " + ex.Message);
            }
        }
    }
}
