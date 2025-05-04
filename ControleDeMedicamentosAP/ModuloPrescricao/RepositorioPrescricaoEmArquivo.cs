using ControleDeMedicamentosAP.Compartilhada;
using GestaoDeEquipamentos.ConsoleApp.Compartilhado;

namespace ControleDeMedicamentosAP.ModuloPrescricao
{
    public class RepositorioPrescricaoEmArquivo : RepositorioBaseEmArquivo<Prescricao>, IRepositorioPrescricao
    {
        public RepositorioPrescricaoEmArquivo(ContextoDados contexto) : base(contexto)
        {
        }

        protected override List<Prescricao> ObterRegistros()
        {
            return contexto.Prescricoes;
        }
    }
}
