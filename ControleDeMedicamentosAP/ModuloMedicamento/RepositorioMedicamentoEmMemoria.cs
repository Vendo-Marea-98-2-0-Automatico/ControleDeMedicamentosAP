using ControleDeMedicamentosAP.Compartilhada;
using ControleDeMedicamentosAP.ConsoleApp.ModuloMedicamento;

namespace ControleDeMedicamentosAP.ModuloMedicamento
{
    public class RepositorioMedicamentoEmMemoria : RepositorioBaseEmMemoria<Medicamento>, IRepositorioMedicamento;

}
