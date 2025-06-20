﻿using ControleDeMedicamentos.ConsoleApp.Extensions;
using ControleDeMedicamentos.ConsoleApp.ModuloPaciente;

namespace ControleDeMedicamentos.ConsoleApp.Model;

public abstract class FormularioPacienteViewModel
{
    public string Nome { get; set; }
    public string Telefone { get; set; }
    public string CartaoSus { get; set; }
}

public class CadastrarPacienteViewModel : FormularioPacienteViewModel
{
    public CadastrarPacienteViewModel() { }

    public CadastrarPacienteViewModel(string nome, string telefone, string cartaoSus) : this()
    {
        Nome = nome;
        Telefone = telefone;
        CartaoSus = cartaoSus;
    }
}

public class EditarPacienteViewModel : FormularioPacienteViewModel
{
    public Guid Id { get; set; }

    public EditarPacienteViewModel() { }

    public EditarPacienteViewModel(Guid id, string nome, string telefone, string cartaoSus) : this()
    {
        Id = id;
        Nome = nome;
        Telefone = telefone;
        CartaoSus = cartaoSus;
    }
}

public class ExcluirPacienteViewModel
{
    public Guid Id { get; set; }
    public string Nome { get; set; }

    public ExcluirPacienteViewModel() { }

    public ExcluirPacienteViewModel(Guid id, string nome) : this()
    {
        Id = id;
        Nome = nome;
    }
}

public class VisualizarPacientesViewModel
{
    public List<DetalhesPacienteViewModel> Registros { get; }

    public VisualizarPacientesViewModel(List<Paciente> pacientes)
    {
        Registros = [];

        foreach (var p in pacientes)
        {
            var detalhesVM = p.ParaDetalhesVM();
            Registros.Add(detalhesVM);
        }
    }
}

public class DetalhesPacienteViewModel
{
    public Guid Id { get; set; }
    public string Nome { get; set; }
    public string Telefone { get; set; }
    public string CartaoSus { get; set; }

    public DetalhesPacienteViewModel(Guid id, string nome, string telefone, string cartaoSus)
    {
        Id = id;
        Nome = nome;
        Telefone = telefone;
        CartaoSus = cartaoSus;
    }
}