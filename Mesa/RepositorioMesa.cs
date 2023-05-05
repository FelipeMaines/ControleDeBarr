using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControleDeBar.ConsoleApp.Mesa
{
    public class RepositorioMesa : RepositorioBase<EntidadeMesa>
    {
        public RepositorioMesa(List<EntidadeMesa> listaRegistros) : base()
        {
            this.listaRegistros = listaRegistros;
        }
    }
}
