namespace Beloop_Manut.Telas.Relatorios;
public partial class UcRelatorios : UserControl, Beloop_Manut.Telas.ITela
{
    public event Action<string>? Navegar { add { } remove { } }
    public UcRelatorios() { InitializeComponent(); Configurar(); }
    private void Configurar()
    {
        btnSalvar.Click += (_, _) => MessageBox.Show("Esta ação será conectada aos dados em uma próxima etapa.", "Beloop Manut");
    }
}
