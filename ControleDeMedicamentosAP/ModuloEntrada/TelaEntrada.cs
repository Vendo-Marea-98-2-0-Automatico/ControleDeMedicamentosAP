using ControleDeMedicamentosAP.ConsoleApp.ModuloMedicamento;
using ControleDeMedicamentosAP.ModuloFuncionario;
using ControleDeMedicamentosAP.ModuloMedicamento;
using ControleDeMedicamentosAP.Util;
using GestaoDeEquipamentos.ConsoleApp.Compartilhado;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControleDeMedicamentosAP.ModuloEntrada
{
    public class TelaEntrada : TelaBase<Entrada>, ITelaCrud
    {
        public IRepositorioEntrada repositorioEntrada;
        public IRepositorioFuncionario repositorioFuncionario;
        public IRepositorioMedicamento repositorioMedicamento; 

        public TelaEntrada(IRepositorioEntrada repositorioEntrada, IRepositorioFuncionario repositorioFuncionario, IRepositorioMedicamento repositorioMedicamento) : base ("Entradas", repositorioEntrada)
        {
            this.repositorioEntrada = repositorioEntrada;
            this.repositorioFuncionario = repositorioFuncionario;
            this.repositorioMedicamento = repositorioMedicamento;
        }


        public override Entrada ObterDados()
        {
            VisualizarMedicamentos();

            Console.WriteLine("Digite o ID do Medicamento que deseja selecionar: ");
            int idMedicamento = int.Parse(Console.ReadLine());

            Medicamento medicamentoSelecionado = (Medicamento)repositorioMedicamento.SelecionarRegistroPorId(idMedicamento);

            VisualizarFuncionarios();

            Console.WriteLine("Digite o ID do Funcionário que deseja selecionar: ");
            int idFuncionario = int.Parse(Console.ReadLine());

            Funcionario funcionarioSelecionado = (Funcionario)repositorioFuncionario.SelecionarRegistroPorId(idFuncionario);

            Console.WriteLine("Digite a Quantidade de Medicamentos a ser (não sei): ");
            int qtdDeMedicamentos = int.Parse(Console.ReadLine());

            Entrada entrada = new Entrada(medicamentoSelecionado, funcionarioSelecionado, qtdDeMedicamentos);

            AtualizarEstoque(medicamentoSelecionado, qtdDeMedicamentos);
            
            return entrada;

        }

        protected override void ExibirCabecalhoTabela()
        {
            Console.WriteLine("{0, -10} | {1, -30} | {2, -20} | {3, -20}", "Id", "Medicamento", "Funcionario", "Quantidade");

        }

        protected override void ExibirLinhaTabela(Entrada entrada)
        {
            Console.WriteLine("{0, -10} | {1, -30} | {2, -20} | {3, -20}", entrada.Id, entrada.Medicamento, entrada.Funcionario, entrada.Quantidade);
        }

        public void VisualizarMedicamentos()
        {
            Console.WriteLine();

            Console.WriteLine("Visualizando Medicamentos...");
            Console.WriteLine("--------------------------------------------");

            Console.WriteLine();

            Console.WriteLine("{0, -10} | {1, -30} | {2, -20} | {3, -20}", "Id", "Nome", "Descrição", "Quantidade Medicamentos");

            List<Medicamento> registros = repositorioMedicamento.SelecionarRegistros();

            foreach (var e in registros)
            {
                Console.WriteLine("{0, -10} | {1, -30} | {2, -20} | {3, -20}", e.Id, e.Nome, e.Descricao, e.QuantidadeMedicamento);
            }

            Console.WriteLine();

            Notificador.ExibirMensagem("Pressione ENTER para continuar...", ConsoleColor.DarkYellow);
        }

        
        
        public void AtualizarEstoque(Medicamento medicamentoSelecionado, int qtdDeMedicamentos)
        {
            medicamentoSelecionado.QuantidadeMedicamento =- qtdDeMedicamentos;
        }
        
        
        public void VisualizarFuncionarios()
        {
            Console.WriteLine();

            Console.WriteLine("Visualizando Funcionários...");
            Console.WriteLine("--------------------------------------------");

            Console.WriteLine();

            Console.WriteLine("{0, -10} | {1, -30} | {2, -20} | {3, -20}", "Id", "Nome", "Telefone", "CPF");

            List<Funcionario> registros = repositorioFuncionario.SelecionarRegistros();

            foreach (var e in registros)
            {
                Console.WriteLine("{0, -10} | {1, -30} | {2, -20} | {3, -20}", e.Id, e.Nome, e.Telefone, e.CPF);
            }

            Console.WriteLine();

            Notificador.ExibirMensagem("Pressione ENTER para continuar...", ConsoleColor.DarkYellow);
        }

    }   
}
