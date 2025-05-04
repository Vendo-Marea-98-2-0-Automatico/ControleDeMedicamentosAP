using ControleDeMedicamentosAP.ModuloMedicamento;
using ControleDeMedicamentosAP.Util;
using GestaoDeEquipamentos.ConsoleApp.Compartilhado;

namespace ControleDeMedicamentosAP
{
    internal class Program
    {
        static void Main(string[] args)
        {
            TelaPrincipal telaPrincipal = new TelaPrincipal();

            while (true)
            {
                telaPrincipal.ApresentarMenuPrincipal();

                ITelaCrud telaSelecionada = telaPrincipal.ObterTela();

                char opcaoEscolhida = telaSelecionada.ApresentarMenu();

                switch (opcaoEscolhida)
                {
                    case '1': telaSelecionada.CadastrarRegistro(); break;

                    case '2': telaSelecionada.EditarRegistro(); break;

                    case '3': telaSelecionada.ExcluirRegistro(); break;

                    case '4': telaSelecionada.VisualizarRegistros(true); break;

                    case '5':
                        if (telaSelecionada is TelaMedicamento telaMedicamento)
                            telaMedicamento.ReporEstoqueMedicamento();
                        else
                            Notificador.ExibirMensagem("Essa opção não está disponível para o módulo selecionado.", ConsoleColor.Red);
                        break;

                    default: break;
                }
            }
        }
    }
}
