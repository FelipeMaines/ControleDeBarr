using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControleDeBar.ConsoleApp.Funcionario
{
    public class RepositorioFuncionario : RepositorioBase<EntidadeFuncionario>
    {
        public RepositorioFuncionario(List<EntidadeFuncionario> listaRegistros)
        {
            this.listaRegistros = listaRegistros;
        }
    }
}
