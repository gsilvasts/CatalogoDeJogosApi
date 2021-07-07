using CatalogoDeJogos_Api.Data.Context;
using CatalogoDeJogos_Api.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CatalogoDeJogos_Api.Repositories
{
    public class CategoriaRepository : ICategoriaRepository
    {
        private readonly JogoContext _context;

        public CategoriaRepository(JogoContext context)
        {
            _context = context;
        }
        public Categoria GetById(int id)
        {
            var result =  _context.Categorias.SingleOrDefault(x => x.Id == id);

            return result;
        }
    }
}
