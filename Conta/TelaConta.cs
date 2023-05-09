using ControleDeBar.ConsoleApp.Funcionario;
using ControleDeBar.ConsoleApp.Mesa;
using ControleDeBar.ConsoleApp.Pedido;
using ControleDeBar.ConsoleApp.Produto;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;

namespace ControleDeBar.ConsoleApp.Conta
{
    public class TelaConta : TelaBase<EntidadeConta, RepositorioConta>
    {
        public RepositorioConta repositorio;
        public RepositorioFuncionario repositorioFuncionario;
        public RepositorioConta repositorioConta;
        public RepositorioPedido repositorioPedido;
        public RepositorioProduto repositorioProduto;

        public TelaFuncionario telaFuncionario;
        public TelaMesa telaMesa;
        public TelaPedido telaPedido;
        public RepositorioMesa repositorioMesa;
        public TelaProduto telaProduto;

        public TelaConta(RepositorioConta repositorio, RepositorioFuncionario repositorioFuncionario,
            RepositorioPedido repositorioPedido, RepositorioMesa repositorioMesa, TelaFuncionario telaFuncionario, TelaMesa telaMesa,
            TelaPedido telaPedido, RepositorioProduto repositorioProduto, TelaProduto telaProduto) : base(repositorio)
        {
            this.repositorioFuncionario = repositorioFuncionario;
            this.telaFuncionario = telaFuncionario;
            this.repositorioPedido = repositorioPedido;
            this.telaPedido = telaPedido;
            this.repositorioMesa = repositorioMesa;
            this.telaMesa = telaMesa;
            repositorioConta = repositorio;
            this.repositorioProduto = repositorioProduto;
            this.telaProduto = telaProduto;
        }

        protected override void MostrarTabela(List<EntidadeConta> registros)
        {
            string pedidosstr = " ";
            int valor = 0;

            registros = OrganizarArray();

            Console.WriteLine("{0, -10} | {1, -10} | {2, -10} | {3, -30}", "id", "Mesa", "Pedidos", "Valor");

            Console.WriteLine("-----------------------------------------------------------------------");

            foreach (EntidadeConta conta in registros)
            {
                foreach (EntidadePedido item in conta.pedidos)
                {
                    pedidosstr += " - " + item.produto.nome +  " qtd: " + item.quantidade;
                    valor = item.valor;
                }


                Console.WriteLine("{0, -10} | {1, -10} | {2, -10} | {3, -30}", conta.id, conta.mesa.local, pedidosstr, valor);
                pedidosstr = string.Empty;
            }
        }

        public override EntidadeConta ObterRegistro()
        {
            if (!repositorioFuncionario.TemRegistros())
            {
                MostrarMensagem("Obrigatorio ter um Funcionario cadastrado!", ConsoleColor.DarkRed);
                 telaFuncionario.InserirNovoRegistro();
            }

            if (!repositorioMesa.TemRegistros())
            {
                MostrarMensagem("Obrigatorio ter uma mesa cadastrada!", ConsoleColor.DarkRed);
                telaMesa.InserirNovoRegistro();
            }

            if (!repositorioProduto.TemRegistros())
            {
                MostrarMensagem("Obrigatorio ter um produto cadastrado!", ConsoleColor.DarkRed);
                telaProduto.InserirNovoRegistro();
            }

            int valorConta = 0;
            List<EntidadePedido> pedidos = new List<EntidadePedido>();

            EntidadeMesa mesa = ObterMesa();

            if (mesa.isOcupada == true)
            {
                MostrarMensagem("Mesa ocupada", ConsoleColor.DarkYellow);
                telaMesa.InserirNovoRegistro();
                mesa = ObterMesa();
            }

            mesa.isOcupada = true;

            EntidadeFuncionario funcionario = ObterFuncionario();

            Console.Clear();

            EntidadePedido pedido = ObterPedido();

            valorConta += pedido.valor;
            AdicionarValorDiaria(pedido);
            pedidos.Add(pedido);

            string opcao = "";
            do
            {
                Console.WriteLine("Deseja fazer outro pedido? (s) SIM - (n) Nao");
                opcao = Console.ReadLine();

                if (opcao == "n")
                    break;

                pedido = ObterPedido();

                pedidos.Add(pedido);

                AdicionarValorDiaria(pedido);
                valorConta += pedido.valor;

            } while (true);

            Console.Clear();


            return new EntidadeConta(funcionario, pedidos, mesa, valorConta);
        }

