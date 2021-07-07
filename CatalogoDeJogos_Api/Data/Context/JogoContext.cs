using CatalogoDeJogos_Api.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;

namespace CatalogoDeJogos_Api.Data.Context
{
    public class JogoContext : DbContext
    {
        public JogoContext(DbContextOptions<JogoContext> options) : base(options)
        {

        }

        public DbSet<Jogo> Jogos{ get; set; }
        public DbSet<Categoria> Categorias { get; set; }
        public DbSet<Produtora> Produtoras { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.UseIdentityColumns();

            base.OnModelCreating(modelBuilder);
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        }

    }
}
