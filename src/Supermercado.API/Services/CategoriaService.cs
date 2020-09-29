using System.Collections.Generic;
using System.Threading.Tasks;
using Supermercado.API.Domain.Models;
using Supermercado.API.Domain.Services;
using Supermercado.API.Domain.Repositories;

namespace Supermercado.API.Services
{
    public class CategoriaService : ICategoriaService
    {
        private readonly ICategoriaRepository _categoriaRepositpry;
        public CategoriaService(ICategoriaRepository categoriaRepository)
        {
            _categoriaRepositpry = categoriaRepository;
        }
        public async Task<IEnumerable<Categoria>> ListAsync()
        {
            return await _categoriaRepositpry.ListAsync();
        }
    }
}