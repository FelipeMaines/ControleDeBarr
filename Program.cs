using ControleDeBar.ConsoleApp.Conta;
using ControleDeBar.ConsoleApp.Produto;
using ControleDeBar.ConsoleApp.Funcionario;
using ControleDeBar.ConsoleApp.Mesa;
using ControleDeBar.ConsoleApp.Pedido;
using System.Collections;
using ControleDeBar.ConsoleApp.Compartilhado;
using System.Diagnostics.CodeAnalysis;

namespace ControleDeBar.ConsoleApp
{
    internal class Program
    {
        static void Main(string[] args)
        {

            TelaPrincipal telaPrincipal = new TelaPrincipal();


            while (true)
            {

                ITelaCadastravel tela = telaPrincipal.SelecionarTela();
                
                if (tela == null)
                    break;

                if (tela is TelaConta)
                {
                    TelaConta telaConta = (TelaConta)tela;
                    CadastrarConta(telaConta);
                }

                else
                    ExecultarCadastros(tela);
            }
        }

        private static void ExecultarCadastros(ITelaCadastravel tela)
        {
            string submenu = tela.ApresentarMenu();

            if (submenu == "1")
                tela.InserirNovoRegistro();

            else if (submenu == "2")
            {
                tela.VisualizarRegistros(false);
                Console.ReadLine();
            }

            else if (submenu == "3")
                tela.EditarRegistro();

            else if (submenu == "4")
                tela.ExcluirRegistro();
        }

        private static void CadastrarConta(TelaConta telaConta)
        {
            string subMenu = telaConta.ApresentarMenu();

                if (subMenu == "1")
                    telaConta.InserirNovoRegistro();

                else if (subMenu == "2")
                {
                    telaConta.VisualizarRegistros(true);
                    Console.ReadLine();
                }

                else if (subMenu == "3")
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