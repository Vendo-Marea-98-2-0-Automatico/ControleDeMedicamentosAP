using ControleDeMedicamentosAP.Compartilhada;
using ControleDeMedicamentosAP.ConsoleApp.ModuloMedicamento;
using ControleDeMedicamentosAP.ModuloFuncionario;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControleDeMedicamentosAP.ModuloEntrada
{
    public class Entrada : EntidadeBase<Entrada>
    {
        
        public Medicamento Medicamento { get; set; }
        public Funcionario Funcionario { get; set; }
        public int Quantidade { get; set; }

        public DateTime DataRequisicao = DateTime.Now;



        public Entrada (Medicamento medicamento, Funcionario funcionario, int quantidade)
        {
            Medicamento = medicamento;
            Funcionario = funcionario;
            Quantidade = quantidade;
        }

        public override void AtualizarRegistro(Entrada registroEditado)
        {
            Medicamento = registroEditado.Medicamento;
            Funcionario = registroEditado.Funcionario;
            Quantidade = registroEditado.Quantidade;
        }

        public override string Validar()
        {
            string erros = "";

            if (Quantidade >= 0)
                erros += "O Campo 'Quantidade' Precisa ser um número inteiro e positivo";

            return erros;
        }
    }
}
