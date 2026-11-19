namespace Beloop_Manut.Telas.Historico;
public partial class UcHistorico : UserControl, Beloop_Manut.Telas.ITela
{
    public event Action<string>? Navegar;
    public UcHistorico() { InitializeComponent(); Configurar(); }
    private void Configurar()
    {
        btnAcao.Click += (_, _) => Navegar?.Invoke("manutencao_nova");
        tabela.Columns.AddRange(new DataGridViewTextBoxColumn { HeaderText = "Equipamento" }, new DataGridViewTextBoxColumn { HeaderText = "Tipo" }, new DataGridViewTextBoxColumn { HeaderText = "Responsável" }, new DataGridViewTextBoxColumn { HeaderText = "Abertura" }, new DataGridViewTextBoxColumn { HeaderText = "Situação" });
        tabela.Rows.Add("Compressor de ar", "Corretiva", "Carlos Silva", "18/11/2026", "Em andamento");
        tabela.Rows.Add("Furadeira de bancada", "Preventiva", "Ana Souza", "16/11/2026", "Concluída");
        tabela.Rows.Add("Serra elétrica", "Corretiva", "Carlos Silva", "14/11/2026", "Aguardando");
    }
}
