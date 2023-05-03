using ControleDeBar.ConsoleApp.Funcionario;
using ControleDeBar.ConsoleApp.Mesa;
using ControleDeBar.ConsoleApp.Pedido;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControleDeBar.ConsoleApp.Conta
{
    public class EntidadeConta : EntidadeBase
    {

        public EntidadeFuncionario funcionario { get; set; }
        public EntidadeMesa mesa { get; set; }
        public ArrayList pedidos { get; set; }
        public int valor { get; set; }
        public bool isFechada { get; set; }

        public EntidadeConta(EntidadeFuncionario funcionario, ArrayList pedidos, EntidadeMesa mesa, int valor)
        {
            this.funcionario = funcionario;
            this.pedidos = pedidos;
            this.mesa = mesa;
        }

        public override void AtualizarInformacoes(EntidadeBase registroAtualizado)
        {
            EntidadeConta conta = (EntidadeConta)registroAtualizado;

            this.funcionario = conta.funcionario;
            this.pedidos = conta.pedidos;
            this.mesa = conta.mesa;
        }

        public override ArrayList Validar()
        {
            ArrayList erros = new ArrayList();

            if (funcionario == null)
                erros.Add("Campo obrigatorio!");

            if (pedidos.Count == null)
                erros.Add("Campo obrigatorio!");

            if(mesa == null)
                erros.Add("Campo obrigatorio!");

            return erros;
        }
    }
}
