using ControleDeMedicamentosAP.Compartilhada;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace ControleDeMedicamentosAP.ModuloFuncionario
{
    public class Funcionario : EntidadeBase<Funcionario>
    {
        public string Nome { get; set; }
        public string Telefone { get; set; }
        public string CPF { get; set; }

        public Funcionario(string nome, string telefone, string cpf)
        {
            Nome = nome;
            Telefone = telefone;
            CPF = cpf;
        }

        public override void AtualizarRegistro(Funcionario registroEditado)
        {
            Nome = registroEditado.Nome;
            Telefone = registroEditado.Telefone;
            CPF = registroEditado.CPF;
        }

        public override string Validar()
        {
            string erros = "";

            if (string.IsNullOrWhiteSpace(Nome))
                erros += "O Campo 'Nome' é obrigatório.\n";

            if (Nome.Length < 3 || Nome.Length > 100)
                erros += "O Campo 'Nome' não atende o limite de caracteres\n";

            string padraoTelefone = @"\(?\d{2}\)?\s?9?\d{4}-?\d{4}";

            if (!Regex.IsMatch(Telefone, padraoTelefone))
                erros += "O Campo 'Telefone' não está formatado corretamente\n";

            if (string.IsNullOrWhiteSpace(CPF))
                erros += "O Campo 'CPF' é obrigatório\n";

            if (CPF.Length != 11)
                erros += "O Campo 'CPF' não está formatado corretamente\n";

            return erros;
        }
    }
}
