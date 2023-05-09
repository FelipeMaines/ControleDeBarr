using ControleDeBar.ConsoleApp.Compartilhado;
using ControleDeBar.ConsoleApp.Conta;
using ControleDeBar.ConsoleApp.Funcionario;
using ControleDeBar.ConsoleApp.Mesa;
using ControleDeBar.ConsoleApp.Pedido;
using ControleDeBar.ConsoleApp.Produto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControleDeBar.ConsoleApp
{
    internal class TelaPrincipal
    {
        public TelaMesa telaMesa;
        public TelaProduto telaProduto;
        public TelaFuncionario telaFuncionario;
        public TelaPedido telaPedido;
        public TelaConta telaConta;

        public TelaPrincipal()
        {
            RepositorioMesa repositorioMesa = new RepositorioMesa(new List<EntidadeMesa>());
            RepositorioFuncionario repositorioFuncionario = new RepositorioFuncionario(new List<EntidadeFuncionario>());
            RepositorioProduto repositorioProduto = new RepositorioProduto(new List<EntidadeProduto>());
            RepositorioConta repositorioConta = new RepositorioConta(new List<EntidadeConta>());
            RepositorioPedido repositorioPedido = new RepositorioPedido(new List<EntidadePedido>());

            Popular(repositorioFuncionario, repositorioMesa, repositorioProduto);

            telaFuncionario = new TelaFuncionario(repositorioFuncionario);
            telaProduto = new TelaProduto(repositorioProduto);
            telaPedido = new TelaPedido(repositorioPedido, telaProduto, repositorioProduto);
            telaMesa = new TelaMesa(repositorioMesa, repositorioConta, repositorioPedido, repositorioProduto, telaProduto);
            telaConta = new TelaConta(repositorioConta, repositorioFuncionario, repositorioPedido, repositorioMesa, telaFuncionario, telaMesa, telaPedido, repositorioProduto, telaProduto);
        }
        public string ApresentarMenu()
        {
            Console.Clear();

            Console.WriteLine("Bem vindo ao * Controle do Bar *\n");

            Console.WriteLine("Digite 1 para Entrar na area de Funcionario");
            Console.WriteLine("Digite 2 para Entrar na area de Produto");
            Console.WriteLine("Digite 3 para Entrar na area de Mesa");
            Console.WriteLine("Digite 4 para Entrar na area de Contas");


            Console.WriteLine("Digite s para Sair");

            string opcao = Console.ReadLine();

            return opcao;
        }

        public ITelaCadastravel SelecionarTela()
        {
            string opcao = ApresentarMenu();

            if (opcao == "1")
                return telaFuncionario;

            if (opcao == "2")
                return telaProduto;

            if (opcao == "3")
                return telaMesa;

            if (opcao == "4")
                return telaConta;

            if (opcao == "s")
                return null;

            else
                return null;
        }

        private static void Popular(
            RepositorioFuncionario repositorioFuncionario,
            RepositorioMesa repositorioMesa,
            RepositorioProduto repositorioProduto)
        {

            EntidadeFuncionario funcionario1 = new EntidadeFuncionario("Pedro");
            EntidadeFuncionario funcionario2 = new EntidadeFuncionario("Joao Plauda");

            repositorioFuncionario.Inserir(funcionario1);
            repositorioFuncionario.Inserir(funcionario2);

            EntidadeMesa mesa1 = new EntidadeMesa("1");
            EntidadeMesa mesa2 = new EntidadeMesa("4");
            EntidadeMesa mesa3 = new EntidadeMesa("3");
            EntidadeMesa mesa4 = new EntidadeMesa("2");
            EntidadeMesa mesa5 = new EntidadeMesa("5");
            EntidadeMesa mesa6 = new EntidadeMesa("6");

            repositorioMesa.Inserir(mesa1);
            repositorioMesa.Inserir(mesa2);
            repositorioMesa.Inserir(mesa3);
            repositorioMesa.Inserir(mesa4);
            repositorioMesa.Inserir(mesa5);
            repositorioMesa.Inserir(mesa6);

            EntidadeProduto produto1 = new EntidadeProduto("Cerveja", 10);
            EntidadeProduto produto2 = new EntidadeProduto("Batata Frita", 30);
            EntidadeProduto produto3 = new EntidadeProduto("Agua", 5);
            EntidadeProduto produto4 = new EntidadeProduto("Suco de Laranja", 8);

            EntidadeProduto produto5 = new EntidadeProduto("Pinga", 15);
            EntidadeProduto produto6 = new EntidadeProduto("Polenta Frita", 25);
            EntidadeProduto produto7 = new EntidadeProduto("X-Burguer", 35);
            EntidadeProduto produto8 = new EntidadeProduto("Suco de Morango", 8);

            repositorioProduto.Inserir(produto1);
            repositorioProduto.Inserir(produto2);
            repositorioProduto.Inserir(produto3);
            repositorioProduto.Inserir(produto4);
            repositorioProduto.Inserir(produto5);
            repositorioProduto.Inserir(produto6);
            repositorioProduto.Inserir(produto7);
            repositorioProduto.Inserir(produto8);
        }
    }
}
