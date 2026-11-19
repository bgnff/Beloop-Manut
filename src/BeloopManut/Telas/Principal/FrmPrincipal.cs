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
        btnVisao.Image = Recursos.Imagens.Carregar("Iconify.Lucide.dashboard.normal.png");
        btnEquipamentos.Image = Recursos.Imagens.Carregar("Iconify.Lucide.monitor.normal.png");
        btnManutencoes.Image = Recursos.Imagens.Carregar("Iconify.Lucide.wrench.normal.png");
        btnRelatorios.Image = Recursos.Imagens.Carregar("Menu.Relatórios.normal.png");
        btnHistorico.Image = Recursos.Imagens.Carregar("Iconify.Lucide.history.normal.png");
        foreach (var botao in new[] { btnVisao, btnEquipamentos, btnManutencoes, btnHistorico, btnRelatorios })
        {
            botao.ImageAlign = ContentAlignment.MiddleLeft;
            botao.TextImageRelation = TextImageRelation.ImageBeforeText;
        }
        btnVisao.Click += (_, _) => AbrirTela("visao_geral");
        btnEquipamentos.Click += (_, _) => AbrirTela("equipamentos");
        btnManutencoes.Click += (_, _) => AbrirTela("manutencoes");
        btnHistorico.Click += (_, _) => AbrirTela("historico");
        btnRelatorios.Click += (_, _) => AbrirTela("relatorios");
        AbrirTela("visao_geral");
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
            botao.ForeColor = botao == ativo ? Color.White : Color.FromArgb(194, 205, 220);
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
