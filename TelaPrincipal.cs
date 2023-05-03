using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControleDeBar.ConsoleApp
{
    internal class TelaPrincipal
    {
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
    }
}
