using ControleDeMedicamentosAP.Compartilhada;
using ControleDeMedicamentosAP.ModuloMedicamento;
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
        

        public Saida(Paciente paciente, Prescricao prescricao)
        {
            Paciente = paciente;
            Prescricao = prescricao;
        }

        public override void AtualizarRegistro(Saida registroEditado)
        {
            Paciente = registroEditado.Paciente;
            Prescricao = registroEditado.Prescricao;
        }

        public override string Validar()
        {
            string erros = "";

            return erros;
        }
    }
}
