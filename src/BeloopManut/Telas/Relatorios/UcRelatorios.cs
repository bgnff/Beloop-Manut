using System.Data;
using System.Drawing.Printing;
using Beloop_Manut.Dados;
using static Beloop_Manut.Telas.OperacaoTela;

namespace Beloop_Manut.Telas.Relatorios;

public partial class UcRelatorios : UserControl, ITela
{
    public event Action<string>? Navegar { add { } remove { } }
    private readonly DataGridView resultado = new();
    private readonly Button exportar = new();
    private DataTable? dados;

    public UcRelatorios()
    {
        InitializeComponent();
        resultado.Bounds = new Rectangle(28, 312, 1020, 185);
        resultado.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
        resultado.ReadOnly = true;
        resultado.AllowUserToAddRows = false;
        resultado.RowHeadersVisible = false;
        resultado.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
        resultado.BackgroundColor = Color.White;
        pnlConteudo.Controls.Add(resultado);
        exportar.Text = "Exportar PDF";
        exportar.Bounds = new Rectangle(710, 520, 160, 42);
        exportar.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
        exportar.Enabled = false;
        pnlConteudo.Controls.Add(exportar);
        exportar.Click += (_, _) => Imprimir();
        var limpar = new Button { Text = "Limpar filtros", Bounds = new Rectangle(530, 520, 160, 42), Anchor = AnchorStyles.Bottom | AnchorStyles.Right };
        pnlConteudo.Controls.Add(limpar);
        limpar.Click += (_, _) => Limpar();
        btnSalvar.Click += async (_, _) => await Gerar();
        campo0.ValueChanged += (_, _) => Invalidar();
        campo1.ValueChanged += (_, _) => Invalidar();
        campo2.SelectedIndexChanged += (_, _) => Invalidar();
        campo3.SelectedIndexChanged += (_, _) => Invalidar();
        Limpar();
    }

    private void Invalidar()
    {
        dados = null;
        resultado.DataSource = null;
        exportar.Enabled = false;
    }

    private void Limpar()
    {
        campo0.Value = DateTime.Today.AddDays(1 - DateTime.Today.Day);
        campo1.Value = DateTime.Today;
        campo2.SelectedIndex = campo3.SelectedIndex = 0;
        Invalidar();
    }

    private Task Gerar()
    {
        if (campo0.Value.Date > campo1.Value.Date)
        {
            Avisar("A data inicial deve ser anterior ou igual à data final.");
            return Task.CompletedTask;
        }
        return Executar(this, async () =>
        {
            var tabela = await Oficina.Ler(Oficina.Consultar + """
                 WHERE m.data_abertura BETWEEN @inicio AND @fim
                   AND (@sit = '' OR m.situacao = @sit)
                   AND (@tipo = '' OR m.tipo = @tipo)
                 ORDER BY m.data_abertura DESC, m.id DESC
                """, ("@inicio", campo0.Value.Date), ("@fim", campo1.Value.Date),
                ("@sit", campo2.SelectedIndex == 0 ? "" : campo2.Text),
                ("@tipo", campo3.SelectedIndex == 0 ? "" : campo3.Text));
            if (IsDisposed) return;
            dados = tabela;
            Mostrar(resultado, tabela, "id", "equipamento_id", "Código", "Problema", "Serviço", "Conclusão");
            exportar.Enabled = tabela.Rows.Count > 0;
            if (tabela.Rows.Count == 0) Avisar("Nenhuma manutenção no período selecionado.");
        });
    }

    private void Imprimir()
    {
        if (dados is null || dados.Rows.Count == 0) return;
        using var documento = new PrintDocument { DocumentName = "Beloop Manut - Relatório" };
        using var seletor = new PrintDialog { Document = documento, UseEXDialog = true };
        foreach (string impressora in PrinterSettings.InstalledPrinters)
            if (impressora == "Microsoft Print to PDF") documento.PrinterSettings.PrinterName = impressora;
        if (seletor.ShowDialog(this) != DialogResult.OK) return;

        int indice = 0;
        documento.PrintPage += (_, e) =>
        {
            using var titulo = new Font("Segoe UI", 16, FontStyle.Bold);
            using var texto = new Font("Segoe UI", 10);
            var g = e.Graphics!;
            var limites = e.MarginBounds;
            g.DrawString("Beloop Manut | Relatório de manutenções", titulo, Brushes.Black, limites.Left, limites.Top);
            g.DrawString($"{campo0.Value:dd/MM/yyyy} a {campo1.Value:dd/MM/yyyy}", texto, Brushes.Black, limites.Left, limites.Top + 30);
            int y = limites.Top + 58;
            while (indice < dados.Rows.Count && y + 55 <= limites.Bottom)
            {
                var linha = dados.Rows[indice++];
                g.DrawString($"{linha["Abertura"]:dd/MM/yyyy} | {linha["Código"]} | {linha["Equipamento"]}", texto, Brushes.Black,
                    new RectangleF(limites.Left, y, limites.Width, 20));
                g.DrawString($"{linha["Tipo"]} | {linha["Situação"]} | {linha["Responsável"]}", texto, Brushes.Black,
                    new RectangleF(limites.Left, y + 22, limites.Width, 20));
                y += 55;
            }
            e.HasMorePages = indice < dados.Rows.Count && y > limites.Top + 58;
        };
        try { documento.Print(); }
        catch (InvalidPrinterException) { Avisar("Nenhuma impressora disponível. Confira o Microsoft Print to PDF."); }
        catch (System.ComponentModel.Win32Exception) { Avisar("Não foi possível imprimir o relatório."); }
    }
}
