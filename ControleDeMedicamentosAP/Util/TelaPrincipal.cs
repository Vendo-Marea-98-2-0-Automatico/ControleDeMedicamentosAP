using ControleDeMedicamentosAP.Compartilhada;
using ControleDeMedicamentosAP.ModuloEntrada;
using ControleDeMedicamentosAP.ModuloFornecedor;
using ControleDeMedicamentosAP.ModuloFuncionario;
using ControleDeMedicamentosAP.ModuloMedicamento;
using ControleDeMedicamentosAP.ModuloPaciente;
using ControleDeMedicamentosAP.ModuloPrescricao;
using ControleDeMedicamentosAP.ModuloSaida;
using GestaoDeEquipamentos.ConsoleApp.Compartilhado;
using System.Runtime.CompilerServices;


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

    private TelaPaciente telaPaciente;

    private TelaEntrada telaEntrada;

    private TelaPrescricao telaPrescricao;

    private TelaSaida telaSaida;


    public TelaPrincipal()
    {
        this.contexto = new ContextoDados(true);

        IRepositorioFornecedor repositorioFornecedor = new RepositorioFornecedorEmArquivo(contexto);
        telaFornecedor = new TelaFornecedor(repositorioFornecedor);

        IRepositorioFuncionario repositorioFuncionario = new RepositorioFuncionarioEmArquivo(contexto);
        telaFuncionario = new TelaFuncionario(repositorioFuncionario);

        IRepositorioMedicamento repositorioMedicamento = new RepositorioMedicamentoEmArquivo(contexto);
        telaMedicamento = new TelaMedicamento(repositorioMedicamento, repositorioFornecedor);

        IRepositorioEntrada repositorioEntrada = new RepositorioEntradaEmArquivo(contexto);
        telaEntrada = new TelaEntrada(repositorioEntrada, repositorioFuncionario, repositorioMedicamento);           

        IRepositorioPaciente repositorioPaciente = new RepositorioPacienteEmArquivo(contexto);
        telaPaciente = new TelaPaciente(repositorioPaciente);

        IRepositorioPrescricao repositorioPrescricao = new RepositorioPrescricaoEmArquivo(contexto);
        telaPrescricao = new TelaPrescricao(repositorioPrescricao, repositorioPaciente, repositorioMedicamento, repositorioFuncionario);

        IRepositorioSaida repositorioSaida = new RepositorioSaidaEmArquivo(contexto);
        telaSaida = new TelaSaida(repositorioSaida, repositorioPaciente, repositorioPrescricao, repositorioMedicamento);
           
      
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
            return telaPaciente;

        else if (opcaoPrincipal == '3')
            return telaMedicamento;

        else if (opcaoPrincipal == '4')
            return telaFuncionario;

        else if (opcaoPrincipal == '5')
            return telaSaida;

        else if (opcaoPrincipal == '6')
            return telaEntrada;

        else if (opcaoPrincipal == '7')
            return telaPrescricao;

        else if (opcaoPrincipal == 'S')
            Environment.Exit(0);

        return null!;
    }
}