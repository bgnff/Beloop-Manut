#nullable enable
namespace Beloop_Manut.Telas.Acompanhar;
partial class UcAcompanhar
{
    private System.ComponentModel.IContainer? components = null;
    internal Label lblTitulo = null!;
    internal Label lblSubtitulo = null!;
    internal Button btnAcao = null!;
    internal Panel pnlConteudo = null!;
    internal Label lblDados = null!;
    internal TextBox txtServico = null!;
    internal Button btnProsseguir = null!;
    protected override void Dispose(bool disposing) { if (disposing) components?.Dispose(); base.Dispose(disposing); }
    private void InitializeComponent()
    {
        lblTitulo = new Label();
        lblSubtitulo = new Label();
        btnAcao = new Button();
        pnlConteudo = new Panel();
        lblDados = new Label();
        txtServico = new TextBox();
        btnProsseguir = new Button();
        SuspendLayout();
        lblTitulo.Name = "lblTitulo";
        lblTitulo.Location = new Point(36, 31);
        lblTitulo.Size = new Size(700, 40);
        lblTitulo.Text = "Manutenção #MAN-004";
        lblTitulo.Font = new Font("Segoe UI", 21F, FontStyle.Bold);
        lblTitulo.ForeColor = Color.FromArgb(32,47,68);
        this.Controls.Add(lblTitulo);
        lblSubtitulo.Name = "lblSubtitulo";
        lblSubtitulo.Location = new Point(38, 78);
        lblSubtitulo.Size = new Size(800, 27);
        lblSubtitulo.Text = "Acompanhe o atendimento e registre sua conclusão.";
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
        lblDados.Text = "Compressor de ar\nEQ-001  •  Corretiva  •  Abertura: 18/11/2026\n\nPROBLEMA INFORMADO\nVazamento de ar próximo à válvula de saída.\n\nRESPONSÁVEL TÉCNICO\nCarlos Silva";
        lblDados.Font = new Font("Segoe UI", 12F);
        pnlConteudo.Controls.Add(lblDados);
        txtServico.Name = "txtServico";
        txtServico.Location = new Point(28, 320);
        txtServico.Size = new Size(1000, 80);
        txtServico.Multiline = true;
        txtServico.PlaceholderText = "Informe o atendimento realizado antes de concluir";
        pnlConteudo.Controls.Add(txtServico);
        btnProsseguir.Name = "btnProsseguir";
        btnProsseguir.Location = new Point(860, 510);
        btnProsseguir.Size = new Size(190, 42);
        btnProsseguir.Text = "Concluir serviço";
        btnProsseguir.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
        btnProsseguir.BackColor = Color.FromArgb(0,73,255);
        btnProsseguir.ForeColor = Color.White;
        btnProsseguir.FlatStyle = FlatStyle.Flat;
        btnProsseguir.FlatAppearance.BorderSize = 0;
        pnlConteudo.Controls.Add(btnProsseguir);
        AutoScaleMode = AutoScaleMode.Font;
        BackColor = Color.FromArgb(241,243,247);
        AutoScroll = true;
        AutoScrollMinSize = new Size(1165, 810);
        Name = "UcAcompanhar";
        Size = new Size(1165, 810);
        ResumeLayout(false);
    }
}
