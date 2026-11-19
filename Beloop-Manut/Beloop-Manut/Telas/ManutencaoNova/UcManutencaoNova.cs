namespace Beloop_Manut.Telas.ManutencaoNova;
public partial class UcManutencaoNova : UserControl, Beloop_Manut.Telas.ITela
{
    public event Action<string>? Navegar;
    public UcManutencaoNova() { InitializeComponent(); Configurar(); }
    private void Configurar()
    {
        btnAcao.Click += (_, _) => Navegar?.Invoke("manutencoes");
        btnSalvar.Click += (_, _) => MessageBox.Show("Esta ação será conectada aos dados em uma próxima etapa.", "Beloop Manut");
    }
}
