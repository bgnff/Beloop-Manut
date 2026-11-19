using System.Data;
using Beloop_Manut.Dados;
using static Beloop_Manut.Telas.OperacaoTela;

namespace Beloop_Manut.Telas.Concluir;

public partial class UcConcluir : UserControl, ITela
{
    public event Action<string>? Navegar;
    public UcConcluir() : this(0) { }
    public UcConcluir(uint id) {
        InitializeComponent();
        lblSecao.Text = "";
        btnSalvar.Enabled = false;
        btnAcao.Click += (_, _) => Navegar?.Invoke("acompanhar:" + id);
        campo0.MaxDate = DateTime.Today;
        if (id == 0) return;
        Load += async (_, _) => await Executar(this, async () =>
        {
            var dados = await Oficina.Ler(Oficina.Consultar + " WHERE m.id = @id", ("@id", id));
            if (IsDisposed || dados.Rows.Count == 0) return;
            var linha = dados.Rows[0];
            lblSecao.Text = $"MAN-{id:D3}   •   {linha["Equipamento"]}";
            campo0.MinDate = (DateTime)linha["Abertura"];
            campo2.Text = linha["Serviço"].ToString();
            btnSalvar.Enabled = linha["Situação"].ToString() != "Concluída";
        });
        btnSalvar.Click += async (_, _) =>
        {
            if (campo1.SelectedIndex < 1 || string.IsNullOrWhiteSpace(campo2.Text))
            {
                Avisar("Informe a condição para uso e descreva o serviço.");
                return;
            }
            await Executar(this, async () =>
            {
                // Uma única instrução altera a manutenção e a disponibilidade de forma atômica.
                int alteradas = await Oficina.Gravar("""
                    UPDATE manutencoes m JOIN equipamentos e ON e.id = m.equipamento_id
                    SET m.situacao = 'Concluída', m.data_conclusao = @data,
                        m.servico_realizado = @servico, e.situacao_base = @condicao
                    WHERE m.id = @id AND m.situacao <> 'Concluída' AND m.data_abertura <= @data
                    """, ("@id", id), ("@data", campo0.Value.Date),
                    ("@servico", campo2.Text.Trim()), ("@condicao", campo1.Text));
                if (IsDisposed) return;
                if (alteradas == 0) Avisar("A manutenção já foi concluída ou a data é inválida.");
                Navegar?.Invoke("manutencoes");
            });
        };
    }

}
