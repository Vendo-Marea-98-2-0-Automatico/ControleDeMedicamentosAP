using ControleDeMedicamentosAP.Compartilhada;
using ControleDeMedicamentosAP.ModuloFornecedor;
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


    public TelaPrincipal()
    {
        this.contexto = new ContextoDados(true);

        IRepositorioFornecedor repositorioFornecedor = new RepositorioFornecedorEmArquivo(contexto);

        telaFornecedor = new TelaFornecedor(repositorioFornecedor);
        
        /*this.repositorioEquipamento = new RepositorioEquipamentoEmArquivo(contexto);
        this.repositorioChamado = new RepositorioChamadoEmArquivo(contexto);  repositórios*/       
      
    }

    public void ApresentarMenuPrincipal()
    {
        Console.Clear();

        Console.WriteLine("----------------------------------------");
        Console.WriteLine("|        Gestão de Equipamentos        |");
        Console.WriteLine("----------------------------------------");

        Console.WriteLine();

        Console.WriteLine("1 - Controle de Fornecedores");
        Console.WriteLine("2 - Controle de ");
        Console.WriteLine("3 - Controle de ");
        Console.WriteLine("S - Sair");

        Console.WriteLine();

        Console.Write("Escolha uma das opções: ");
        opcaoPrincipal = Console.ReadLine()![0];
    }

     public ITelaCrud ObterTela()
    {
        if (opcaoPrincipal == '1')
            return telaFornecedor;

        /*else if (opcaoPrincipal == '2')
            return new TelaEquipamento(repositorioEquipamento, repositorioFabricante);

        else if (opcaoPrincipal == '3')
            return new TelaChamado(repositorioChamado, repositorioEquipamento);
        */
        return null!;
    }
}