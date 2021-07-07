using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CatalogoDeJogos_Api.Dto.ViewModel
{
    public class JogoViewModel
    {
        public string Nome { get; set; }
        public string Produtora { get; set; }
        public string Categoria { get; set; }
        public double Preco { get; set; }
    }
}
