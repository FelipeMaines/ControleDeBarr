using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControleDeBar.ConsoleApp.Produto
{
    public class TelaProduto : TelaBase
    {
        public TelaProduto(RepositorioBase repositorio) : base(repositorio)
        {
            nomeEntidade = "Produto";
        }

        protected override void MostrarTabela(ArrayList registros)
        {
            Console.WriteLine("{0, -10} | {1, -20} | {2, -20} | ", "id", "nome", "valor");

            Console.WriteLine("----------------------------------------");

            foreach (EntidadeProduto produto in registros)
            {
                Console.WriteLine("{0, -10} | {1, -20} | {2, -20} |", produto.id, produto.nome, produto.valor);
            }
        }

        public override EntidadeBase ObterRegistro()
        {
            Console.WriteLine("Qual o nome do produto?");
            string nome = Console.ReadLine();

            Console.WriteLine("Qual o valor do produto?");
            int valor = int.Parse(Console.ReadLine());

            return new EntidadeProduto(nome, valor);
        }
    }
}