        public void ObterOutroPedido()
        {
            EntidadeConta conta = ObterConta();

            if (conta.isFechada == true)
            {
                MostrarMensagem("Essa conta ja foi fechada!", ConsoleColor.DarkRed);
                Console.ReadLine();
                return;
            }

            EntidadePedido pedido = null;
            string opcao = " ";
            do
            {
                Console.Clear();
                Console.WriteLine("Deseja fazer outro pedido? (s) SIM - (n) Nao");
                opcao = Console.ReadLine();

                if (opcao == "n")
                    break;

                pedido = ObterPedido();

                conta.pedidos.Add(pedido);

                conta.valor += pedido.valor;
                AdicionarValorDiaria(pedido);

            } while (true);
        }

        private EntidadeConta ObterConta()
        {
            VisualizarRegistros(false);

            int idConta = int.Parse(Console.ReadLine());

            EntidadeConta conta = (EntidadeConta)repositorioConta.SelecionarPorId(idConta);

            return conta;
        }

        private EntidadeMesa ObterMesa()
        {
            telaMesa.VisualizarRegistros(false);

            Console.WriteLine("Qual o id da mesa?");
            int idMesa = int.Parse(Console.ReadLine());

            EntidadeMesa mesa = (EntidadeMesa)repositorioMesa.SelecionarPorId(idMesa);
            return mesa;
        }

        private int AdicionarValorDiaria(EntidadePedido pedido)
        {
            int valorConta = pedido.valor;

            repositorioConta.valorContaDiaria.Add(valorConta);
            return valorConta;
        }

        private EntidadeFuncionario ObterFuncionario()
        {
            telaFuncionario.VisualizarRegistros(false);

            Console.WriteLine("Qual o funcionario fazendo o pedido?");
            int idFuncionario = int.Parse(Console.ReadLine());

            EntidadeFuncionario funcionario = (EntidadeFuncionario)repositorioFuncionario.SelecionarPorId(idFuncionario);
            return funcionario;
        }

        private EntidadePedido ObterPedido()
        {
            return (EntidadePedido)telaPedido.ObterRegistro();
        }

        public void MostrarValorDiaria()
        {
            int valorFinal = repositorioConta.ValorFinalConta();
            Console.Clear();

            MostrarMensagem($"O valor final ficou em: {valorFinal}", ConsoleColor.Green);
        }

        public void FecharConta()
        {
            Console.Clear();
            VisualizarRegistros(false);

            Console.WriteLine("Qual o id da mesa deseja fechar a conta?");
            int idConta = int.Parse(Console.ReadLine());

            EntidadeConta conta = (EntidadeConta)repositorioConta.SelecionarPorId(idConta);

            conta.isFechada = true;

            MostrarMensagem($"Conta fechada com sucesso", ConsoleColor.Green);

        }

       

        public override string ApresentarMenu()
        {
            Console.Clear();

            Console.WriteLine($"Cadastro de {nomeEntidade}{sufixo} \n");

            Console.WriteLine($"Digite 1 para Inserir {nomeEntidade}");
            Console.WriteLine($"Digite 2 para Visualizar {nomeEntidade}{sufixo}");
            Console.WriteLine($"Digite 3 para Adicionar outro pedido {nomeEntidade}{sufixo}");
            Console.WriteLine($"Digite 4 para Editar {nomeEntidade}{sufixo}");
            Console.WriteLine($"Digite 5 para Excluir {nomeEntidade}{sufixo}");
            Console.WriteLine($"Digite 6 Fechar {nomeEntidade}{sufixo}");
            Console.WriteLine($"Digite 7 mostrar valor diario");

            Console.WriteLine("Digite s para Sair");

            string opcao = Console.ReadLine();

            return opcao;
        }

        public override List<EntidadeConta> OrganizarArray()
        {
            return base.OrganizarArray();
        }

    }
}
