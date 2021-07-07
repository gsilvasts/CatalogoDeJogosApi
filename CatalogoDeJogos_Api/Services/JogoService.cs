using CatalogoDeJogos_Api.Dto.InputModel;
using CatalogoDeJogos_Api.Dto.ViewModel;
using CatalogoDeJogos_Api.Entities;
using CatalogoDeJogos_Api.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CatalogoDeJogos_Api.Services
{
    public class JogoService : IJogoService
    {
        private readonly IJogoRepository _reporitory;

        public JogoService(IJogoRepository reporitory)
        {
            _reporitory = reporitory;
        }

        public Task<bool> Disable(int id)
        {
            try
            {
                var result = _reporitory.DisableJogo(id);
                return result;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<JogoViewModel> Get(int id)
        {
            var result = await _reporitory.GetById(id);

            if (result == null)
            {
                return null;
            }
            else
            {
                return new JogoViewModel
                {
                    Categoria = result.Categoria.Descricao,
                    Produtora = result.Produtora.Nome,
                    Nome = result.Nome,
                    Preco = result.Preco,
                };
            }
        }

        public async Task<List<JogoViewModel>> GetJogoAll()
        {
            var jogos = await _reporitory.GetAllJogo();

            return jogos.Select(jogo => new JogoViewModel
            {
                Nome = jogo.Nome,
                Preco = jogo.Preco,
                Categoria = jogo.Categoria.Descricao,
                Produtora = jogo.Produtora.Nome
            }).ToList();
        }

        public Task<bool> Post(JogoInputModel jogo)
        {
            try
            {
                var x = new Jogo
                {
                    CategoriaId = jogo.CategoriaId,
                    ProdutoraId = jogo.ProdutoraId,
                    Nome = jogo.Nome,
                    Preco = jogo.Preco,
                    Ativo = true

                };
                var result = _reporitory.InsertJogo(x);

                return result;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }


        }
    }
}
