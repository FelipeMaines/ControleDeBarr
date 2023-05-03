using System;
using System.Collections;

namespace ControleDeBar.ConsoleApp.Funcionario
{
    public class EntidadeFuncionario : EntidadeBase
    {
        public string nome { get; set; }
        
        public EntidadeFuncionario(string nome)
        {
            this.nome = nome;
        }

        public override void AtualizarInformacoes(EntidadeBase registroAtualizado)
        {
            EntidadeFuncionario funcionarioAtualizado = (EntidadeFuncionario)registroAtualizado;

            nome = funcionarioAtualizado.nome;
        }

        public override ArrayList Validar()
        {
            ArrayList erros = new ArrayList();

            if (string.IsNullOrEmpty(nome))
                erros.Add("O campo *NOME* eh obrigatorio!");
            
            return erros;
        }
    }
}
