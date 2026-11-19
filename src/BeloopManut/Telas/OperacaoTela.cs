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
        catch (MySqlException ex)
        {
            string mensagem = ex.Number switch
            {
                1042 or 2003 => "Não foi possível alcançar o MySQL. Confira se o servidor está iniciado e a porta está correta.",
                1044 or 1045 => "A conta do MySQL não tem acesso. Confira as credenciais e permissões.",
                1049 or 1054 or 1146 => "O esquema do banco está incompleto ou incompatível. Confira o script 04_schema_completo.sql.",
                _ => $"O MySQL não concluiu a operação (código {ex.Number})."
            };
            if (!tela.IsDisposed) Avisar(mensagem);
        }
        catch (Exception ex) when (ex is IOException or InvalidOperationException or System.Text.Json.JsonException or ArgumentException or KeyNotFoundException)
        {
            if (!tela.IsDisposed) Avisar("Não foi possível concluir a operação. Confira a conexão e o esquema do banco.");
        }
        finally { if (!tela.IsDisposed) tela.Enabled = true; }
    }

    internal static void Mostrar(DataGridView grade, DataTable dados, params string[] ocultas)
    {
        grade.EnableHeadersVisualStyles = false;
        grade.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(244, 247, 250);
        grade.ColumnHeadersDefaultCellStyle.ForeColor = Color.FromArgb(85, 104, 128);
        grade.DefaultCellStyle.ForeColor = Color.FromArgb(32, 47, 68);
        grade.DefaultCellStyle.SelectionBackColor = Color.FromArgb(226, 235, 255);
        grade.DefaultCellStyle.SelectionForeColor = grade.DefaultCellStyle.ForeColor;
        grade.GridColor = Color.FromArgb(230, 236, 243);
        grade.CellBorderStyle = DataGridViewCellBorderStyle.SingleHorizontal;
        grade.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.None;
        grade.RowTemplate.Height = 36;
        grade.AutoGenerateColumns = true;
        grade.DataSource = dados;
        grade.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
        grade.MultiSelect = false;
        foreach (string nome in ocultas)
            if (grade.Columns[nome] is { } colunaOculta) colunaOculta.Visible = false;
        foreach (DataGridViewColumn coluna in grade.Columns)
            if (coluna.ValueType == typeof(DateTime)) coluna.DefaultCellStyle.Format = "dd/MM/yyyy";
    }

    internal static string? Selecionado(DataGridView grade) =>
        (grade.CurrentRow?.DataBoundItem as DataRowView)?["id"].ToString();
}
