using System.Data;
using Beloop_Manut.Dados;
using static Beloop_Manut.Telas.OperacaoTela;

namespace Beloop_Manut.Telas.ManutencaoNova;

public partial class UcManutencaoNova : UserControl, ITela
{
    public event Action<string>? Navegar;
    public UcManutencaoNova() : this(null) { }
    public UcManutencaoNova(uint? equipamentoId) {
        InitializeComponent();
        btnAcao.Click += (_, _) => Navegar?.Invoke("manutencoes");
        btnSalvar.Enabled = false;
        campo0.Items.Clear();
        campo2.Items.Clear();
        campo2.DropDownStyle = ComboBoxStyle.DropDown;
        campo2.MaxLength = 120;
        campo3.MaxDate = DateTime.Today;
        Load += async (_, _) => await Executar(this, async () =>
        {
            var equipamentos = await Oficina.Ler("SELECT id, CONCAT(codigo, ' - ', nome) AS nome FROM vw_equipamentos WHERE situacao <> 'Em manutenção' ORDER BY nome");
            if (IsDisposed) return;
            campo0.DisplayMember = "nome";
            campo0.ValueMember = "id";
            campo0.DataSource = equipamentos;
            btnSalvar.Enabled = equipamentos.Rows.Count > 0;
            if (equipamentos.Rows.Count == 0)
                Avisar("Nenhum equipamento disponível para uma nova manutenção. Cadastre um equipamento ou conclua uma manutenção aberta.");
            if (equipamentoId is uint id) campo0.SelectedValue = id;
        });
        btnSalvar.Click += async (_, _) =>
        {
            if (campo0.SelectedValue is not uint id || campo1.SelectedIndex < 1 ||
                string.IsNullOrWhiteSpace(campo2.Text) || string.IsNullOrWhiteSpace(campo5.Text))
            {
                Avisar("Selecione o equipamento e o tipo. Preencha o responsável e o problema.");
                return;
            }
            await Executar(this, async () =>
            {
                await Oficina.Gravar("INSERT INTO manutencoes (equipamento_id,tipo,responsavel,problema,data_abertura,situacao) VALUES (@id,@tipo,@resp,@problema,@data,@situacao)",
                    ("@id", id), ("@tipo", campo1.Text), ("@resp", campo2.Text.Trim()),
                    ("@problema", campo5.Text.Trim()), ("@data", campo3.Value.Date), ("@situacao", campo4.Text));
                if (!IsDisposed) Navegar?.Invoke("manutencoes");
            });
        };
    }

}
