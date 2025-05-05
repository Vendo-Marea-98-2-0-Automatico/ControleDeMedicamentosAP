using ControleDeMedicamentosAP.ConsoleApp.ModuloMedicamento;
using ControleDeMedicamentosAP.ModuloFuncionario;
using ControleDeMedicamentosAP.ModuloMedicamento;
using ControleDeMedicamentosAP.ModuloPaciente;
using ControleDeMedicamentosAP.Util;
using GestaoDeEquipamentos.ConsoleApp.Compartilhado;
using ControleDeMedicamentosAP.ModuloSaida;


namespace ControleDeMedicamentosAP.ModuloPrescricao
{
    public class TelaPrescricao : TelaBase<Prescricao>, ITelaCrud
    {
        public IRepositorioSaida repositorioSaida;
        public IRepositorioPaciente repositorioPaciente;
        public IRepositorioPrescricao repositorioPrescricao;
        public IRepositorioMedicamento repositorioMedicamento;

        public TelaPrescricao(IRepositorioPrescricao repositorioPrescricao,IRepositorioPaciente repositorioPaciente, IRepositorioMedicamento repositorioMedicamento, IRepositorioFuncionario repositorioFuncionario)
            : base("Prescrição", repositorioPrescricao)
        {
           
        }

        public override Prescricao ObterDados()
        {
            Console.Write("CRM do Médico (6 dígitos): ");
            string crm = Console.ReadLine() ?? string.Empty;

            while (crm.Length != 6 || !crm.All(char.IsDigit))
            {
                Notificador.ExibirMensagem("CRM inválido! Deve conter exatamente 6 dígitos numéricos.", ConsoleColor.Red);
                Console.Write("CRM do Médico (6 dígitos): ");
                crm = Console.ReadLine() ?? string.Empty;
            }

            DateTime data;

            Console.Write("Data (dd/mm/aaaa): ");
            while (!DateTime.TryParse(Console.ReadLine(), out data))
            {
                Notificador.ExibirMensagem("Data inválida!", ConsoleColor.Red);
                Console.Write("Data (dd/mm/aaaa): ");
            }

            Prescricao prescricao = new Prescricao(crm, data);


            while (true)
            {
                VisualizarMedicamentos();
                Console.WriteLine("Digite o Id do Medicamento que deseja selecionar: ");
                int idMedicamento = int.Parse(Console.ReadLine() ?? string.Empty);

                Medicamento medicamentoSelecionado = (Medicamento)repositorioMedicamento.SelecionarRegistroPorId(idMedicamento);

                Console.Write("Dosagem: ");
                string dosagem = Console.ReadLine() ?? string.Empty;

                medicamentoSelecionado.Dosagem = dosagem;

                Console.Write("Período: ");
                string periodo = Console.ReadLine() ?? string.Empty;

                medicamentoSelecionado.Periodo = periodo;

                Console.Write("Quantidade necessária: ");
                if (!int.TryParse(Console.ReadLine(), out int qtd) || qtd <= 0)
                {
                    Notificador.ExibirMensagem("Quantidade inválida!", ConsoleColor.Red);
                    continue;
                }

                medicamentoSelecionado.QuantidadeMedicamentoPresc = qtd;

                
                prescricao.Medicamentos.Add(medicamentoSelecionado);

                Console.Write("Adicionar outro medicamento? (s/n): ");
                if (Console.ReadLine().Trim().ToLower() != "s") break;
            }

            return prescricao;
        }

        protected override void ExibirCabecalhoTabela()
        {
            Console.WriteLine("ID | CRM Médico | Data Prescrição | Qtde. Medicamentos");
            Console.WriteLine("--------------------------------------------------------");
        }

        protected override void ExibirLinhaTabela(Prescricao registro)
        {
            Console.WriteLine($"{registro.Id} | {registro.CrmMedico} | {registro.Data:dd/MM/yyyy} | {registro.Medicamentos.Count}");
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
    }
    //public bool ExisteCartaoSUS(string cartaoSus);
}
