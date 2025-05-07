using ControleDeMedicamentosAP.Compartilhada;
using ControleDeMedicamentosAP.ModuloFornecedor;
namespace ControleDeMedicamentosAP.ModuloMedicamento;

public class Medicamento : EntidadeBase<Medicamento>
{
    public string Nome { get; set; }
    public string Descricao { get; set; }
    public int QuantidadeMedicamento { get; set; }
    public int QuantidadeMedicamentoPresc {  get; set; }
    public string Dosagem { get; set; }
    public string Periodo { get; set; }
    public Fornecedor Fornecedor { get; set; }
    public Medicamento() { }
    public Medicamento(string nome, string descricao, int quantidadeMedicamento, Fornecedor fornecedor)
    {
        Nome = nome;
        Descricao = descricao;
        QuantidadeMedicamento = quantidadeMedicamento;
        Fornecedor = fornecedor;
    }
    public override void AtualizarRegistro(Medicamento registroEditado)
    {
        Nome = registroEditado.Nome;
        Descricao = registroEditado.Descricao;
        QuantidadeMedicamento = registroEditado.QuantidadeMedicamento;
    }
    public override string Validar()
    {
        string erros = "";

        if (string.IsNullOrWhiteSpace(Nome))
            erros += "O campo 'Nome' é obrigatório.\n";
        if (Nome.Length < 3 || Nome.Length > 100)
            erros += "O campo 'Nome' deve possuir de 3 a 100 caracteres.\n";

        if (Descricao.Length < 3 || Descricao.Length > 255)
            erros += "O campo 'Descrição' deve possuir de 5 a 255 caracteres.\n";

        if (QuantidadeMedicamento <= 0)
            erros += "A quantidade de medicamentos a ser cadastrada deve ser maior que 0 e positiva.\n";

        return erros.Trim();
    }
}

