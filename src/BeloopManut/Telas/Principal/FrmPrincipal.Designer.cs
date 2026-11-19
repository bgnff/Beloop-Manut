#nullable enable
namespace Beloop_Manut.Telas.Principal;
partial class FrmPrincipal
{
    private System.ComponentModel.IContainer? components = null;
    private Panel pnlMenu = null!;
    private Panel pnlCabecalho = null!;
    private Panel pnlConteudo = null!;
    private PictureBox imgMarca = null!;
    private Label lblEquipe = null!;
    private Label lblUsuario = null!;
    private Button btnVisao = null!;
    private Button btnEquipamentos = null!;
    private Button btnManutencoes = null!;
    private Button btnHistorico = null!;
    private Button btnRelatorios = null!;
    protected override void Dispose(bool disposing) { if (disposing) components?.Dispose(); base.Dispose(disposing); }
    private void InitializeComponent()
    {
        pnlMenu = new Panel(); pnlCabecalho = new Panel(); pnlConteudo = new Panel();
        imgMarca = new PictureBox(); lblEquipe = new Label(); lblUsuario = new Label();
        btnVisao = new Button(); btnEquipamentos = new Button(); btnManutencoes = new Button(); btnHistorico = new Button(); btnRelatorios = new Button();
        SuspendLayout();
        pnlMenu.Dock = DockStyle.Left; pnlMenu.Width = 238; pnlMenu.BackColor = Color.FromArgb(21,34,52);
        imgMarca.Location = new Point(27, 15); imgMarca.Size = new Size(180, 70); imgMarca.SizeMode = PictureBoxSizeMode.Zoom;
        lblUsuario.Text = "Nome do usuário\nCargo / Função"; lblUsuario.ForeColor = Color.FromArgb(190,205,222); lblUsuario.Location = new Point(24, 815); lblUsuario.Size = new Size(190, 55); lblUsuario.Anchor = AnchorStyles.Left | AnchorStyles.Bottom;
        btnVisao.Location = new Point(12, 135); btnVisao.Size = new Size(214, 40); btnVisao.Text = "Visão geral";
        btnEquipamentos.Location = new Point(12, 185); btnEquipamentos.Size = new Size(214, 40); btnEquipamentos.Text = "Equipamentos";
        btnManutencoes.Location = new Point(12, 235); btnManutencoes.Size = new Size(214, 40); btnManutencoes.Text = "Manutenções";
        btnHistorico.Location = new Point(12, 285); btnHistorico.Size = new Size(214, 40); btnHistorico.Text = "Histórico";
        btnRelatorios.Location = new Point(12, 335); btnRelatorios.Size = new Size(214, 40); btnRelatorios.Text = "Relatórios";
        btnVisao.FlatStyle = FlatStyle.Flat; btnVisao.FlatAppearance.BorderSize = 0; btnVisao.BackColor = Color.FromArgb(21,34,52); btnVisao.ForeColor = Color.FromArgb(194,205,220); btnVisao.TextAlign = ContentAlignment.MiddleLeft; btnVisao.Padding = new Padding(14,0,0,0); pnlMenu.Controls.Add(btnVisao);
        btnEquipamentos.FlatStyle = FlatStyle.Flat; btnEquipamentos.FlatAppearance.BorderSize = 0; btnEquipamentos.BackColor = Color.FromArgb(21,34,52); btnEquipamentos.ForeColor = Color.FromArgb(194,205,220); btnEquipamentos.TextAlign = ContentAlignment.MiddleLeft; btnEquipamentos.Padding = new Padding(14,0,0,0); pnlMenu.Controls.Add(btnEquipamentos);
        btnManutencoes.FlatStyle = FlatStyle.Flat; btnManutencoes.FlatAppearance.BorderSize = 0; btnManutencoes.BackColor = Color.FromArgb(21,34,52); btnManutencoes.ForeColor = Color.FromArgb(194,205,220); btnManutencoes.TextAlign = ContentAlignment.MiddleLeft; btnManutencoes.Padding = new Padding(14,0,0,0); pnlMenu.Controls.Add(btnManutencoes);
        btnHistorico.FlatStyle = FlatStyle.Flat; btnHistorico.FlatAppearance.BorderSize = 0; btnHistorico.BackColor = Color.FromArgb(21,34,52); btnHistorico.ForeColor = Color.FromArgb(194,205,220); btnHistorico.TextAlign = ContentAlignment.MiddleLeft; btnHistorico.Padding = new Padding(14,0,0,0); pnlMenu.Controls.Add(btnHistorico);
        btnRelatorios.FlatStyle = FlatStyle.Flat; btnRelatorios.FlatAppearance.BorderSize = 0; btnRelatorios.BackColor = Color.FromArgb(21,34,52); btnRelatorios.ForeColor = Color.FromArgb(194,205,220); btnRelatorios.TextAlign = ContentAlignment.MiddleLeft; btnRelatorios.Padding = new Padding(14,0,0,0); pnlMenu.Controls.Add(btnRelatorios);
        pnlMenu.Controls.Add(imgMarca); pnlMenu.Controls.Add(lblUsuario);
        pnlCabecalho.Dock = DockStyle.Top; pnlCabecalho.Height = 72; pnlCabecalho.BackColor = Color.White;
        lblEquipe.Text = "CONTROLE DE MANUTENÇÃO                                             Equipe técnica"; lblEquipe.ForeColor = Color.FromArgb(99,117,142); lblEquipe.Location = new Point(34, 27); lblEquipe.Size = new Size(850,25); pnlCabecalho.Controls.Add(lblEquipe);
        pnlConteudo.Dock = DockStyle.Fill; pnlConteudo.BackColor = Color.FromArgb(241,243,247);
        Controls.Add(pnlConteudo); Controls.Add(pnlCabecalho); Controls.Add(pnlMenu);
        AutoScaleMode = AutoScaleMode.Font; ClientSize = new Size(1440,900); MinimumSize = new Size(1050,700); StartPosition = FormStartPosition.CenterScreen; Text = "Beloop Manut";
        WindowState = FormWindowState.Maximized;
        ResumeLayout(false);
    }
}
