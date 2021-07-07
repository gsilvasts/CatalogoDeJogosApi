using CatalogoDeJogos_Api.Data.Context;
using CatalogoDeJogos_Api.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CatalogoDeJogos_Api.Repositories
{
    public class JogoRepository : IJogoRepository
    {
        private readonly JogoContext _context;
        private readonly ICategoriaRepository _categoriaRepository;
        private readonly IProdutoraRepository _produtoraRepository;

        public JogoRepository(JogoContext context, ICategoriaRepository categoriaRepository, IProdutoraRepository produtoraRepository)
        {
            _context = context;
            _categoriaRepository = categoriaRepository;
            _produtoraRepository = produtoraRepository;
        }

        public async Task<bool> DisableJogo(int id)
        {
            var entity = await GetById(id);
            if (entity == null)
            {
                return false;
            }
            else
            {
                entity.Ativo = !entity.Ativo;
                await _context.SaveChangesAsync();
                return true;
            }
        }

        public async Task<List<Jogo>> GetAllJogo()
        {
            try
            {
                var query = await _context.Jogos
               .Include(c => c.Categoria)
               .Include(p => p.Produtora)
               .AsNoTracking()
               .ToListAsync();

                return query;
            }
            catch (Exception)
            {

                throw;
            }
           
        }

        public async Task<Jogo> GetById(int id)
        {
            var result = await _context.Jogos.SingleOrDefaultAsync(x => x.Id == id);

            var categoria = _categoriaRepository.GetById(result.CategoriaId);
            var produtora = _produtoraRepository.GetById(result.ProdutoraId);

            result.Categoria = categoria;
            result.Produtora = produtora;

            return result;
        }

        public async Task<bool> InsertJogo(Jogo jogo)
        {
            try
            {
                _context.Jogos.Add(jogo);
                await _context.SaveChangesAsync();
                return true;
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);

            }
            
        }
    }
}
