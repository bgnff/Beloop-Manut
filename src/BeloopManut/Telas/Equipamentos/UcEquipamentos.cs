using Beloop_Manut.Dados;

namespace Beloop_Manut.Telas.Equipamentos;
public partial class UcEquipamentos : UserControl, ITela
{
    public event Action<string>? Navegar;
    private readonly System.Windows.Forms.Timer _esperaPesquisa = new() { Interval = 350 };
    private int _versaoPesquisa;

    public UcEquipamentos()
    {
        InitializeComponent();
        btnAcao.Click += (_, _) => Navegar?.Invoke("equipamento_novo");
        btnDetalhes.Click += (_, _) =>
        {
            if (OperacaoTela.Selecionado(tabela) is string id) Navegar?.Invoke("equipamento_detalhes:" + id);
            else OperacaoTela.Avisar("Selecione um equipamento.");
        };
        tabela.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
        tabela.MultiSelect = false;
        // Aguarda o usuário terminar de digitar antes de consultar novamente.
        _esperaPesquisa.Tick += async (_, _) => { _esperaPesquisa.Stop(); await CarregarAsync(); };
        txtPesquisa.TextChanged += (_, _) => { _esperaPesquisa.Stop(); _esperaPesquisa.Start(); };
        cmbSituacao.SelectedIndexChanged += async (_, _) => await CarregarAsync();
        Load += async (_, _) => await CarregarAsync();
        Disposed += (_, _) => _esperaPesquisa.Dispose();
    }

    private async Task CarregarAsync()
    {
        int versao = ++_versaoPesquisa;
        try
        {
            string situacao = cmbSituacao.SelectedIndex <= 0 ? "" : cmbSituacao.Text;
            var dados = await EquipamentosRepositorio.ListarAsync(txtPesquisa.Text.Trim(), situacao);
            if (IsDisposed || versao != _versaoPesquisa) return;
            OperacaoTela.Mostrar(tabela, dados, "id");
        }
        catch (Exception ex) when (ex is MySqlConnector.MySqlException or IOException or InvalidOperationException or System.Text.Json.JsonException or KeyNotFoundException or ArgumentException)
        {
            if (!IsDisposed && versao == _versaoPesquisa)
                MessageBox.Show("Não foi possível carregar os equipamentos. Verifique a conexão e o schema do banco.", "Beloop Manut", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
    }
}
