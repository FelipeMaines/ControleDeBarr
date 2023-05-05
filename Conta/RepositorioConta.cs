using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControleDeBar.ConsoleApp.Conta
{
    public class RepositorioConta : RepositorioBase<EntidadeConta>
    {
        public RepositorioConta(List<EntidadeConta> listaRegistros)
        {
            this.listaRegistros = listaRegistros;
        }

        public ArrayList valorContaDiaria = new ArrayList();

        public int  ValorFinalConta()
        {
            int valorFinal = 0;

            foreach (int item in valorContaDiaria)
            {
                valorFinal += item;
            }

            return valorFinal;
        }

       
    }
}
