using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControleDeBar.ConsoleApp.Produto
{
    public class EntidadeProduto : EntidadeBase
    {
        public string nome { get; set; }
        public int valor { get; set; }


        public EntidadeProduto(string nome, int valor)
        {
            this.nome = nome;
            this.valor = valor;
        }

        public override void AtualizarInformacoes(EntidadeBase registroAtualizado)
        {
            EntidadeProduto produtoAtuazlizado = (EntidadeProduto)registroAtualizado;

            nome = produtoAtuazlizado.nome;
            valor = produtoAtuazlizado.valor;
        }

        public override ArrayList Validar()
        {
            ArrayList erros = new ArrayList();

            if (string.IsNullOrEmpty(nome))
                erros.Add("Nome eh obrigatorio");

            if (valor < 0)
                erros.Add("Produto nao podes ter valor negativo!");

            return erros;
        }
    }
}
