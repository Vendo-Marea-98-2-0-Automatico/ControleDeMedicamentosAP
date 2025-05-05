

using ControleDeMedicamentosAP.Compartilhada;
using ControleDeMedicamentosAP.ConsoleApp.ModuloMedicamento;

namespace ControleDeMedicamentosAP.ConsoleApp.ModuloPrescricao
{
    public class MedicamentoPrescrito
    {
        public Medicamento Nome { get; set; }

        public int QuantidadeMedicamento { get; set; }
        public string Dosagem { get; set; }
        public string Periodo { get; set; }
        public int QuantidadeNecessaria { get; set; }
        public MedicamentoPrescrito() { }       

        public MedicamentoPrescrito(Medicamento nome, string dosagem, string periodo, int quantidade)
        {
            Nome = nome;
            Dosagem = dosagem;
            Periodo = periodo;
            QuantidadeNecessaria = quantidade;
            QuantidadeMedicamento = Nome.QuantidadeMedicamento;
           
        }

        public override string ToString()
        {
            return $"{Nome} - {Dosagem} - {Periodo} - Qtd: {QuantidadeNecessaria}";
        }
    }
}
