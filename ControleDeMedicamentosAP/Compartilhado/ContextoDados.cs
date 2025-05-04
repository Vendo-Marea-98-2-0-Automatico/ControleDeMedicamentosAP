using System.Text.Json.Serialization;
using System.Text.Json;
using ControleDeMedicamentosAP.ModuloFornecedor;
using ControleDeMedicamentosAP.ModuloFuncionario;
using ControleDeMedicamentosAP.ModuloMedicamento;
using ControleDeMedicamentosAP.ConsoleApp.ModuloMedicamento;
using ControleDeMedicamentosAP.ModuloEntrada;
using ControleDeMedicamentosAP.ModuloPaciente;
using ControleDeMedicamentosAP.ModuloPrescricao;


namespace ControleDeMedicamentosAP.Compartilhada;

public class ContextoDados
{
    private string pastaArmazenamento = "C:\\temp";
    private string arquivoArmazenamento = "dados.json";

    public List<Fornecedor> Fornecedores { get; set; }    
    public List<Medicamento> Medicamentos { get; set; }
    public List<Funcionario> Funcionarios { get; set; }
    public List<Entrada> Entradas { get; set; }    
    public List<Paciente> Pacientes { get;  set; }
    public List<Prescricao> Prescricoes { get; set; }

    public ContextoDados()
    {
        Fornecedores = new List<Fornecedor>();        
        Medicamentos = new List<Medicamento>();
        Funcionarios = new List<Funcionario>();
        Entradas = new List<Entrada>();
        Pacientes = new List<Paciente>();
        Prescricoes = new List<Prescricao>();
    }

    public ContextoDados(bool carregarDados) : this()
    {
        if (carregarDados)
            Carregar();
    }

    public void Salvar()
    {
        string caminhoCompleto = Path.Combine(pastaArmazenamento, arquivoArmazenamento);

        JsonSerializerOptions jsonOptions = new JsonSerializerOptions();
        jsonOptions.WriteIndented = true;
        jsonOptions.ReferenceHandler = ReferenceHandler.Preserve;

        string json = JsonSerializer.Serialize(this, jsonOptions);

        if (!Directory.Exists(pastaArmazenamento))
            Directory.CreateDirectory(pastaArmazenamento);

        File.WriteAllText(caminhoCompleto, json);
    }

    public void Carregar()
    {
        string caminhoCompleto = Path.Combine(pastaArmazenamento, arquivoArmazenamento);

        if (!File.Exists(caminhoCompleto)) return;

        string json = File.ReadAllText(caminhoCompleto);

        if (string.IsNullOrWhiteSpace(json)) return;

        JsonSerializerOptions jsonOptions = new JsonSerializerOptions();
        jsonOptions.ReferenceHandler = ReferenceHandler.Preserve;

        ContextoDados contextoArmazenado = JsonSerializer.Deserialize<ContextoDados>(json, jsonOptions)!;

        if (contextoArmazenado == null) return;

        this.Fornecedores = contextoArmazenado.Fornecedores;        
        this.Medicamentos = contextoArmazenado.Medicamentos;
        this.Funcionarios = contextoArmazenado.Funcionarios;
        this.Entradas = contextoArmazenado.Entradas;
        this.Pacientes = contextoArmazenado.Pacientes;
        this.Prescricoes = contextoArmazenado.Prescricoes;
        
        
    }
}
