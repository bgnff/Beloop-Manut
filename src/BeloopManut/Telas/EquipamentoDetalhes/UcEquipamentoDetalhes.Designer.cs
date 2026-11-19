#nullable enable
namespace Beloop_Manut.Telas.EquipamentoDetalhes;
partial class UcEquipamentoDetalhes
{
    private System.ComponentModel.IContainer? components = null;
    internal Label lblTitulo = null!;
    internal Label lblSubtitulo = null!;
    internal Button btnAcao = null!;
    internal Panel pnlConteudo = null!;
    internal Label lblDados = null!;
    internal Button btnProsseguir = null!;
    internal Button btnHistorico = null!;
    protected override void Dispose(bool disposing) { if (disposing) components?.Dispose(); base.Dispose(disposing); }
    private void InitializeComponent()
    {
        lblTitulo = new Label();
        lblSubtitulo = new Label();
        btnAcao = new Button();
        pnlConteudo = new Panel();
        lblDados = new Label();
        btnProsseguir = new Button();
        btnHistorico = new Button();
        SuspendLayout();
        lblTitulo.Name = "lblTitulo";
        lblTitulo.Location = new Point(36, 31);
        lblTitulo.Size = new Size(700, 40);
        lblTitulo.Text = "Detalhes do equipamento";
        lblTitulo.Font = new Font("Segoe UI", 21F, FontStyle.Bold);
        lblTitulo.ForeColor = Color.FromArgb(32,47,68);
        this.Controls.Add(lblTitulo);
        lblSubtitulo.Name = "lblSubtitulo";
        lblSubtitulo.Location = new Point(38, 78);
        lblSubtitulo.Size = new Size(800, 27);
        lblSubtitulo.Text = "Consulte os dados e o atendimento atual deste equipamento.";
        lblSubtitulo.Font = new Font("Segoe UI", 10F);
        lblSubtitulo.ForeColor = Color.FromArgb(113,131,154);
        this.Controls.Add(lblSubtitulo);
        btnAcao.Name = "btnAcao";
        btnAcao.Location = new Point(935, 30);
        btnAcao.Size = new Size(195, 44);
        btnAcao.Text = "Voltar";
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
        lblDados.Name = "lblDados";
        lblDados.Location = new Point(28, 30);
        lblDados.Size = new Size(900, 250);
        lblDados.Text = "EQ-001\nCompressor de ar\n\nLocalização: Oficina 01\nModelo: CP-200   •   Nº de série: 04852\n\nMANUTENÇÃO EM ANDAMENTO\nVazamento de ar próximo à válvula de saída.\nResponsável técnico: Carlos Silva";
        lblDados.Font = new Font("Segoe UI", 12F);
        pnlConteudo.Controls.Add(lblDados);
        btnProsseguir.Name = "btnProsseguir";
        btnProsseguir.Location = new Point(860, 510);
        btnProsseguir.Size = new Size(190, 42);
        btnProsseguir.Text = "Acompanhar";
        btnProsseguir.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
        btnProsseguir.BackColor = Color.FromArgb(0,73,255);
        btnProsseguir.ForeColor = Color.White;
        btnProsseguir.FlatStyle = FlatStyle.Flat;
        btnProsseguir.FlatAppearance.BorderSize = 0;
        pnlConteudo.Controls.Add(btnProsseguir);
        btnHistorico.Name = "btnHistorico";
        btnHistorico.Location = new Point(670, 510);
        btnHistorico.Size = new Size(170, 42);
        btnHistorico.Text = "Ver histórico";
        btnHistorico.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
        pnlConteudo.Controls.Add(btnHistorico);
        AutoScaleMode = AutoScaleMode.Font;
        BackColor = Color.FromArgb(241,243,247);
        AutoScroll = true;
        AutoScrollMinSize = new Size(1165, 740);
        Name = "UcEquipamentoDetalhes";
        Size = new Size(1165, 810);
        ResumeLayout(false);
    }
}
