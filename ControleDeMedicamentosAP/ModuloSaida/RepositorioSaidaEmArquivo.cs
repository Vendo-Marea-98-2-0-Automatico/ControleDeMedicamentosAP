using ControleDeMedicamentosAP.Compartilhada;
using ControleDeMedicamentosAP.ModuloEntrada;
using GestaoDeEquipamentos.ConsoleApp.Compartilhado;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
