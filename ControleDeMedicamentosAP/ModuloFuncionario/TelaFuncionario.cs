using ControleDeMedicamentosAP.Util;
using GestaoDeEquipamentos.ConsoleApp.Compartilhado;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControleDeMedicamentosAP.ModuloFuncionario
{
    public class TelaFuncionario : TelaBase<Funcionario>, ITelaCrud
    {
        public IRepositorioFuncionario repositorioFuncionario;

        public TelaFuncionario(IRepositorioFuncionario repositorioFuncionario) : base("Funcionários", repositorioFuncionario)
        {
            this.repositorioFuncionario = repositorioFuncionario;
        }

        public override void VisualizarRegistros(bool exibirTitulo)
        {
            if (exibirTitulo)
                ExibirCabecalho();

            Console.WriteLine("Visualizando todos os Funcionários...");
            Console.WriteLine("---------------------------------------");

            Console.WriteLine();

            Console.WriteLine(
           "{0, -6} | {1, -20} | {2, -30} | {3, -30}",
           "Id", "Nome", "Telefone", "CPF"
       );

            List<Funcionario> registros = repositorioFuncionario.SelecionarRegistros();

            foreach (var f in registros)
            {
                Console.WriteLine(
                    "{0, -6} | {1, -20} | {2, -30} | {3, -30}",
                    f.Id, f.Nome, f.Telefone, f.CPF
                );
            }

            Console.WriteLine();

            Notificador.ExibirMensagem("Pressione ENTER para continuar...", ConsoleColor.DarkYellow);
        
        }

        public override Funcionario ObterDados()
        {
            Console.WriteLine("Digite o Nome do Funcionário: ");
            string nome = Console.ReadLine() ?? string.Empty;

            Console.WriteLine("Digite o Telefone do Funcionário ((XX) XXXX-XXXX): ");
            string telefone = Console.ReadLine() ?? string.Empty;

            Console.WriteLine("Digite o CPF do Funcionário (11 dígitos): ");
            string cpf = Console.ReadLine() ?? string.Empty;

            Funcionario funcionario = new Funcionario(nome, telefone, cpf);

            return funcionario;
        }
    }
}
