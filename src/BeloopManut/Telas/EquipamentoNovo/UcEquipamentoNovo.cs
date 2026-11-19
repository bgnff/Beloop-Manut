using Beloop_Manut.Dados;
using MySqlConnector;

namespace Beloop_Manut.Telas.EquipamentoNovo;
public partial class UcEquipamentoNovo : UserControl, ITela
{
    public event Action<string>? Navegar;
    public UcEquipamentoNovo()
    {
        InitializeComponent();
        btnAcao.Click += (_, _) => Navegar?.Invoke("equipamentos");
        btnSalvar.Click += SalvarAsync;
    }

    private async void SalvarAsync(object? sender, EventArgs e)
    {
        string codigo = campo0.Text.Trim(), nome = campo1.Text.Trim(), localizacao = campo2.Text.Trim();
        if (codigo.Length == 0 || nome.Length == 0 || localizacao.Length == 0)
        {
            MessageBox.Show("Preencha código, nome e localização.", "Beloop Manut", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            return;
        }
        if (codigo.Length > 30 || nome.Length > 120 || localizacao.Length > 120 || campo3.Text.Trim().Length > 120 || campo4.Text.Trim().Length > 120)
        {
            MessageBox.Show("Um dos campos excede o tamanho permitido.", "Beloop Manut", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            return;
        }
        btnSalvar.Enabled = false;
        try
        {
            await EquipamentosRepositorio.CadastrarAsync(codigo, nome, localizacao, campo3.Text.Trim(), campo4.Text.Trim(), campo5.Text);
            if (IsDisposed) return;
            MessageBox.Show("Equipamento cadastrado com sucesso.", "Beloop Manut", MessageBoxButtons.OK, MessageBoxIcon.Information);
            Navegar?.Invoke("equipamentos");
        }
        catch (MySqlException ex) when (ex.Number == 1062)
        {
            MessageBox.Show("Já existe um equipamento com esse código.", "Beloop Manut", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }
        catch (Exception ex) when (ex is MySqlException or IOException or InvalidOperationException or System.Text.Json.JsonException or KeyNotFoundException or ArgumentException)
        {
            MessageBox.Show("Não foi possível salvar. Verifique a conexão e o schema do banco.", "Beloop Manut", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
        finally { if (!IsDisposed) btnSalvar.Enabled = true; }
    }
}
