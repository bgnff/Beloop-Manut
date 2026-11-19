using System.Data;
using Beloop_Manut.Dados;
using static Beloop_Manut.Telas.OperacaoTela;

namespace Beloop_Manut.Telas.Acompanhar;

public partial class UcAcompanhar : UserControl, ITela
{
    public event Action<string>? Navegar;
    public UcAcompanhar() : this(0) { }
    public UcAcompanhar(uint id) {
        InitializeComponent();
        lblDados.Text = "";
        btnProsseguir.Enabled = false;
        btnAcao.Click += (_, _) => Navegar?.Invoke("manutencoes");
        btnProsseguir.Click += (_, _) => Navegar?.Invoke("concluir:" + id);
        txtServico.ReadOnly = true;
        var atualizar = new Button { Text = "Atualizar serviço", Bounds = new Rectangle(660, 510, 185, 42), Anchor = AnchorStyles.Bottom | AnchorStyles.Right, Enabled = false };
        pnlConteudo.Controls.Add(atualizar);
        atualizar.Click += async (_, _) => await Executar(this, async () =>
        {
            int alteradas = await Oficina.Gravar("UPDATE manutencoes SET servico_realizado = @servico, situacao = 'Em andamento' WHERE id = @id AND situacao <> 'Concluída'",
                ("@servico", txtServico.Text.Trim()), ("@id", id));
            if (!IsDisposed) Avisar(alteradas > 0 ? "Atendimento atualizado." : "A manutenção já foi concluída.");
        });
        if (id == 0) return;
        Load += async (_, _) => await Executar(this, async () =>
        {
            var dados = await Oficina.Ler(Oficina.Consultar + " WHERE m.id = @id", ("@id", id));
            if (IsDisposed || dados.Rows.Count == 0) return;
            var linha = dados.Rows[0];
            lblTitulo.Text = $"Manutenção #MAN-{id:D3}";
            lblDados.Text = $"{linha["Equipamento"]}   •   {linha["Código"]}   •   {linha["Tipo"]}\n{linha["Situação"]}   •   {linha["Abertura"]:dd/MM/yyyy}\n\nPROBLEMA INFORMADO\n{linha["Problema"]}\n\nRESPONSÁVEL TÉCNICO\n{linha["Responsável"]}";
            txtServico.Text = linha["Serviço"].ToString();
            atualizar.Enabled = btnProsseguir.Enabled = linha["Situação"].ToString() != "Concluída";
            txtServico.ReadOnly = !atualizar.Enabled;
        });
    }

}
