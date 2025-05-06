using GestaoDeEquipamentos.ConsoleApp.Compartilhado;
using ControleDeMedicamentosAP.Compartilhada;
using ControleDeMedicamentosAP.ModuloMedicamento;

namespace ControleDeMedicamentosAP.ModuloMedicamento
{
    public class RepositorioMedicamentoEmArquivo : RepositorioBaseEmArquivo<Medicamento>, IRepositorioMedicamento
    {
        public RepositorioMedicamentoEmArquivo(ContextoDados contexto) : base(contexto) { }
        protected override List<Medicamento> ObterRegistros()
        {
            return new List<Medicamento>();
        }
    }
}
