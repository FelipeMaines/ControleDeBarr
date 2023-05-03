using ControleDeBar.ConsoleApp.Conta;
using ControleDeBar.ConsoleApp.Produto;
using ControleDeBar.ConsoleApp.Funcionario;
using ControleDeBar.ConsoleApp.Mesa;
using ControleDeBar.ConsoleApp.Pedido;
using System.Collections;

namespace ControleDeBar.ConsoleApp
{
    internal class Program
    {
        static void Main(string[] args)
        {
            RepositorioMesa repositorioMesa = new RepositorioMesa(new ArrayList());
            RepositorioFuncionario repositorioFuncionario = new RepositorioFuncionario(new ArrayList());
            RepositorioProduto repositorioProduto = new RepositorioProduto(new ArrayList());
            RepositorioConta repositorioConta = new RepositorioConta(new ArrayList());
            RepositorioPedido repositorioPedido = new RepositorioPedido(new ArrayList());

            Popular(repositorioFuncionario, repositorioMesa, repositorioProduto);

            TelaFuncionario telaFuncionario = new TelaFuncionario(repositorioFuncionario);
            TelaProduto telaProduto = new TelaProduto(repositorioProduto);
            TelaPedido telaPedido = new TelaPedido(repositorioPedido, telaProduto, repositorioProduto);
            TelaMesa telaMesa = new TelaMesa(repositorioMesa, repositorioConta, repositorioPedido, repositorioProduto, telaProduto);
            TelaConta telaConta = new TelaConta(repositorioConta, repositorioFuncionario, repositorioPedido, repositorioMesa, telaFuncionario, telaMesa, telaPedido, repositorioProduto, telaProduto);


            TelaPrincipal principal = new TelaPrincipal();

            while (true)
            {
                string opcao = principal.ApresentarMenu();

                if (opcao == "s")
                    break;

                if (opcao == "1")
                {
                    string subMenu = telaFuncionario.ApresentarMenu();

                    if (subMenu == "1")
                    {
                        telaFuncionario.InserirNovoRegistro();
                    }
                    else if (subMenu == "2")
                    {
                        telaFuncionario.VisualizarRegistros(true);
                        Console.ReadLine();
                    }
                    else if (subMenu == "3")
                    {
                        telaFuncionario.EditarRegistro();
                    }
                    else if (subMenu == "4")
                    {
                        telaFuncionario.ExcluirRegistro();
                    }
                }
                else if (opcao == "2")
                {
                    string subMenu = telaProduto.ApresentarMenu();

                    if (subMenu == "1")
                    {
                        telaProduto.InserirNovoRegistro();
                    }
                    else if (subMenu == "2")
                    {
                        telaProduto.VisualizarRegistros(true);
                        Console.ReadLine();
                    }
                    else if (subMenu == "3")
                    {
                        telaProduto.EditarRegistro();
                    }
                    else if (subMenu == "4")
                    {
                        telaProduto.ExcluirRegistro();
                    }
                }
                else if (opcao == "3")
                {
                    string subMenu = telaMesa.ApresentarMenu();

                    if (subMenu == "1")
                    {
                        telaMesa.InserirNovoRegistro();
                    }
                    else if (subMenu == "2")
                    {
                        telaMesa.VisualizarRegistros(true);
                        Console.ReadLine();
                    }
                    else if (subMenu == "3")
                    {
                        telaMesa.EditarRegistro();
                    }
                    else if (subMenu == "4")
                    {
                        telaMesa.ExcluirRegistro();
                    }
                }
                else if (opcao == "4")
                {
                    string subMenu = telaConta.ApresentarMenu();
                    

                    if (subMenu == "1")
                        telaConta.InserirNovoRegistro();

                    else if (subMenu == "2")
                    {
                        telaConta.VisualizarRegistros(true);
                        Console.ReadLine();
                    }

                    else if(subMenu == "3")
                        telaConta.ObterOutroPedido();

                    else if (subMenu == "4")
                        telaConta.EditarRegistro();
                    
                    else if (subMenu == "5")
                        telaConta.ExcluirRegistro();

                    else if (subMenu == "6")
                        telaConta.FecharConta();

                    else if (subMenu == "7")
                         telaConta.MostrarValorDiaria();
                    
                }

            }
        }

        private static void Popular(
            RepositorioFuncionario repositorioFuncionario,
            RepositorioMesa repositorioMesa,
            RepositorioProduto repositorioProduto)
        {

            EntidadeFuncionario funcionario1 = new EntidadeFuncionario("Pedro");
            EntidadeFuncionario funcionario2 = new EntidadeFuncionario("Joao");

            repositorioFuncionario.Inserir(funcionario1);
            repositorioFuncionario.Inserir(funcionario2);

            EntidadeMesa mesa1 = new EntidadeMesa("Perto Janela");
            EntidadeMesa mesa2 = new EntidadeMesa("Perto Porta");

            repositorioMesa.Inserir(mesa1);
            repositorioMesa.Inserir(mesa2);

            EntidadeProduto produto1 = new EntidadeProduto("Cerveja", 10);
            EntidadeProduto produto2 = new EntidadeProduto("Batata Frita", 30);
            EntidadeProduto produto3 = new EntidadeProduto("Agua", 5);
            EntidadeProduto produto4 = new EntidadeProduto("Suco de Laranja", 8);

            repositorioProduto.Inserir(produto1);
            repositorioProduto.Inserir(produto2);
            repositorioProduto.Inserir(produto3);
            repositorioProduto.Inserir(produto4);
        }
    }
}