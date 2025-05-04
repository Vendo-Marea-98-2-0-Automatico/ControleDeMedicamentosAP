using ControleDeMedicamentosAP.Compartilhada;
using ControleDeMedicamentosAP.ConsoleApp.ModuloMedicamento;
using ControleDeMedicamentosAP.ModuloEntrada;
using ControleDeMedicamentosAP.ModuloPaciente;
using ControleDeMedicamentosAP.ModuloPrescricao;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControleDeMedicamentosAP.ModuloSaida
{
    public class Saida : EntidadeBase<Saida>
    {
        public DateTime dataAbertura = DateTime.Now;
        public Paciente Paciente { get; set; }
        public Prescricao Prescricao { get; set; }
        public Medicamento Medicamento { get; set; }

        public Saida(Paciente paciente, Prescricao prescricao, Medicamento medicamento)
        {
            Paciente = paciente;
            Prescricao = prescricao;
            Medicamento = medicamento;
        }

        public override void AtualizarRegistro(Saida registroEditado)
        {
            Paciente = registroEditado.Paciente;
            Prescricao = registroEditado.Prescricao;
            Medicamento = registroEditado.Medicamento;
        }

        public override string Validar()
        {
            string erros = "";

            if (Medicamento.QuantidadeMedicamento <= 0)
                erros += "O Medicamento Selecionado Não Está em Estoque.\n";

            return erros;
        }

    }
}
