using ControleDeMedicamentosAP.ModuloMedicamento;
using ControleDeMedicamentosAP.ModuloEntrada;
using ControleDeMedicamentosAP.ModuloMedicamento;
using ControleDeMedicamentosAP.ModuloPaciente;
using ControleDeMedicamentosAP.ModuloPrescricao;
using ControleDeMedicamentosAP.Util;
using GestaoDeEquipamentos.ConsoleApp.Compartilhado;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;

namespace ControleDeMedicamentosAP.ModuloSaida
{
    public class TelaSaida : TelaBase<Saida>, ITelaCrud
    {
        public IRepositorioSaida repositorioSaida;
        public IRepositorioPaciente repositorioPaciente;
        public IRepositorioPrescricao repositorioPrescricao;
        public IRepositorioMedicamento repositorioMedicamento;

        public TelaSaida(IRepositorioSaida repositorioSaida, IRepositorioPaciente repositorioPaciente, IRepositorioPrescricao repositorioPrescricao, IRepositorioMedicamento repositorioMedicamento) : base ("Saida", repositorioSaida)
        {
            this.repositorioSaida = repositorioSaida;
            this.repositorioPaciente = repositorioPaciente;
            this.repositorioPrescricao = repositorioPrescricao;
            this.repositorioMedicamento = repositorioMedicamento;
        }

        public override Saida ObterDados()
        {
            VisualizarPacientes();

            Console.WriteLine("Digite o ID do Paciente que deseja selecionar: ");
            int idPaciente = int.Parse(Console.ReadLine());

            Paciente pacienteSelecionado = (Paciente)repositorioPaciente.SelecionarRegistroPorId(idPaciente);


            VisualizarPrescricoes();

            Console.WriteLine("Digite o ID da Prescrição que deseja selecionar: ");
            int idPresc = int.Parse(Console.ReadLine());

            Prescricao prescSelecionada = (Prescricao)repositorioPrescricao.SelecionarRegistroPorId(idPresc);

            Saida saida = new Saida(pacienteSelecionado, prescSelecionada);

            List<Medicamento> qtdDeMedicamentos = prescSelecionada.Medicamentos;

            foreach (Medicamento e in qtdDeMedicamentos)
            {
                int qtdDeMedicamentosPresc = e.QuantidadeMedicamentoPresc;

                bool qtdDisponivel = Validar(e);
                if (!qtdDisponivel)
                {
                    Console.WriteLine($"O medicamento {e} não está em estoque\n");
                    Console.ReadLine();
                    continue;
                }

                AtualizarEstoque(e, qtdDeMedicamentosPresc);
            }

 
            return saida;

           
        }

        protected override void ExibirCabecalhoTabela()
        {
            Console.WriteLine("{0, -10} | {1, -30} | {2, -20} | {3, -20} ", "Id",  "Paciente", "Id da Prescrição", "Data da Requisição");

        }

        protected override void ExibirLinhaTabela(Saida saida)
        {
            Console.WriteLine("{0, -10} | {1, -30} | {2, -20} | {3, -20}", saida.Id, saida.Paciente.Nome, saida.Prescricao.Id, saida.dataAbertura);
        }

        public void VisualizarPacientes()
        {
            Console.WriteLine();

            Console.WriteLine("Visualizando Pacientes...");
            Console.WriteLine("--------------------------------------------");

            Console.WriteLine();

            Console.WriteLine("{0, -10} | {1, -30} | {2, -20} | {3, -20}", "Id", "Nome", "Telefone", "Nº do Cartao Sus");

            List<Paciente> registros = repositorioPaciente.SelecionarRegistros();

            foreach (var e in registros)
            {
                Console.WriteLine("{0, -10} | {1, -30} | {2, -20} | {3, -20}", e.Id, e.Nome, e.Telefone, e.CartaoSus);
            }

            Console.WriteLine();

            Notificador.ExibirMensagem("Pressione ENTER para continuar...", ConsoleColor.DarkYellow);
        }

        public void VisualizarPrescricoes() 
        {
            Console.WriteLine();

            Console.WriteLine("Visualizando Prescrições...");
            Console.WriteLine("--------------------------------------------");

            Console.WriteLine();

            Console.WriteLine("{0, -10} | {1, -30} | {2, -20} | {3, -20}", "Id", "Data da Requisição", "CRM do Médico Vigente", "Medicamentos Prescritos");

            List<Prescricao> registros = repositorioPrescricao.SelecionarRegistros();

            foreach (var e in registros)
            {
                Console.WriteLine("{0, -10} | {1, -30} | {2, -20} | {3, -20}", e.Id, e.Data, e.CrmMedico, CarregarMedicamentosEmString(e));
            }

            Console.WriteLine();

            Notificador.ExibirMensagem("Pressione ENTER para continuar...", ConsoleColor.DarkYellow);
        }

        public void AtualizarEstoque(Medicamento medicamentoSelecionado, int qtdDeMedicamentos)
        {
            medicamentoSelecionado.QuantidadeMedicamento -= qtdDeMedicamentos;
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

        public bool Validar(Medicamento medicamento) 
        {
            if (medicamento.QuantidadeMedicamento == 0)
            {
                return false;
            }

            return true;
        
        }

        public string CarregarMedicamentosEmString(Prescricao e)
        {
            string allMeds = "";
            int sizeOfList = e.Medicamentos.Count;

            for (int i = 0; i < sizeOfList; i++)
            {
                string newMed;
                newMed = e.Medicamentos[i].Nome;
                allMeds += newMed + ", ";
            }

            return allMeds;
        }
    }
}
