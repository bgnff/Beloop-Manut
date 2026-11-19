namespace Beloop_Manut.Telas.Concluir;
public partial class UcConcluir : UserControl, Beloop_Manut.Telas.ITela
{
    public event Action<string>? Navegar;
    public UcConcluir() { InitializeComponent(); Configurar(); }
    private void Configurar()
    {
        btnAcao.Click += (_, _) => Navegar?.Invoke("acompanhar");
        btnSalvar.Click += (_, _) => MessageBox.Show("Esta ação será conectada aos dados em uma próxima etapa.", "Beloop Manut");
    }
}
