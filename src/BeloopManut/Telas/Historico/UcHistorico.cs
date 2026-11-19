using Beloop_Manut.Dados;
using static Beloop_Manut.Telas.OperacaoTela;

namespace Beloop_Manut.Telas.Historico;
public partial class UcHistorico : UserControl, ITela
{
    public event Action<string>? Navegar;
    public UcHistorico() : this(0) { }
    public UcHistorico(uint id) {
        InitializeComponent();
        lblSecao.Text = "Histórico de intervenções";
        btnAcao.Click += (_, _) => Navegar?.Invoke(id == 0 ? "manutencao_nova" : "manutencao_nova:" + id);
        tabela.CellDoubleClick += (_, e) =>
        {
            if (e.RowIndex >= 0 && Selecionado(tabela) is string selecionado)
                Navegar?.Invoke("acompanhar:" + selecionado);
        };
        Load += async (_, _) => await Executar(this, async () =>
        {
            var dados = await Oficina.Ler(Oficina.Consultar + " WHERE (@id = 0 OR e.id = @id) ORDER BY m.data_abertura DESC, m.id DESC", ("@id", id));
            if (!IsDisposed) Mostrar(tabela, dados, "id", "equipamento_id", "Serviço");
        });
    }
}
