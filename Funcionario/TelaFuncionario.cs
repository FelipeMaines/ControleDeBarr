using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControleDeBar.ConsoleApp.Funcionario
{
    public class TelaFuncionario : TelaBase<EntidadeFuncionario, RepositorioFuncionario>
    {
        public TelaFuncionario(RepositorioFuncionario repositorioFuncionario) : base(repositorioFuncionario)
        {
            nomeEntidade = "Funcionario";
            sufixo = "s";
        }

        protected override void MostrarTabela(List<EntidadeFuncionario> registros)
        {
            Console.WriteLine("{0, -10} | {1, -10} | ", "id", "nome");

            Console.WriteLine("-----------------------------------------------------------------------");

            foreach (EntidadeFuncionario funcionario in registros)
            {
                Console.WriteLine("{0, -10} | {1, -10} |", funcionario.id ,funcionario.nome);
            }
        }

        public override EntidadeFuncionario ObterRegistro()
        {
            Console.WriteLine("Qual o nome do Garcon?");
            string nome = Console.ReadLine();

            return new EntidadeFuncionario(nome);
        }
    }
}
