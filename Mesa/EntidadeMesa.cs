using ControleDeBar.ConsoleApp.Conta;
using ControleDeBar.ConsoleApp.Pedido;
using ControleDeBar.ConsoleApp.Produto;
using System;
using System.Collections;


namespace ControleDeBar.ConsoleApp.Mesa
{
    public class EntidadeMesa : EntidadeBase
    {

        public string local { get; set; }
        public bool isOcupada { get; set; }

        public EntidadeMesa(string local)
        {
            this.local = local;
        }

        public override void AtualizarInformacoes(EntidadeBase registroAtualizado)
        {
            EntidadeMesa mesaAtualizada = (EntidadeMesa)registroAtualizado;

            this.local = mesaAtualizada.local;
        }

        public override ArrayList Validar()
        {
            ArrayList erros = new ArrayList();

            if (string.IsNullOrEmpty(local))
                erros.Add("Campo local esta errado!");

            return erros;
        }
    }
}
