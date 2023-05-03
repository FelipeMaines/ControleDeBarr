using ControleDeBar.ConsoleApp.Produto;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControleDeBar.ConsoleApp.Pedido
{
    public class EntidadePedido : EntidadeBase
    {
        public EntidadeProduto entidadeProduto { get; set; }

        public EntidadePedido(EntidadeProduto produto)
        {
            this.produto = produto;
        }

        public EntidadeProduto produto { get; set; }


        public override void AtualizarInformacoes(EntidadeBase registroAtualizado)
        {
            throw new NotImplementedException();
        }

        public override ArrayList Validar()
        {
            throw new NotImplementedException();
        }
    }
}
