using System.Text.Json;
using MySqlConnector;

namespace Beloop_Manut.Dados;

public static class ConexaoMySql
{
    public static MySqlConnection Criar()
    {
        // O arquivo local fica fora do Git e é procurado junto ao executável.
        string caminho = Path.Combine(AppContext.BaseDirectory, "conexao.local.json");
        if (!File.Exists(caminho))
            throw new InvalidOperationException("Configure o arquivo conexao.local.json junto ao executável. Consulte BancoDeDados/03_login.md.");
        using JsonDocument configuracao = JsonDocument.Parse(File.ReadAllText(caminho));
        string? conexao = configuracao.RootElement.GetProperty("conexao").GetString();
        if (string.IsNullOrWhiteSpace(conexao))
            throw new InvalidOperationException("Informe a conexão MySQL no arquivo conexao.local.json.");
        return new MySqlConnection(conexao);
    }
}
