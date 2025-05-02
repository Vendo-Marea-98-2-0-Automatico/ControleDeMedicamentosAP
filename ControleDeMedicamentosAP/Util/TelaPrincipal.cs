using ControleDeMedicamentosAP.Compartilhada;
using ControleDeMedicamentosAP.ModuloFornecedor;
using ControleDeMedicamentosAP.ModuloFuncionario;
using ControleDeMedicamentosAP.ModuloMedicamento;
using GestaoDeEquipamentos.ConsoleApp.Compartilhado;


namespace ControleDeMedicamentosAP.Util;

public class TelaPrincipal
{
    private char opcaoPrincipal;
    /*private IRepositorioFabricante repositorioFabricante;
    private IRepositorioEquipamento repositorioEquipamento;
    private IRepositorioChamado repositorioChamado;   interfaces
    */
    
    private ContextoDados contexto;

    private TelaFornecedor telaFornecedor;

    private TelaFuncionario telaFuncionario;

    private TelaMedicamento telaMedicamento;


    public TelaPrincipal()
    {
        this.contexto = new ContextoDados(true);

        IRepositorioFornecedor repositorioFornecedor = new RepositorioFornecedorEmArquivo(contexto);
        telaFornecedor = new TelaFornecedor(repositorioFornecedor);

        IRepositorioFuncionario repositorioFuncionario = new RepositorioFuncionarioEmArquivo(contexto);
        telaFuncionario = new TelaFuncionario(repositorioFuncionario);

        IRepositorioMedicamento repositorioMedicamento = new RepositorioMedicamentoEmArquivo(contexto);
        telaMedicamento = new TelaMedicamento(repositorioMedicamento);      
           
      
    }

    public void ApresentarMenuPrincipal()
    {
        Console.Clear();

        Console.WriteLine("------------------------------------------");
        Console.WriteLine("|        Controle de Medicamentos        |");
        Console.WriteLine("------------------------------------------");

        Console.WriteLine();

        Console.WriteLine("1 - Controle de Fornecedores");
        Console.WriteLine("2 - Controle de Pacientes");
        Console.WriteLine("3 - Controle de Medicamentos ");
        Console.WriteLine("4 - Controle de Funcionários");
        Console.WriteLine("5 - Requisições de Saída");
        Console.WriteLine("6 - Requisições de Entrada");
        Console.WriteLine("7 - Controle de Prescrições");
        Console.WriteLine();
        Console.WriteLine("S - Sair");

        Console.WriteLine();

        Console.Write("Escolha uma das opções: ");
        opcaoPrincipal = Console.ReadLine()![0];
    }

     public ITelaCrud ObterTela()
    {
        if (opcaoPrincipal == '1')
            return telaFornecedor;

        else if (opcaoPrincipal == '2')
            Environment.Exit(0);

        else if (opcaoPrincipal == '3')
            return telaMedicamento;

        else if (opcaoPrincipal == '4')
            return telaFuncionario;

        else if (opcaoPrincipal == '5')
            Environment.Exit(0);

        else if (opcaoPrincipal == '6')
            Environment.Exit(0);

        else if (opcaoPrincipal == '7')
            Environment.Exit(0);

        else if (opcaoPrincipal == 'S')
            Environment.Exit(0);

        return null!;
    }
}