using Beloop_Manut.Dados;
using static Beloop_Manut.Telas.OperacaoTela;

namespace Beloop_Manut.Telas.EquipamentoDetalhes;
public partial class UcEquipamentoDetalhes : UserControl, ITela
{
    public event Action<string>? Navegar;
    public UcEquipamentoDetalhes() : this(0) { }
    public UcEquipamentoDetalhes(uint id) {
        InitializeComponent();
        lblDados.Text = "";
        btnHistorico.Enabled = btnProsseguir.Enabled = false;
        btnAcao.Click += (_, _) => Navegar?.Invoke("equipamentos");
        btnHistorico.Click += (_, _) => Navegar?.Invoke("historico:" + id);
        uint aberta = 0;
        btnProsseguir.Click += (_, _) => Navegar?.Invoke(aberta == 0 ? "manutencao_nova:" + id : "acompanhar:" + aberta);
        if (id == 0) return;
        Load += async (_, _) => await Executar(this, async () =>
        {
            var dados = await Oficina.Ler("""
                SELECT e.*, m.id AS aberta, m.problema, m.responsavel
                FROM vw_equipamentos e LEFT JOIN manutencoes m ON m.equipamento_em_aberto = e.id
                WHERE e.id = @id
                """, ("@id", id));
            if (IsDisposed || dados.Rows.Count == 0) return;
            var linha = dados.Rows[0];
            lblDados.Text = $"{linha["codigo"]}   •   {linha["nome"]}\n\nLocalização: {linha["localizacao"]}\nModelo: {linha["modelo"]}   •   Nº de série: {linha["numero_serie"]}\n\nSituação: {linha["situacao"]}\n{linha["problema"]}\n{linha["responsavel"]}";
            aberta = linha["aberta"] is uint valor ? valor : 0;
            btnProsseguir.Text = aberta == 0 ? "Nova manutenção" : "Acompanhar";
            btnHistorico.Enabled = btnProsseguir.Enabled = true;
        });
    }
}
