using CatalogoDeJogos_Api.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CatalogoDeJogos_Api.Repositories
{
    public interface IJogoRepository
    {
        Task<List<Jogo>> GetAllJogo();
        Task<Jogo> GetById(int id);
        Task<bool> DisableJogo(int id);
        Task<bool> InsertJogo(Jogo jogo);
    }
}
