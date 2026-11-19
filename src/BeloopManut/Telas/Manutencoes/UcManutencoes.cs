using System.Data;
using Beloop_Manut.Dados;
using static Beloop_Manut.Telas.OperacaoTela;

namespace Beloop_Manut.Telas.Manutencoes;

public partial class UcManutencoes : UserControl, ITela
{
    public event Action<string>? Navegar;
    public UcManutencoes() {
        InitializeComponent();
        btnAcao.Click += (_, _) => Navegar?.Invoke("manutencao_nova");
        btnDetalhes.Click += (_, _) => Abrir();
        tabela.CellDoubleClick += (_, e) => { if (e.RowIndex >= 0) Abrir(); };
        cmbSituacao.Items.Clear();
        cmbSituacao.Items.AddRange(["Todas as situações", "Aguardando", "Em andamento", "Concluída"]);
        cmbSituacao.SelectedIndex = 0;
        txtPesquisa.PlaceholderText = "Digite o nome ou código e pressione Enter";
        Load += async (_, _) => await Carregar();
        cmbSituacao.SelectedIndexChanged += async (_, _) => await Carregar();
        txtPesquisa.KeyDown += async (_, e) => { if (e.KeyCode == Keys.Enter) { e.SuppressKeyPress = true; await Carregar(); } };
    }

    private void Abrir()
    {
        if (Selecionado(tabela) is string id) Navegar?.Invoke("acompanhar:" + id);
        else Avisar("Selecione uma manutenção.");
    }

    private Task Carregar() => Executar(this, async () =>
    {
        var dados = await Oficina.Ler(Oficina.Consultar +
            " WHERE (LOCATE(@busca, e.nome) > 0 OR LOCATE(@busca, e.codigo) > 0 OR @busca = '')" +
            " AND (@situacao = '' OR m.situacao = @situacao) ORDER BY m.id DESC",
            ("@busca", txtPesquisa.Text.Trim()), ("@situacao", cmbSituacao.SelectedIndex == 0 ? "" : cmbSituacao.Text));
        if (!IsDisposed) Mostrar(tabela, dados, "id", "equipamento_id", "Problema", "Serviço");
    });
}
