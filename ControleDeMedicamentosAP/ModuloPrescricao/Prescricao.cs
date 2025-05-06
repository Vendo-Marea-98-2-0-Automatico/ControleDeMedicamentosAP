using ControleDeMedicamentosAP.Compartilhada;
using ControleDeMedicamentosAP.ModuloMedicamento;


namespace ControleDeMedicamentosAP.ModuloPrescricao
{
    public class Prescricao : EntidadeBase<Prescricao>
    {
        public string CrmMedico { get; set; }
        public DateTime Data { get; set; }
        public List<Medicamento> Medicamentos { get; set; }
        public Prescricao() { }
        
        public Prescricao(string crmMedico, DateTime data)
        {
            CrmMedico = crmMedico;
            Data = data;
            Medicamentos = new List<Medicamento>();
        }

        public override void AtualizarRegistro(Prescricao registroEditado)
        {
            CrmMedico = registroEditado.CrmMedico;
            Data = registroEditado.Data;
            Medicamentos = registroEditado.Medicamentos;
        }

        public override string Validar()
        {
            if (string.IsNullOrWhiteSpace(CrmMedico))
                return "O campo CRM é obrigatório.";

            if (CrmMedico.Length != 6 || !CrmMedico.All(char.IsDigit))
                return "O CRM deve conter exatamente 6 dígitos numéricos.";

            if (Medicamentos == null || Medicamentos.Count == 0)
                return "É necessário informar pelo menos um medicamento.";

            return string.Empty; 
        }

        public override string ToString()
        {
            string lista = string.Join("\n", Medicamentos.Select(m => $"- {m}"));
            return $"ID: {Id} | CRM: {CrmMedico} | Data: {Data:d}\nMedicamentos:\n{lista}";
        }
    }
}
