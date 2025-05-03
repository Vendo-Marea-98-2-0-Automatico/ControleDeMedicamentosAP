using ControleDeMedicamentosAP.Compartilhada;
using GestaoDeEquipamentos.ConsoleApp.Compartilhado;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControleDeMedicamentosAP.ModuloEntrada
{
   public class RepositorioEntradaEmArquivo : RepositorioBaseEmArquivo<Entrada>, IRepositorioEntrada
    {
        public RepositorioEntradaEmArquivo(ContextoDados contexto) : base(contexto)
        {
        }

        protected override List<Entrada> ObterRegistros()
        {
            return contexto.Entradas;
        }
    }
}
