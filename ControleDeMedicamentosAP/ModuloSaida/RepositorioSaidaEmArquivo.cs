using ControleDeMedicamentosAP.Compartilhada;
using GestaoDeEquipamentos.ConsoleApp.Compartilhado;


namespace ControleDeMedicamentosAP.ModuloSaida
{
    public class RepositorioSaidaEmArquivo : RepositorioBaseEmArquivo<Saida>, IRepositorioSaida
    {
        public RepositorioSaidaEmArquivo(ContextoDados contexto) : base(contexto)
        {
        }

        protected override List<Saida> ObterRegistros()
        {
            return contexto.Saidas;
        }
    }
}
