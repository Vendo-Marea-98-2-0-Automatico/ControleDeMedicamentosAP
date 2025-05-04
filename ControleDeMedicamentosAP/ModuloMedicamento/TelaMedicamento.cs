using ControleDeMedicamentosAP.ConsoleApp.ModuloMedicamento;
using ControleDeMedicamentosAP.ModuloFornecedor;
using ControleDeMedicamentosAP.Util;
using GestaoDeEquipamentos.ConsoleApp.Compartilhado;

namespace ControleDeMedicamentosAP.ModuloMedicamento;

public class TelaMedicamento : TelaBase<Medicamento>, ITelaCrud
{
    public IRepositorioFornecedor repositorioFornecedor;
    public TelaMedicamento(IRepositorio<Medicamento> repositorio, IRepositorioFornecedor repositorioFornecedor) : base("Medicamentos", repositorio)
    {
        this.repositorioFornecedor = repositorioFornecedor;
    }
    public override Medicamento ObterDados()
    {        
        Console.Write("Digite o nome do medicamento: ");
        string nome = Console.ReadLine()!;

        Console.Write("Digite a descrição do medicamento: ");
        string descricao = Console.ReadLine()!;

        Console.Write("Digite a quantidade de medicamentos a ser inserida no estoque: ");
        int qtdMedicamento = Convert.ToInt32(Console.ReadLine());

        VisualizarFornecedores();

        Console.Write("Digite o ID do Fornecedor que deseja selecionar: ");
        int idFornecedor = int.Parse(Console.ReadLine()!);

        Fornecedor fornecedorSelecionado = (Fornecedor)repositorioFornecedor.SelecionarRegistroPorId(idFornecedor);

        Medicamento medicamentoExistente = ((RepositorioMedicamentoEmArquivo)repositorio).SelecionarPorNome(nome);

        if (medicamentoExistente != null)
        {
            medicamentoExistente.QuantidadeMedicamento += qtdMedicamento;
            Notificador.ExibirMensagem("Medicamento já cadastrado. Quantidade de medicamentos atualizada!", ConsoleColor.Green);
            return null!;
        }

        Medicamento novoMedicamento = new Medicamento(nome, descricao, qtdMedicamento, fornecedorSelecionado);

        string statusValidacao = novoMedicamento.Validar();

        repositorio.CadastrarRegistro(novoMedicamento);

        return novoMedicamento;        
    }
    private void VisualizarFornecedores()
    {
        Console.WriteLine();

        Console.WriteLine("Visualizando Fornecedores...");
        Console.WriteLine("--------------------------------------------");

        Console.WriteLine();

        Console.WriteLine("{0, -10} | {1, -30} | {2, -20} | {3, -20}", "Id", "Nome", "Telefone", "CNPJ");

        List<Fornecedor> registros = repositorioFornecedor.SelecionarRegistros();

        foreach (var fornecedor in registros)
        {
            Console.WriteLine("{0, -10} | {1, -30} | {2, -20} | {3, -20}", fornecedor.Id, fornecedor.Nome, fornecedor.Telefone, fornecedor.CNPJ);
        }

        Console.WriteLine();

        Notificador.ExibirMensagem("Pressione ENTER para continuar...", ConsoleColor.DarkYellow);
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
