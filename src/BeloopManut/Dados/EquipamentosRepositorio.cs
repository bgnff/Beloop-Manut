using System.Data;
using MySqlConnector;

namespace Beloop_Manut.Dados;

public static class EquipamentosRepositorio
{
    public static async Task<DataTable> ListarAsync(string pesquisa, string situacao)
    {
        await using var conexao = ConexaoMySql.Criar();
        await conexao.OpenAsync();
        const string sql = """
            SELECT id, codigo AS Identificação, nome AS Equipamento, localizacao AS Local, situacao AS Situação
            FROM vw_equipamentos
            WHERE (nome LIKE CONCAT('%', @pesquisa, '%') OR codigo LIKE CONCAT('%', @pesquisa, '%'))
              AND (@situacao = '' OR situacao = @situacao)
            ORDER BY nome
            """;
        await using var comando = new MySqlCommand(sql, conexao);
        comando.Parameters.AddWithValue("@pesquisa", pesquisa);
        comando.Parameters.AddWithValue("@situacao", situacao);
        await using var leitor = await comando.ExecuteReaderAsync();
        var tabela = new DataTable();
        tabela.Load(leitor);
        return tabela;
    }

    public static async Task CadastrarAsync(string codigo, string nome, string localizacao, string modelo, string serie, string situacao)
    {
        await using var conexao = ConexaoMySql.Criar();
        await conexao.OpenAsync();
        const string sql = "INSERT INTO equipamentos (codigo, nome, localizacao, modelo, numero_serie, situacao_base) VALUES (@codigo, @nome, @localizacao, @modelo, @serie, @situacao)";
        await using var comando = new MySqlCommand(sql, conexao);
        comando.Parameters.AddWithValue("@codigo", codigo);
        comando.Parameters.AddWithValue("@nome", nome);
        comando.Parameters.AddWithValue("@localizacao", localizacao);
        comando.Parameters.AddWithValue("@modelo", string.IsNullOrEmpty(modelo) ? DBNull.Value : modelo);
        comando.Parameters.AddWithValue("@serie", string.IsNullOrEmpty(serie) ? DBNull.Value : serie);
        comando.Parameters.AddWithValue("@situacao", situacao);
        await comando.ExecuteNonQueryAsync();
    }
}
