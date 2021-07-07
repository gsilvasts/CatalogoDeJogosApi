using CatalogoDeJogos_Api.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CatalogoDeJogos_Api.Repositories
{
    public interface IProdutoraRepository
    {
        Produtora GetById(int id);
    }
}
