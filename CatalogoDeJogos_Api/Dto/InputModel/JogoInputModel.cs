using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CatalogoDeJogos_Api.Dto.InputModel
{
    public class JogoInputModel
    {
        public string Nome { get; set; }
        public int ProdutoraId { get; set; }        
        public int CategoriaId { get; set; }        
        public double Preco { get; set; }
    }
}
