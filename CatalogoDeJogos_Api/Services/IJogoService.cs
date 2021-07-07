using CatalogoDeJogos_Api.Dto.InputModel;
using CatalogoDeJogos_Api.Dto.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CatalogoDeJogos_Api.Services
{
    public interface IJogoService
    {
        Task<List<JogoViewModel>> GetJogoAll();
        Task<JogoViewModel> Get(int id);
        Task<bool> Post(JogoInputModel jogo);
        Task<bool> Disable(int id);
    }
}
