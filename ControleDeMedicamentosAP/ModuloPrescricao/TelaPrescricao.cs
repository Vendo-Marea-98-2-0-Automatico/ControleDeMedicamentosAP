using ControleDeMedicamentosAP.ConsoleApp.ModuloMedicamento;
using ControleDeMedicamentosAP.ModuloFuncionario;
using ControleDeMedicamentosAP.ModuloMedicamento;
using ControleDeMedicamentosAP.ModuloPaciente;
using ControleDeMedicamentosAP.Util;
using GestaoDeEquipamentos.ConsoleApp.Compartilhado;
using ControleDeMedicamentosAP.ConsoleApp.ModuloPrescricao;


namespace ControleDeMedicamentosAP.ModuloPrescricao
{
    public class TelaPrescricao : TelaBase<Prescricao>, ITelaCrud
    {
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
                Console.Write("Nome do Medicamento: ");
                string nome = Console.ReadLine() ?? string.Empty;

                Console.Write("Dosagem: ");
                string dosagem = Console.ReadLine() ?? string.Empty;

                Console.Write("Período: ");
                string periodo = Console.ReadLine() ?? string.Empty;

                Console.Write("Quantidade necessária: ");
                if (!int.TryParse(Console.ReadLine(), out int qtd) || qtd <= 0)
                {
                    Notificador.ExibirMensagem("Quantidade inválida!", ConsoleColor.Red);
                    continue;
                }

                var medicamento = new MedicamentoPrescrito(nome, dosagem, periodo, qtd);
                prescricao.Medicamentos.Add(medicamento);

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
    }
    //public bool ExisteCartaoSUS(string cartaoSus);
}
