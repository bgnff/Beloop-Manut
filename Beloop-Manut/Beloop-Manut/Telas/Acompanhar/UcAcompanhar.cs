namespace Beloop_Manut.Telas.Acompanhar;
public partial class UcAcompanhar : UserControl, Beloop_Manut.Telas.ITela
{
    public event Action<string>? Navegar;
    public UcAcompanhar() { InitializeComponent(); Configurar(); }
    private void Configurar()
    {
        btnAcao.Click += (_, _) => Navegar?.Invoke("manutencoes");
        btnProsseguir.Click += (_, _) => Navegar?.Invoke("concluir");
    }
}
