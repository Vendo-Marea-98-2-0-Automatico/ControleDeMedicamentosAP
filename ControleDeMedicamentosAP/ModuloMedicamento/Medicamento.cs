using ControleDeMedicamentosAP.Compartilhada;
namespace ControleDeMedicamentosAP.ConsoleApp.ModuloMedicamento;

public class Medicamento : EntidadeBase<Medicamento>
{
    public string Nome { get; set; }
    public string Descricao { get; set; }
    public int QuantidadeMedicamento { get; set; }
    public Medicamento(string nome, string descricao, int quantidadeMedicamento)
    {
        Nome = nome;
        Descricao = descricao;
        QuantidadeMedicamento = quantidadeMedicamento;
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
        if (string.IsNullOrWhiteSpace(Descricao))
            erros += "O campo 'Telefone' é obrigatório.\n";
        if (QuantidadeMedicamento <= 0)
            erros += "A quantidade de medicamentos a ser cadastrada deve ser maior que 0.\n";

        return erros.Trim();
    }
}

