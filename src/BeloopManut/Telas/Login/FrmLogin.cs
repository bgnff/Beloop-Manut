namespace Beloop_Manut.Telas.Login;

public partial class FrmLogin : Form
{
    public FrmLogin()
    {
        InitializeComponent();
        lblAjuda.Cursor = Cursors.Hand;
        lblAjuda.Click += (_, _) => MessageBox.Show(
            "Se você esqueceu a senha ou sua conta está desativada, fale com o administrador da oficina.",
            "Ajuda para acessar");
        imagemEquipe.Image = Recursos.Imagens.Carregar("EquipeBeloopLetreiro.png");
        imagemSimbolo.Image = Recursos.Imagens.Carregar("LogoBeloop.png");
        imagemMarca.Image = Recursos.Imagens.Carregar("BeloopManutLetreiro.png");
        painelMarca.Resize += (_, _) => AjustarMarca();
        painelAcesso.Resize += (_, _) => AjustarAcesso();
        AjustarMarca();
        AjustarAcesso();
    }

    // Mantém a composição do Figma centralizada e proporcional ao redimensionar.
    private void AjustarMarca()
    {
        float escala = Math.Min(painelMarca.ClientSize.Width / 610f, painelMarca.ClientSize.Height / 900f);
        int esquerda = (painelMarca.ClientSize.Width - (int)(610 * escala)) / 2;
        int topo = (painelMarca.ClientSize.Height - (int)(900 * escala)) / 2;
        Posicionar(imagemEquipe, 86, 29, 436, 203);
        Posicionar(imagemSimbolo, 137, 205, 334, 320);
        Posicionar(imagemMarca, 73, 549, 464, 169);
        Posicionar(lblDescricao, 120, 765, 370, 48);
        void Posicionar(Control controle, int x, int y, int largura, int altura)
        {
            controle.SetBounds(esquerda + (int)(x * escala), topo + (int)(y * escala),
                (int)(largura * escala), (int)(altura * escala));
        }
    }

    // A largura máxima preserva a proporção original e mantém margens nas telas menores.
    private void AjustarAcesso()
    {
        int largura = Math.Min(475, Math.Max(250, painelAcesso.ClientSize.Width - 72));
        layoutAcesso.SetBounds((painelAcesso.ClientSize.Width - largura) / 2,
            Math.Max(30, (painelAcesso.ClientSize.Height - 490) / 2), largura, 470);
    }

    private async void btnEntrar_Click(object? sender, EventArgs e)
    {
        string login = txtUsuario.Text.Trim();
        string senha = txtSenha.Text;
        if (string.IsNullOrWhiteSpace(login) || string.IsNullOrEmpty(senha))
        {
            MessageBox.Show("Informe o usuário e a senha.", "Beloop Manut", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            return;
        }

        btnEntrar.Enabled = false;
        try
        {
            var usuario = await Dados.AutenticacaoService.AutenticarAsync(login, senha);
            if (usuario is null)
            {
                MessageBox.Show("Usuário ou senha inválidos.", "Beloop Manut", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtSenha.Clear();
                txtSenha.Focus();
                return;
            }
            txtSenha.Clear();
            Hide();
            using var principal = new Principal.FrmPrincipal(usuario.Nome);
            principal.ShowDialog(this);
            Show();
        }
        catch (MySqlConnector.MySqlException ex)
        {
            // Exibe orientações sem revelar a senha de conexão configurada.
            string detalhe = ex.Number switch
            {
                1045 => "Usuário ou senha do MySQL incorretos, ou usuário sem permissão.",
                1049 => "O banco beloop_manut não foi encontrado. Execute o schema no servidor configurado.",
                1146 => "A tabela de usuários não existe no banco configurado. Execute o schema atualizado.",
                1042 or 2003 => "Não foi possível alcançar o MySQL. Confira se ele está iniciado e revise servidor e porta.",
                _ => $"O MySQL retornou o código {ex.Number}. Confira a configuração e as permissões."
            };
            MessageBox.Show(detalhe, "Erro de conexão", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
        catch (Exception ex) when (ex is IOException or UnauthorizedAccessException or InvalidOperationException or System.Text.Json.JsonException or KeyNotFoundException or ArgumentException)
        {
            MessageBox.Show("Não foi possível ler a configuração de conexão. Confira o arquivo conexao.local.json e os campos do exemplo.", "Erro de configuração", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
        finally { btnEntrar.Enabled = true; }
    }
}
