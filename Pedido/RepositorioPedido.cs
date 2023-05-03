using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControleDeBar.ConsoleApp.Pedido
{
    public class RepositorioPedido : RepositorioBase
    {

        public RepositorioPedido(ArrayList arrayList)
        {
            this.listaRegistros = arrayList;
        }
    }
}
