#nullable enable
namespace Beloop_Manut.Telas.Login;

partial class FrmLogin
{
    private System.ComponentModel.IContainer? components = null;
    private TableLayoutPanel layoutPrincipal = null!;
    private Panel painelMarca = null!;
    private Panel painelAcesso = null!;
    private PictureBox imagemEquipe = null!;
    private PictureBox imagemSimbolo = null!;
    private PictureBox imagemMarca = null!;
    private Label lblDescricao = null!;
    private TableLayoutPanel layoutAcesso = null!;
    private Label lblTitulo = null!;
    private Label lblSubtitulo = null!;
    private Label lblUsuario = null!;
    private Label lblSenha = null!;
    private Panel bordaUsuario = null!;
    private Panel bordaSenha = null!;
    private TextBox txtUsuario = null!;
    private TextBox txtSenha = null!;
    private Button btnEntrar = null!;
    private Label lblAjuda = null!;

    protected override void Dispose(bool disposing)
    {
        if (disposing) components?.Dispose();
        base.Dispose(disposing);
    }

    private void InitializeComponent()
    {
        layoutPrincipal = new TableLayoutPanel();
        painelMarca = new Panel();
        imagemEquipe = new PictureBox();
        imagemSimbolo = new PictureBox();
        imagemMarca = new PictureBox();
        lblDescricao = new Label();
        painelAcesso = new Panel();
        layoutAcesso = new TableLayoutPanel();
        lblTitulo = new Label();
        lblSubtitulo = new Label();
        lblUsuario = new Label();
        bordaUsuario = new Panel();
        txtUsuario = new TextBox();
        lblSenha = new Label();
        bordaSenha = new Panel();
        txtSenha = new TextBox();
        btnEntrar = new Button();
        lblAjuda = new Label();
        layoutPrincipal.SuspendLayout();
        painelMarca.SuspendLayout();
        ((System.ComponentModel.ISupportInitialize)imagemEquipe).BeginInit();
        ((System.ComponentModel.ISupportInitialize)imagemSimbolo).BeginInit();
        ((System.ComponentModel.ISupportInitialize)imagemMarca).BeginInit();
        painelAcesso.SuspendLayout();
        layoutAcesso.SuspendLayout();
        bordaUsuario.SuspendLayout();
        bordaSenha.SuspendLayout();
        SuspendLayout();
        // 
        // layoutPrincipal
        // 
        layoutPrincipal.ColumnCount = 2;
        layoutPrincipal.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 42.36F));
        layoutPrincipal.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 57.64F));
        layoutPrincipal.Controls.Add(painelMarca, 0, 0);
        layoutPrincipal.Controls.Add(painelAcesso, 1, 0);
        layoutPrincipal.Dock = DockStyle.Fill;
        layoutPrincipal.Location = new Point(0, 0);
        layoutPrincipal.Name = "layoutPrincipal";
        layoutPrincipal.RowCount = 1;
        layoutPrincipal.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
        layoutPrincipal.Size = new Size(1440, 900);
        layoutPrincipal.TabIndex = 0;
        // 
        // painelMarca
        // 
        painelMarca.BackColor = Color.FromArgb(21, 34, 52);
        painelMarca.Controls.Add(imagemEquipe);
        painelMarca.Controls.Add(imagemSimbolo);
        painelMarca.Controls.Add(imagemMarca);
        painelMarca.Controls.Add(lblDescricao);
        painelMarca.Dock = DockStyle.Fill;
        painelMarca.Location = new Point(0, 0);
        painelMarca.Margin = new Padding(0);
        painelMarca.Name = "painelMarca";
        painelMarca.Size = new Size(609, 900);
        painelMarca.TabIndex = 0;
        // 
        // imagemEquipe
        // 
        imagemEquipe.Anchor = AnchorStyles.Top;
        imagemEquipe.Location = new Point(86, 29);
        imagemEquipe.Name = "imagemEquipe";
        imagemEquipe.Size = new Size(436, 203);
        imagemEquipe.SizeMode = PictureBoxSizeMode.Zoom;
        imagemEquipe.TabIndex = 0;
        imagemEquipe.TabStop = false;
        // 
        // imagemSimbolo
        // 
        imagemSimbolo.Anchor = AnchorStyles.Top;
        imagemSimbolo.Location = new Point(137, 205);
        imagemSimbolo.Name = "imagemSimbolo";
        imagemSimbolo.Size = new Size(334, 320);
        imagemSimbolo.SizeMode = PictureBoxSizeMode.Zoom;
        imagemSimbolo.TabIndex = 1;
        imagemSimbolo.TabStop = false;
        // 
        // imagemMarca
        // 
        imagemMarca.Anchor = AnchorStyles.Top;
        imagemMarca.Location = new Point(73, 549);
        imagemMarca.Name = "imagemMarca";
        imagemMarca.Size = new Size(464, 169);
        imagemMarca.SizeMode = PictureBoxSizeMode.Zoom;
        imagemMarca.TabIndex = 2;
        imagemMarca.TabStop = false;
        // 
        // lblDescricao
        // 
        lblDescricao.Anchor = AnchorStyles.Top;
        lblDescricao.Font = new Font("Segoe UI", 11F);
        lblDescricao.ForeColor = Color.FromArgb(181, 195, 213);
        lblDescricao.Location = new Point(120, 765);
        lblDescricao.Name = "lblDescricao";
        lblDescricao.Size = new Size(370, 48);
        lblDescricao.TabIndex = 3;
        lblDescricao.Text = "Acompanhe equipamentos e manutenções\nem um só lugar.";
        lblDescricao.TextAlign = ContentAlignment.TopCenter;
        // 
        // painelAcesso
        // 
        painelAcesso.BackColor = Color.FromArgb(241, 243, 247);
        painelAcesso.Controls.Add(layoutAcesso);
        painelAcesso.Dock = DockStyle.Fill;
        painelAcesso.Location = new Point(609, 0);
        painelAcesso.Margin = new Padding(0);
        painelAcesso.Name = "painelAcesso";
        painelAcesso.Size = new Size(831, 900);
        painelAcesso.TabIndex = 1;
        // 
        // layoutAcesso
        // 
        layoutAcesso.Anchor = AnchorStyles.Top;
        layoutAcesso.ColumnCount = 1;
        layoutAcesso.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
        layoutAcesso.Controls.Add(lblTitulo, 0, 0);
        layoutAcesso.Controls.Add(lblSubtitulo, 0, 1);
        layoutAcesso.Controls.Add(lblUsuario, 0, 2);
        layoutAcesso.Controls.Add(bordaUsuario, 0, 3);
        layoutAcesso.Controls.Add(lblSenha, 0, 5);
        layoutAcesso.Controls.Add(bordaSenha, 0, 6);
        layoutAcesso.Controls.Add(btnEntrar, 0, 8);
        layoutAcesso.Controls.Add(lblAjuda, 0, 10);
        layoutAcesso.Location = new Point(178, 205);
        layoutAcesso.Name = "layoutAcesso";
        layoutAcesso.RowCount = 11;
        layoutAcesso.RowStyles.Add(new RowStyle(SizeType.Absolute, 42F));
        layoutAcesso.RowStyles.Add(new RowStyle(SizeType.Absolute, 73F));
        layoutAcesso.RowStyles.Add(new RowStyle(SizeType.Absolute, 24F));
        layoutAcesso.RowStyles.Add(new RowStyle(SizeType.Absolute, 54F));
        layoutAcesso.RowStyles.Add(new RowStyle(SizeType.Absolute, 27F));
        layoutAcesso.RowStyles.Add(new RowStyle(SizeType.Absolute, 24F));
        layoutAcesso.RowStyles.Add(new RowStyle(SizeType.Absolute, 54F));
        layoutAcesso.RowStyles.Add(new RowStyle(SizeType.Absolute, 36F));
        layoutAcesso.RowStyles.Add(new RowStyle(SizeType.Absolute, 50F));
        layoutAcesso.RowStyles.Add(new RowStyle(SizeType.Absolute, 26F));
        layoutAcesso.RowStyles.Add(new RowStyle(SizeType.Absolute, 30F));
        layoutAcesso.Size = new Size(475, 470);
        layoutAcesso.TabIndex = 0;
        // 
        // lblTitulo
        // 
        lblTitulo.AutoSize = true;
        lblTitulo.Font = new Font("Segoe UI", 21F, FontStyle.Bold);
        lblTitulo.ForeColor = Color.FromArgb(31, 47, 69);
        lblTitulo.Location = new Point(3, 0);
        lblTitulo.Name = "lblTitulo";
        lblTitulo.Size = new Size(275, 38);
        lblTitulo.TabIndex = 0;
        lblTitulo.Text = "Bem-vindo de volta";
        // 
        // lblSubtitulo
        // 
        lblSubtitulo.AutoSize = true;
        lblSubtitulo.Font = new Font("Segoe UI", 10F);
        lblSubtitulo.ForeColor = Color.FromArgb(111, 130, 155);
        lblSubtitulo.Location = new Point(3, 42);
        lblSubtitulo.Name = "lblSubtitulo";
        lblSubtitulo.Size = new Size(288, 19);
        lblSubtitulo.TabIndex = 1;
        lblSubtitulo.Text = "Entre para acessar o controle de manutenção.";
        // 
        // lblUsuario
        // 
        lblUsuario.AutoSize = true;
        lblUsuario.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
        lblUsuario.ForeColor = Color.FromArgb(31, 47, 69);
        lblUsuario.Location = new Point(3, 115);
        lblUsuario.Name = "lblUsuario";
        lblUsuario.Size = new Size(49, 15);
        lblUsuario.TabIndex = 2;
        lblUsuario.Text = "Usuário";
        // 
        // bordaUsuario
        // 
        bordaUsuario.BackColor = Color.White;
        bordaUsuario.BorderStyle = BorderStyle.FixedSingle;
        bordaUsuario.Controls.Add(txtUsuario);
        bordaUsuario.Dock = DockStyle.Fill;
        bordaUsuario.Location = new Point(0, 139);
        bordaUsuario.Margin = new Padding(0);
        bordaUsuario.Name = "bordaUsuario";
        bordaUsuario.Padding = new Padding(14, 12, 14, 0);
        bordaUsuario.Size = new Size(475, 54);
        bordaUsuario.TabIndex = 3;
        // 
        // txtUsuario
        // 
        txtUsuario.BorderStyle = BorderStyle.None;
        txtUsuario.Dock = DockStyle.Top;
        txtUsuario.Font = new Font("Segoe UI", 10F);
        txtUsuario.Location = new Point(14, 12);
        txtUsuario.Name = "txtUsuario";
        txtUsuario.PlaceholderText = "Digite seu usuário";
        txtUsuario.Size = new Size(445, 18);
        txtUsuario.TabIndex = 0;
        // 
        // lblSenha
        // 
        lblSenha.AutoSize = true;
        lblSenha.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
        lblSenha.ForeColor = Color.FromArgb(31, 47, 69);
        lblSenha.Location = new Point(3, 220);
        lblSenha.Name = "lblSenha";
        lblSenha.Size = new Size(41, 15);
        lblSenha.TabIndex = 4;
        lblSenha.Text = "Senha";
        // 
        // bordaSenha
        // 
        bordaSenha.BackColor = Color.White;
        bordaSenha.BorderStyle = BorderStyle.FixedSingle;
        bordaSenha.Controls.Add(txtSenha);
        bordaSenha.Dock = DockStyle.Fill;
        bordaSenha.Location = new Point(0, 244);
        bordaSenha.Margin = new Padding(0);
        bordaSenha.Name = "bordaSenha";
        bordaSenha.Padding = new Padding(14, 12, 14, 0);
        bordaSenha.Size = new Size(475, 54);
        bordaSenha.TabIndex = 5;
        // 
        // txtSenha
        // 
        txtSenha.BorderStyle = BorderStyle.None;
        txtSenha.Dock = DockStyle.Top;
        txtSenha.Font = new Font("Segoe UI", 10F);
        txtSenha.Location = new Point(14, 12);
        txtSenha.Name = "txtSenha";
        txtSenha.PlaceholderText = "Digite sua senha";
        txtSenha.Size = new Size(445, 18);
        txtSenha.TabIndex = 0;
        txtSenha.UseSystemPasswordChar = true;
        // 
        // btnEntrar
        // 
        btnEntrar.BackColor = Color.FromArgb(0, 72, 255);
        btnEntrar.Dock = DockStyle.Fill;
        btnEntrar.FlatAppearance.BorderSize = 0;
        btnEntrar.FlatStyle = FlatStyle.Flat;
        btnEntrar.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
        btnEntrar.ForeColor = Color.White;
        btnEntrar.Location = new Point(0, 334);
        btnEntrar.Margin = new Padding(0);
        btnEntrar.Name = "btnEntrar";
        btnEntrar.Size = new Size(475, 50);
        btnEntrar.TabIndex = 6;
        btnEntrar.Text = "Entrar";
        btnEntrar.UseVisualStyleBackColor = false;
        btnEntrar.Click += btnEntrar_Click;
        // 
        // lblAjuda
        // 
        lblAjuda.AutoSize = true;
        lblAjuda.Font = new Font("Segoe UI", 9F);
        lblAjuda.ForeColor = Color.FromArgb(111, 130, 155);
        lblAjuda.Location = new Point(3, 410);
        lblAjuda.Name = "lblAjuda";
        lblAjuda.Size = new Size(135, 15);
        lblAjuda.TabIndex = 7;
        lblAjuda.Text = "Problemas para acessar?";
        // 
        // FrmLogin
        // 
        AcceptButton = btnEntrar;
        AutoScaleDimensions = new SizeF(7F, 15F);
        AutoScaleMode = AutoScaleMode.Font;
        ClientSize = new Size(1440, 900);
        Controls.Add(layoutPrincipal);
        MinimumSize = new Size(1000, 700);
        Name = "FrmLogin";
        StartPosition = FormStartPosition.CenterScreen;
        Text = "Beloop Manut — Login";
        layoutPrincipal.ResumeLayout(false);
        painelMarca.ResumeLayout(false);
        ((System.ComponentModel.ISupportInitialize)imagemEquipe).EndInit();
        ((System.ComponentModel.ISupportInitialize)imagemSimbolo).EndInit();
        ((System.ComponentModel.ISupportInitialize)imagemMarca).EndInit();
        painelAcesso.ResumeLayout(false);
        layoutAcesso.ResumeLayout(false);
        layoutAcesso.PerformLayout();
        bordaUsuario.ResumeLayout(false);
        bordaUsuario.PerformLayout();
        bordaSenha.ResumeLayout(false);
        bordaSenha.PerformLayout();
        WindowState = FormWindowState.Maximized;
        ResumeLayout(false);
    }
}

