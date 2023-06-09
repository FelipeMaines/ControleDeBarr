﻿using ControleDeBar.ConsoleApp.Conta;
using ControleDeBar.ConsoleApp.Produto;
using ControleDeBar.ConsoleApp.Pedido;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Security.Cryptography.X509Certificates;
using System.Runtime.CompilerServices;

namespace ControleDeBar.ConsoleApp.Mesa
{
    public class TelaMesa : TelaBase<EntidadeMesa, RepositorioMesa>
    {
        public RepositorioConta repositorioConta;
        public RepositorioPedido repositorioPedido;
        public RepositorioProduto repositorioProduto;
        public TelaProduto telaProduto;
        public TelaConta telaConta;

        public TelaMesa(RepositorioMesa repositorio, RepositorioConta repositorioConta, RepositorioPedido repositorioPedido,
            RepositorioProduto repositorioProduto, TelaProduto telaProduto) : base(repositorio)
        {
            this.repositorioConta = repositorioConta;
            this.repositorioPedido = repositorioPedido;
            this.repositorioProduto = repositorioProduto;
            this.telaProduto = telaProduto;
            this.telaConta = telaConta;
        }

        protected override void MostrarTabela(List<EntidadeMesa> registros)
        {
            registros = OrganizarArray();

            Console.WriteLine("{0, -10} | {1, -10} |", "id","local");

            Console.WriteLine("-----------------------------------------------------------------------");

            foreach (EntidadeMesa mesa in registros)
            {
                Console.WriteLine("{0, -10} | {1, -10} |", mesa.id, mesa.local);
            }
        }

        public override EntidadeMesa ObterRegistro()
        {
            Console.WriteLine("local:");
            string local = Console.ReadLine();

            return new EntidadeMesa(local);
        }

        public override List<EntidadeMesa> OrganizarArray()
        {
            return base.OrganizarArray();
        }
    }
}
