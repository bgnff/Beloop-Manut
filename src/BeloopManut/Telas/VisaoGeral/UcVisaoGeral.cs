using Beloop_Manut.Dados;
using static Beloop_Manut.Telas.OperacaoTela;

namespace Beloop_Manut.Telas.VisaoGeral;
public partial class UcVisaoGeral : UserControl, ITela
{
    public event Action<string>? Navegar;
    public UcVisaoGeral() {
        InitializeComponent();
        lblIndicadores.Text = "";
        btnAcao.Click += (_, _) => Navegar?.Invoke("manutencao_nova");
        var ver = new Button { Text = "Ver manutenções", Bounds = new Rectangle(850, 112, 190, 40), Anchor = AnchorStyles.Top | AnchorStyles.Right };
        pnlConteudo.Controls.Add(ver);
        ver.Click += (_, _) => Navegar?.Invoke("manutencoes");
        tabela.CellDoubleClick += (_, e) =>
        {
            if (e.RowIndex >= 0 && Selecionado(tabela) is string id) Navegar?.Invoke("acompanhar:" + id);
        };
        Load += async (_, _) => await Executar(this, async () =>
        {
            var totais = await Oficina.Ler("""
                SELECT COUNT(*) AS total, COUNT(CASE WHEN situacao = 'Disponível' THEN 1 END) AS disponiveis,
                    COUNT(CASE WHEN situacao = 'Em manutenção' THEN 1 END) AS manutencao,
                    COUNT(CASE WHEN situacao = 'Indisponível' THEN 1 END) AS indisponiveis
                FROM vw_equipamentos
                """);
            var dados = await Oficina.Ler(Oficina.Consultar + " ORDER BY m.data_abertura DESC, m.id DESC LIMIT 5");
            if (IsDisposed) return;
            var t = totais.Rows[0];
            lblIndicadores.Text = $"Equipamentos  {t["total"]}     Disponíveis  {t["disponiveis"]}     Em manutenção  {t["manutencao"]}     Indisponíveis  {t["indisponiveis"]}";
            Mostrar(tabela, dados, "id", "equipamento_id", "Problema", "Serviço", "Conclusão");
        });
    }
}
