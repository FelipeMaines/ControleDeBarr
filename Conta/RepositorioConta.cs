using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControleDeBar.ConsoleApp.Conta
{
    public class RepositorioConta : RepositorioBase
    {
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

        public RepositorioConta(ArrayList arrayList)
        {
            this.listaRegistros = arrayList;
        }
    }
}
