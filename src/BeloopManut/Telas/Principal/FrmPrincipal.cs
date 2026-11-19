namespace Beloop_Manut.Telas.Principal;

public partial class FrmPrincipal : Form
{
    public FrmPrincipal() : this("Nome do usuário") { }

    public FrmPrincipal(string nomeUsuario)
    {
        InitializeComponent();
        lblUsuario.Text = nomeUsuario + "\nEquipe técnica";
        imgMarca.Image = Recursos.Imagens.Carregar("LogoBeloopManut.png");
        // Ícones fornecidos junto ao protótipo, mantidos como recursos incorporados.
        btnVisao.Image = CarregarIcone("Iconify.Lucide.dashboard.normal.png");
        btnEquipamentos.Image = CarregarIcone("Iconify.Lucide.monitor.normal.png");
        btnManutencoes.Image = CarregarIcone("Iconify.Lucide.wrench.normal.png");
        btnRelatorios.Image = CarregarIcone("Menu.Relatórios.normal.png");
        btnHistorico.Image = CarregarIcone("Iconify.Lucide.history.normal.png");
        foreach (var botao in new[] { btnVisao, btnEquipamentos, btnManutencoes, btnHistorico, btnRelatorios })
        {
            botao.Font = new Font("Segoe UI", 11F, FontStyle.Bold);
            botao.Cursor = Cursors.Hand;
            botao.FlatAppearance.MouseOverBackColor = Color.FromArgb(56, 77, 103);
            botao.ImageAlign = ContentAlignment.MiddleLeft;
            botao.TextImageRelation = TextImageRelation.ImageBeforeText;
            var icone = botao.Image;
            var fonte = botao.Font;
            botao.Disposed += (_, _) =>
            {
                icone?.Dispose();
                fonte.Dispose();
            };
        }
        btnVisao.Click += (_, _) => AbrirTela("visao_geral");
        btnEquipamentos.Click += (_, _) => AbrirTela("equipamentos");
        btnManutencoes.Click += (_, _) => AbrirTela("manutencoes");
        btnHistorico.Click += (_, _) => AbrirTela("historico");
        btnRelatorios.Click += (_, _) => AbrirTela("relatorios");
        AbrirTela("visao_geral");
    }

    private static Bitmap CarregarIcone(string recurso)
    {
        using var original = Recursos.Imagens.Carregar(recurso);
        // A borda transparente mantém um respiro entre o símbolo e o texto.
        var icone = new Bitmap(36, 28);
        using var desenho = Graphics.FromImage(icone);
        desenho.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.HighQualityBicubic;
        desenho.DrawImage(original, new Rectangle(0, 0, 28, 28));
        return icone;
    }

    private void AbrirTela(string destino)
    {
        var partes = destino.Split(':', 2);
        uint id = partes.Length == 2 && uint.TryParse(partes[1], out uint valor) ? valor : 0;
        UserControl tela = partes[0] switch
        {
            "equipamentos" => new Equipamentos.UcEquipamentos(),
            "equipamento_novo" => new EquipamentoNovo.UcEquipamentoNovo(),
            "equipamento_detalhes" => new EquipamentoDetalhes.UcEquipamentoDetalhes(id),
            "manutencoes" => new Manutencoes.UcManutencoes(),
            "manutencao_nova" => new ManutencaoNova.UcManutencaoNova(id == 0 ? null : id),
            "acompanhar" => new Acompanhar.UcAcompanhar(id),
            "concluir" => new Concluir.UcConcluir(id),
            "historico" => new Historico.UcHistorico(id),
            "relatorios" => new Relatorios.UcRelatorios(),
            _ => new VisaoGeral.UcVisaoGeral()
        };
        var ativo = partes[0] switch
        {
            "equipamentos" or "equipamento_novo" or "equipamento_detalhes" => btnEquipamentos,
            "manutencoes" or "manutencao_nova" or "acompanhar" or "concluir" => btnManutencoes,
            "historico" => btnHistorico,
            "relatorios" => btnRelatorios,
            _ => btnVisao
        };
        foreach (var botao in new[] { btnVisao, btnEquipamentos, btnManutencoes, btnHistorico, btnRelatorios })
        {
            botao.BackColor = botao == ativo ? Color.FromArgb(44, 63, 86) : pnlMenu.BackColor;
            botao.ForeColor = botao == ativo ? Color.White : Color.FromArgb(225, 233, 244);
        }
        ((ITela)tela).Navegar += AbrirTela;
        // Descartar a tela anterior libera os controles e recursos associados.
        foreach (Control anterior in pnlConteudo.Controls.Cast<Control>().ToArray()) anterior.Dispose();
        pnlConteudo.Controls.Clear();
        tela.Dock = DockStyle.Fill;
        pnlConteudo.Controls.Add(tela);
        tela.BringToFront();
    }
}
