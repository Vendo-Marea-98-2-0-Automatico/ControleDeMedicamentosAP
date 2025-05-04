namespace GestaoMedica.ConsoleApp.ModuloPrescricao
{
    public class MedicamentoPrescrito
    {
        public string Nome;
        public string Dosagem;
        public string Periodo;
        public int QuantidadeNecessaria;

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
