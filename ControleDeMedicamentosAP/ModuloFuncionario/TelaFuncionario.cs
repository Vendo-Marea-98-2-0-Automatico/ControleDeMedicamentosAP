using ControleDeMedicamentosAP.ModuloFornecedor;
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

        public override Funcionario ObterDados()
        {
            Console.Write("Digite o Nome do Funcionário: ");
            string nome = Console.ReadLine() ?? string.Empty;

            Console.Write("Digite o Telefone do Funcionário ((XX) XXXX-XXXX): ");
            string telefone = Console.ReadLine() ?? string.Empty;

            Console.Write("Digite o CPF do Funcionário (11 dígitos): ");
            string cpf = Console.ReadLine() ?? string.Empty;

            Funcionario funcionario = new Funcionario(nome, telefone, cpf);

            return funcionario;

        }

        protected override void ExibirCabecalhoTabela()
        {
            Console.WriteLine("{0, -10} | {1, -30} | {2, -20} | {3, -20}", "Id", "Nome", "Telefone", "CPF");
        }

        protected override void ExibirLinhaTabela(Funcionario funcionario)
        {
            Console.WriteLine("{0, -10} | {1, -30} | {2, -20} | {3, -20}", funcionario.Id, funcionario.Nome, funcionario.Telefone, funcionario.CPF);
        }
    }
}
