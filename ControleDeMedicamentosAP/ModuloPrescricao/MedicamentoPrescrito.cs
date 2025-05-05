
using ControleDeMedicamentosAP.Compartilhada;

namespace ControleDeMedicamentosAP.ConsoleApp.ModuloPrescricao
{
    public class MedicamentoPrescrito
    {
        public string Nome { get; set; }
        public string Dosagem { get; set; }
        public string Periodo { get; set; }
        public int QuantidadeNecessaria { get; set; }
        public MedicamentoPrescrito() { }       

        public MedicamentoPrescrito(string nome, string dosagem, string periodo, int quantidade)
        {
            Nome = nome;
            Dosagem = dosagem;
            Periodo = periodo;
            QuantidadeNecessaria = quantidade;
        }

        public override string ToString()
        {
            return $"{Nome} - {Dosagem} - {Periodo} - Qtd: {QuantidadeNecessaria}";
        }
    }
}
