using CatalogoDeJogos_Api.Data.Context;
using CatalogoDeJogos_Api.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CatalogoDeJogos_Api.Repositories
{
    public class ProdutoraRepository : IProdutoraRepository
    {
        private readonly JogoContext _context;

        public ProdutoraRepository(JogoContext context)
        {
            _context = context;
        }
        public Produtora GetById(int id)
        {
            var result = _context.Produtoras.SingleOrDefault(x => x.Id == id);

            return result;
        }
    }
}
