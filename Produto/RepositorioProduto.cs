﻿using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControleDeBar.ConsoleApp.Produto
{
    public class RepositorioProduto : RepositorioBase
    {

        public RepositorioProduto(ArrayList arrayList)
        {
            this.listaRegistros = arrayList;
        }
    }
}
