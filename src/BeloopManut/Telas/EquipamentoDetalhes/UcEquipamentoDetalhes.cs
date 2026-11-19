namespace Beloop_Manut.Telas.EquipamentoDetalhes;
public partial class UcEquipamentoDetalhes : UserControl, Beloop_Manut.Telas.ITela
{
    public event Action<string>? Navegar;
    public UcEquipamentoDetalhes() { InitializeComponent(); Configurar(); }
    private void Configurar()
    {
        btnAcao.Click += (_, _) => Navegar?.Invoke("equipamentos");
        btnProsseguir.Click += (_, _) => Navegar?.Invoke("acompanhar");
        btnHistorico.Click += (_, _) => Navegar?.Invoke("historico");
    }
}
