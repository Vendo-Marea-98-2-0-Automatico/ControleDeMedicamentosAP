﻿using ControleDeMedicamentos.ConsoleApp.Compartilhado;
using ControleDeMedicamentos.ConsoleApp.ModuloFornecedor;
using System.Diagnostics.CodeAnalysis;

namespace ControleDeMedicamentos.ConsoleApp.ModuloMedicamento;

public class Medicamento : EntidadeBase<Medicamento>
{
    public string Nome { get; set; }
    public string Descricao { get; set; }
    public Fornecedor Fornecedor { get; set; }
    public List<RequisicaoEntrada> RequisicoesEntrada { get; set; }
    public List<RequisicaoSaida> RequisicoesSaida { get; set; }

    public int QuantidadeEmEstoque
    {
        get
        {
            int quantidadeEmEstoque = 0;

            foreach (var req in RequisicoesEntrada)
                quantidadeEmEstoque += req.QuantidadeRequisitada;

            foreach (var req in RequisicoesSaida)
            {
                foreach (var med in req.Prescricao.MedicamentoPrescritos)
                    quantidadeEmEstoque -= med.Quantidade;
            }

            return quantidadeEmEstoque;
        }
    }

    public bool EmFalta
    {
        get { return QuantidadeEmEstoque < 20; }
    }

    [ExcludeFromCodeCoverage]
    public Medicamento()
    {
        RequisicoesEntrada = new List<RequisicaoEntrada>();
        RequisicoesSaida = new List<RequisicaoSaida>();
    }

    public Medicamento(
        string nome,
        string descricao,
        Fornecedor fornecedor
    ) : this()
    {
        Id = Guid.NewGuid();
        Nome = nome;
        Descricao = descricao;
        Fornecedor = fornecedor;
    }

    public void AdicionarAoEstoque(RequisicaoEntrada requisicaoEntrada)
    {
        if (!RequisicoesEntrada.Contains(requisicaoEntrada))
            RequisicoesEntrada.Add(requisicaoEntrada);
    }

    public void RemoverDoEstoque(RequisicaoSaida requisicaoSaida)
    {
        if (!RequisicoesSaida.Contains(requisicaoSaida))
            RequisicoesSaida.Add(requisicaoSaida);
    }

    public override void AtualizarRegistro(Medicamento registroEditado)
    {
        Nome = registroEditado.Nome;
        Descricao = registroEditado.Descricao;
        Fornecedor = registroEditado.Fornecedor;
    }

    public override string Validar()
    {
        string erros = string.Empty;

        if (string.IsNullOrEmpty(Nome.Trim()))
            erros += "O campo \"Nome\" é obrigatório.";

        if (string.IsNullOrEmpty(Descricao.Trim()))
            erros += "O campo \"Descrição\" é obrigatório.";

        if (Fornecedor == null)
            erros += "O campo \"Fornecedor\" é obrigatório.";

        return erros;
    }
}