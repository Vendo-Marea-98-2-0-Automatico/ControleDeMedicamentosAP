using ControleDeMedicamentosAP.Compartilhada;
using System.Text.RegularExpressions;

namespace ControleDeMedicamentosAP.ModuloPaciente;

public class Paciente : EntidadeBase<Paciente>
{
    public string Nome { get; set; }
    public string Telefone { get; set; }
    public string CartaoSus { get; set; }


public Paciente()
    {

    }
    public Paciente(string nome, string telefone, string cartaoSus)
    {
        Nome = nome;
        Telefone = telefone;
        CartaoSus = cartaoSus;
    }

    public override void AtualizarRegistro(Paciente registroEditado)
    {
        Nome += registroEditado.Nome;
        Telefone += registroEditado.Telefone;
        CartaoSus += registroEditado.CartaoSus;
    }

    public override string Validar()
    {
        string erros = "";

        if (string.IsNullOrWhiteSpace(Nome))
            erros += "O campo 'Nome' é obrigatório. \n";

        if (Nome.Length < 3 || Nome.Length > 100)
            erros += "O campo 'Nome' deve conter entre 3 e 100 caracteres \n ";

        if (!Regex.IsMatch(Telefone, @"^^\(\d{2}\)\s?(9\d{4}|\d{4})-\d{4}$"))
            erros += "O campo 'Telefone'deve seguir o padrão (DDD) 0000-0000 ou (DDD) 00000-0000. \n ";

        if (!Regex.IsMatch(CartaoSus, @"^\d{15}$"))
            erros += "O campo 'Cartão SUS ' precisa conter 15 números.\n";


        return erros;
    }
}
