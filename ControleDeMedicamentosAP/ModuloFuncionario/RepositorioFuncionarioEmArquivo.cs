using ControleDeMedicamentosAP.Compartilhada;
using GestaoDeEquipamentos.ConsoleApp.Compartilhado;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControleDeMedicamentosAP.ModuloFuncionario
{
    public class RepositorioFuncionarioEmArquivo : RepositorioBaseEmArquivo<Funcionario>, IRepositorioFuncionario
    {
        public RepositorioFuncionarioEmArquivo(ContextoDados contexto) : base(contexto)
        {
        }

        protected override List<Funcionario> ObterRegistros()
        {
            return contexto.Funcionarios;
        }
    }
}
