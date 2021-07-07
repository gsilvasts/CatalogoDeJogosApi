using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CatalogoDeJogos_Api.Entities
{
    public class Jogo : EntidadeBase
    {
        public string Nome { get; set; }
        public int ProdutoraId { get; set; }
        public Produtora Produtora { get; set; }
        public int CategoriaId { get; set; }
        public Categoria Categoria { get; set; }
        public double Preco { get; set; }
        public bool Ativo { get; set; }
    }
}
