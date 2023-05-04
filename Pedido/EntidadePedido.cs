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
        public int quantidade { get; set; }
        public int valor { get; set; }

        public EntidadePedido(EntidadeProduto produto, int valor, int quantidade)
        {
            this.produto = produto;
            this.quantidade = quantidade;
            this.valor = valor;
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
