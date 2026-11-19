#nullable enable
namespace Beloop_Manut.Telas.VisaoGeral;
partial class UcVisaoGeral
{
    private System.ComponentModel.IContainer? components = null;
    internal Label lblTitulo = null!;
    internal Label lblSubtitulo = null!;
    internal Button btnAcao = null!;
    internal Panel pnlConteudo = null!;
    internal Label lblIndicadores = null!;
    internal Label lblSecao = null!;
    internal DataGridView tabela = null!;
    protected override void Dispose(bool disposing) { if (disposing) components?.Dispose(); base.Dispose(disposing); }
    private void InitializeComponent()
    {
        lblTitulo = new Label();
        lblSubtitulo = new Label();
        btnAcao = new Button();
        pnlConteudo = new Panel();
        lblIndicadores = new Label();
        lblSecao = new Label();
        tabela = new DataGridView();
        SuspendLayout();
        lblTitulo.Name = "lblTitulo";
        lblTitulo.Location = new Point(36, 31);
        lblTitulo.Size = new Size(700, 40);
        lblTitulo.Text = "Visão geral";
        lblTitulo.Font = new Font("Segoe UI", 21F, FontStyle.Bold);
        lblTitulo.ForeColor = Color.FromArgb(32,47,68);
        this.Controls.Add(lblTitulo);
        lblSubtitulo.Name = "lblSubtitulo";
        lblSubtitulo.Location = new Point(38, 78);
        lblSubtitulo.Size = new Size(800, 27);
        lblSubtitulo.Text = "Acompanhe os equipamentos e as manutenções da oficina.";
        lblSubtitulo.Font = new Font("Segoe UI", 10F);
        lblSubtitulo.ForeColor = Color.FromArgb(113,131,154);
        this.Controls.Add(lblSubtitulo);
        btnAcao.Name = "btnAcao";
        btnAcao.Location = new Point(935, 30);
        btnAcao.Size = new Size(195, 44);
        btnAcao.Text = "Nova manutenção";
        btnAcao.Anchor = AnchorStyles.Top | AnchorStyles.Right;
        btnAcao.BackColor = Color.FromArgb(0,73,255);
        btnAcao.ForeColor = Color.White;
        btnAcao.FlatStyle = FlatStyle.Flat;
        btnAcao.FlatAppearance.BorderSize = 0;
        this.Controls.Add(btnAcao);
        pnlConteudo.Name = "pnlConteudo";
        pnlConteudo.Location = new Point(36, 130);
        pnlConteudo.Size = new Size(1095, 590);
        pnlConteudo.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
        pnlConteudo.BackColor = Color.White;
        this.Controls.Add(pnlConteudo);
        lblIndicadores.Name = "lblIndicadores";
        lblIndicadores.Location = new Point(25, 25);
        lblIndicadores.Size = new Size(1000, 70);
        lblIndicadores.Text = "Equipamentos     24                 Disponíveis     18                 Em manutenção     04                 Indisponíveis     02";
        lblIndicadores.Font = new Font("Segoe UI", 13F, FontStyle.Bold);
        pnlConteudo.Controls.Add(lblIndicadores);
        lblSecao.Name = "lblSecao";
        lblSecao.Location = new Point(25, 120);
        lblSecao.Size = new Size(600, 30);
        lblSecao.Text = "Manutenções recentes";
        lblSecao.Font = new Font("Segoe UI", 14F, FontStyle.Bold);
        pnlConteudo.Controls.Add(lblSecao);
        tabela.Name = "tabela";
        tabela.Location = new Point(25, 165);
        tabela.Size = new Size(1045, 350);
        tabela.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
        tabela.ReadOnly = true;
        tabela.AllowUserToAddRows = false;
        tabela.AllowUserToDeleteRows = false;
        tabela.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
        tabela.RowHeadersVisible = false;
        tabela.BackgroundColor = Color.White;
        tabela.BorderStyle = BorderStyle.None;
        pnlConteudo.Controls.Add(tabela);
        AutoScaleMode = AutoScaleMode.Font;
        BackColor = Color.FromArgb(241,243,247);
        AutoScroll = true;
        AutoScrollMinSize = new Size(1165, 810);
        Name = "UcVisaoGeral";
        Size = new Size(1165, 810);
        ResumeLayout(false);
    }
}
