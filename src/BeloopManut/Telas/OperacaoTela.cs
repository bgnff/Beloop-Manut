using System.Data;
using MySqlConnector;

namespace Beloop_Manut.Telas;

internal static class OperacaoTela
{
    internal static void Avisar(string mensagem) => MessageBox.Show(mensagem, "Beloop Manut");

    internal static async Task Executar(Control tela, Func<Task> acao)
    {
        tela.Enabled = false;
        try { await acao(); }
        catch (MySqlException ex) when (ex.Number == 1062)
        {
            if (!tela.IsDisposed) Avisar("Já existe uma manutenção aberta para este equipamento ou um código igual.");
        }
        catch (Exception ex) when (ex is MySqlException or IOException or InvalidOperationException or System.Text.Json.JsonException or ArgumentException or KeyNotFoundException)
        {
            if (!tela.IsDisposed) Avisar("Não foi possível concluir a operação. Confira a conexão e o esquema do banco.");
        }
        finally { if (!tela.IsDisposed) tela.Enabled = true; }
    }

    internal static void Mostrar(DataGridView grade, DataTable dados, params string[] ocultas)
    {
        grade.DataSource = dados;
        grade.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
        grade.MultiSelect = false;
        foreach (string nome in ocultas)
            grade.Columns[nome]!.Visible = false;
        foreach (DataGridViewColumn coluna in grade.Columns)
            if (coluna.ValueType == typeof(DateTime)) coluna.DefaultCellStyle.Format = "dd/MM/yyyy";
    }

    internal static string? Selecionado(DataGridView grade) =>
        (grade.CurrentRow?.DataBoundItem as DataRowView)?["id"].ToString();
}
