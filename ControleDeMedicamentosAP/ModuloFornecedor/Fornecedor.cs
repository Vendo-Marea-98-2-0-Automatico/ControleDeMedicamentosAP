﻿using ControleDeMedicamentosAP.Compartilhada;
using System.Reflection.Metadata;

namespace ControleDeMedicamentosAP.ModuloFornecedor;


public class Fornecedor : EntidadeBase<Fornecedor>
{
    public string Nome {  get; set; }

    public string Telefone { get; set; }

    public string CNPJ { get; set; }

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
        CNPJ = registroEditado.CNPJ;
    }

    public override string Validar()
    {
        string erros = "";

        if (string.IsNullOrWhiteSpace(Nome))
            erros += "O campo 'Nome' é obrigatório.\n";
        if (string.IsNullOrWhiteSpace(Telefone))
            erros += "O campo 'Telefone' é obrigatório.\n";
        if (string.IsNullOrWhiteSpace(CNPJ))
            erros += "O campo 'CNPJ' é obrigatório.\n";

        return erros.Trim();
    }
}
