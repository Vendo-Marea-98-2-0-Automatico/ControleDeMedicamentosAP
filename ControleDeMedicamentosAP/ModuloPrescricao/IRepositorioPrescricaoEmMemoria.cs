using ControleDeMedicamentosAP.Compartilhada;

namespace ControleDeMedicamentosAP.ModuloPrescricao
{
    public class RepositorioPrescricaoEmMemoria : RepositorioBaseEmMemoria<Prescricao>, IRepositorioPrescricao
        {
            private List<Prescricao> prescricoes = new();
            private int contadorId = 0;

            public void Inserir(Prescricao novaPrescricao)
            {
                novaPrescricao.Id = ++contadorId;
                prescricoes.Add(novaPrescricao);
            }

            public void Editar(int id, Prescricao prescricaoAtualizada)
            {
                var prescricaoExistente = SelecionarPorId(id);

                if (prescricaoExistente != null)
                    prescricaoExistente.AtualizarRegistro(prescricaoAtualizada);
            }

            public void Excluir(Prescricao prescricao)
            {
                prescricoes.Remove(prescricao);
            }

            public List<Prescricao> SelecionarTodos()
            {
                return prescricoes;
            }

            public Prescricao SelecionarPorId(int id)
            {
                return prescricoes.FirstOrDefault(p => p.Id == id);
            }

            public bool ExisteRegistroComId(int id)
            {
                return prescricoes.Any(p => p.Id == id);
            }
        }
    }

