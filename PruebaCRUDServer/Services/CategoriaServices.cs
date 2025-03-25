using Dapper;
using Microsoft.EntityFrameworkCore;
using PruebaCRUDServer.Context;
using PruebaCRUDServer.Models;
using PruebaCRUDServer.Models.DTO;
using System.Data;

namespace PruebaCRUDServer.Services
{
    public class CategoriaServices: ICategoriaService
    {
        private readonly AppDbContext _context;
        public CategoriaServices(AppDbContext context)
        {
            _context = context;
        }

        public async Task<Response<List<Categoria>>> GetCategorias()
        {
            try
            {
                using (var connection = _context.Database.GetDbConnection())
                {
                    var categorias = await connection.QueryAsync<Categoria>("spGetCategorias", commandType: CommandType.StoredProcedure);
                    return new Response<List<Categoria>>(true, "Se han encontrado estos productos", categorias.ToList());
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Sucedió un error: " + ex.Message);
            }
        }

        public async Task<Response<CategoriaDTO>> CreateCategoria(CategoriaDTO request)
        {
            try
            {
                var parameters = new DynamicParameters();
                parameters.Add("Nombre", request.Nombre);
                parameters.Add("Descripcion", request.Descripcion);
                using (var connection = _context.Database.GetDbConnection())
                {
                    var categoria = await connection.QueryFirstOrDefaultAsync<CategoriaDTO>("spCreateCategoria", parameters, commandType: CommandType.StoredProcedure);
                    return new Response<CategoriaDTO>(true, "Se ha creado la categoria", categoria!);
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Sucedió un error: " + ex.Message);
            }
        }

        public async Task<Response<CategoriaDTO>> UpdateCategoria(int id, CategoriaDTO request)
        {
            try
            {
                var parameters = new DynamicParameters();
                parameters.Add("CategoriaID", id);
                parameters.Add("Nombre", request.Nombre);
                parameters.Add("Descripcion", request.Descripcion);
                using (var connection = _context.Database.GetDbConnection())
                {
                    var categoria = await connection.QueryFirstOrDefaultAsync<CategoriaDTO>("spUpdateCategoria", parameters, commandType: CommandType.StoredProcedure);
                    return new Response<CategoriaDTO>(true, "Se ha actualizado la categoria", categoria!);
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Sucedió un error: " + ex.Message);
            }
        }

        public async Task<Response<bool>> DeleteCategoria(int id)
        {
            try
            {
                var parameters = new DynamicParameters();
                parameters.Add("CategoriaID", id);
                using (var connection = _context.Database.GetDbConnection())
                {
                    await connection.ExecuteAsync("spDeleteCategoria", parameters, commandType: CommandType.StoredProcedure);
                    return new Response<bool>(true, "Se ha eliminado la categoria", true);
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Sucedió un error: " + ex.Message);
            }
        }
    }
}
