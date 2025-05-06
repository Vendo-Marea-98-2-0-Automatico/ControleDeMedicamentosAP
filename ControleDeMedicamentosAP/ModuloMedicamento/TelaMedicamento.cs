using ControleDeMedicamentosAP.ModuloFornecedor;
using ControleDeMedicamentosAP.Util;
using GestaoDeEquipamentos.ConsoleApp.Compartilhado;

namespace ControleDeMedicamentosAP.ModuloMedicamento;

public class TelaMedicamento : TelaBase<Medicamento>, ITelaCrud
{
    public IRepositorioFornecedor repositorioFornecedor;
    public IRepositorioMedicamento repositorioMedicamento;

    public TelaMedicamento(IRepositorio<Medicamento> repositorio, IRepositorioFornecedor repositorioFornecedor, IRepositorioMedicamento repositorioMedicamento) : base("Medicamentos", repositorio)
    {
        this.repositorioFornecedor = repositorioFornecedor;    
        this.repositorioMedicamento = repositorioMedicamento;        
    }
    public override char ApresentarMenu()
    {
        ExibirCabecalho();

        Console.WriteLine();

        Console.WriteLine($"1 - Cadastrar {nomeEntidade}");
        Console.WriteLine($"2 - Editar {nomeEntidade}");
        Console.WriteLine($"3 - Excluir {nomeEntidade}");
        Console.WriteLine($"4 - Visualizar {nomeEntidade}");
        Console.WriteLine($"5 - Repor {nomeEntidade}");

        Console.WriteLine("S - Voltar");

        Console.WriteLine();

        Console.Write("Escolha uma das opções: ");
        char operacaoEscolhida = Convert.ToChar(Console.ReadLine()!);

        return operacaoEscolhida;
    }
    public void ReporEstoqueMedicamento()
    {
        VisualizarRegistros(false);

        Console.Write("Digite o ID do medicamento: ");
        int idMedicamento = Convert.ToInt32(Console.ReadLine());

        Medicamento medicamento = (Medicamento)repositorioMedicamento.SelecionarRegistroPorId(idMedicamento);

        if (medicamento == null)
        {
            Notificador.ExibirMensagem("Digite um ID válido para um medicamento!", ConsoleColor.Red);
            return;
        }

        Console.Write("Digite a quantidade de medicamentos que deseja adicionar ao estoque: ");
        int medicamentosAdicionadosEstoque = Convert.ToInt32(Console.ReadLine());

        if (medicamentosAdicionadosEstoque <= 0)
        {
            Notificador.ExibirMensagem("A quantia de medicamentos a ser adicionada deve ser maior que 0.", ConsoleColor.Red);
            return;
        }

        medicamento.QuantidadeMedicamento += medicamentosAdicionadosEstoque;

        Notificador.ExibirMensagem("Estoque de medicamentos atualizado com sucesso!", ConsoleColor.Green);
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
        int idFornecedor = int.Parse(Console.ReadLine());

        Fornecedor fornecedorSelecionado = (Fornecedor)repositorioFornecedor.SelecionarRegistroPorId(idFornecedor);

        Medicamento novoMedicamento = new Medicamento(nome, descricao, qtdMedicamento, fornecedorSelecionado);

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
        if (medicamento.QuantidadeMedicamento < 20)
        {            
            Console.WriteLine("{0, -10} | {1, -30} | {2, -20} | {3, -20}",medicamento.Id, medicamento.Nome, medicamento.Descricao, medicamento.QuantidadeMedicamento);
            Notificador.ExibirMensagem("Atenção! Medicamento em falta!", ConsoleColor.Red);
        }
        else 
        {
            Console.WriteLine("{0, -10} | {1, -30} | {2, -20} | {3, -20}", medicamento.Id, medicamento.Nome, medicamento.Descricao, medicamento.QuantidadeMedicamento);
        }            
    }


}
