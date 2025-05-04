using ControleDeMedicamentosAP.Compartilhada;
using System.Text.RegularExpressions;
using ControleDeMedicamentosAP.ModuloMedicamento;

namespace ControleDeMedicamentosAP.ModuloFornecedor;


public class Fornecedor : EntidadeBase<Fornecedor>
{
    private static List<string> cnpjsCadastrado = new List<string>();

    public string Nome { get; set; }
    public string Telefone { get; set; }
    public string CNPJ { get; set;}
    public Fornecedor() { }
    
    public Fornecedor(string nome, string telefone, string cnpj)
    {
        Nome = nome;
        Telefone = telefone;
        CNPJ = cnpj;
    }

    public override void AtualizarRegistro(Fornecedor registroEditado)
    {
        Nome = registroEditado.Nome;
        Telefone = registroEditado.Telefone;
        
        cnpjsCadastrado.Remove(CNPJ);
        CNPJ = registroEditado.CNPJ;
        if (!cnpjsCadastrado.Contains(CNPJ))
            cnpjsCadastrado.Add(CNPJ);
    }

    public override string Validar()
    {
        string erros = "";

        if (string.IsNullOrWhiteSpace(Nome))
            erros += "O campo 'Nome' é obrigatório.\n";
        if (Nome.Length < 3 || Nome.Length > 100)
            erros += "O campo 'Nome' deve possuir de 3 a 100 caracteres.\n";
        
        if (string.IsNullOrWhiteSpace(Telefone))
            erros += "O campo 'Telefone' é obrigatório.\n";

        string padraoTelefone = @"\(?\d{2}\)?\s?9?\d{4}-?\d{4}";

        if (!Regex.IsMatch(Telefone, padraoTelefone))
            erros += "O campo 'Telefone' não está formatado corretamente.\n";

        if (string.IsNullOrWhiteSpace(CNPJ))
            erros += "O campo 'CNPJ' é obrigatório.\n";

        if (CNPJ.Length != 1)
            erros += "O campo 'CNPJ' precisa ter 14 dígitos.\n";

        if (cnpjsCadastrado.Contains(CNPJ))
            erros += "O campo 'CNPJ' só permite uma única entrada.\n";
        else
            cnpjsCadastrado.Add(CNPJ);

        return erros.Trim();
    }
}
