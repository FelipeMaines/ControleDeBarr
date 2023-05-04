using ControleDeBar.ConsoleApp.Produto;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControleDeBar.ConsoleApp.Pedido
{
    public class TelaPedido : TelaBase
    {
        public TelaProduto telaProduto { get; set; }
        public RepositorioProduto repositorioProduto { get; set; }

        public TelaPedido(RepositorioBase repositorioPedido, TelaProduto telaProduto, RepositorioProduto repositorioProduto) : base(repositorioPedido)
        {
            this.telaProduto = telaProduto;
            this.repositorioProduto = repositorioProduto;
        }

        protected override void MostrarTabela(ArrayList registros)
        {
        //    Console.WriteLine("{0, -10} | {1, -10} | {2, -10} |", "id", "nome", "cpf");

        //    Console.WriteLine("-----------------------------------------------------------------------");

        //    foreach (EntidadePedido pedido in registros)
        //    {
        //        Console.WriteLine("{0, -10} | {1, -10} | {2, -10} |", funcionario.id, funcionario.nome, funcionario.cpf);
        //    }
        }

        public override EntidadeBase ObterRegistro()
        {
            telaProduto.VisualizarRegistros(false);

            Console.WriteLine("\n Qual seria seu pedido?");
            int idProduto = int.Parse(Console.ReadLine());

            EntidadeProduto produto = (EntidadeProduto)repositorioProduto.SelecionarPorId(idProduto);

            Console.WriteLine("Qual a quantidade do pedido? ");
            int quantidade = int.Parse(Console.ReadLine());

            int valorTotal = produto.valor * quantidade;

            return new EntidadePedido(produto, valorTotal, quantidade);
        }

       
    }
}
