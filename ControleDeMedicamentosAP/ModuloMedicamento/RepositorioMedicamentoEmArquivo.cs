using GestaoDeEquipamentos.ConsoleApp.Compartilhado;
using ControleDeMedicamentosAP.Compartilhada;
using ControleDeMedicamentosAP.ConsoleApp.ModuloMedicamento;

namespace ControleDeMedicamentosAP.ModuloMedicamento
{
    public class RepositorioMedicamentoEmArquivo : RepositorioBaseEmArquivo<Medicamento>, IRepositorioMedicamento
    {
        public RepositorioMedicamentoEmArquivo(ContextoDados contexto) : base(contexto)
        {
        }

        protected override List<Medicamento> ObterRegistros()
        {
            return new List<Medicamento>();
        }
    }
}
