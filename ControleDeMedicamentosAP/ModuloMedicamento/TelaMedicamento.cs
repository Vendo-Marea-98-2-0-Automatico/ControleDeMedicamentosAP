using ControleDeMedicamentosAP.ConsoleApp.ModuloMedicamento;
using ControleDeMedicamentosAP.ModuloFornecedor;
using GestaoDeEquipamentos.ConsoleApp.Compartilhado;

namespace ControleDeMedicamentosAP.ModuloMedicamento;

public class TelaMedicamento : TelaBase<Medicamento>, ITelaCrud
{
    public TelaMedicamento(IRepositorio<Medicamento> repositorio) : base("Medicamentos", repositorio)
    {
    }
    public override Medicamento ObterDados()
    {
        Console.Write("Digite o nome do medicamento: ");
        string nome = Console.ReadLine()!;

        Console.Write("Digite a descrição do medicamento: ");
        string descricao = Console.ReadLine()!;

        Console.Write("Digite a quantidade de medicamentos a ser inserida no estoque: ");
        int qtdMedicamento = Convert.ToInt32(Console.ReadLine());

        Medicamento medicamento = new Medicamento(nome, descricao, qtdMedicamento);

        return medicamento;
    }
    protected override void ExibirCabecalhoTabela()
    {
        Console.WriteLine("{0, -10} | {1, -30} | {2, -20} | {3, -20}", "Id", "Nome", "Descrição", "Quantidade Medicamentos");
    }
    protected override void ExibirLinhaTabela(Medicamento medicamento)
    {
        Console.WriteLine("{0, -10} | {1, -30} | {2, -20} | {3, -20}", medicamento.Id, medicamento.Nome, medicamento.Descricao, medicamento.QuantidadeMedicamento);
    }
}
