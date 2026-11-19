using System.Data;
using MySqlConnector;

namespace Beloop_Manut.Dados;

internal static class Oficina
{
    internal const string Consultar = """
        SELECT m.id, e.id AS equipamento_id, e.codigo AS Código, e.nome AS Equipamento,
               m.tipo AS Tipo, m.responsavel AS Responsável, m.data_abertura AS Abertura,
               m.situacao AS Situação, m.problema AS Problema, m.servico_realizado AS Serviço,
               m.data_conclusao AS Conclusão
        FROM manutencoes m JOIN equipamentos e ON e.id = m.equipamento_id
        """;

    private static MySqlCommand Comando(MySqlConnection c, string sql, (string, object)[] args)
    {
        var cmd = new MySqlCommand(sql, c);
        foreach (var (nome, valor) in args)
            cmd.Parameters.AddWithValue(nome, valor);
        return cmd;
    }

    internal static async Task<DataTable> Ler(string sql, params (string, object)[] args)
    {
        await using var c = ConexaoMySql.Criar();
        await c.OpenAsync();
        await using var cmd = Comando(c, sql, args);
        await using var leitor = await cmd.ExecuteReaderAsync();
        var dados = new DataTable();
        dados.Load(leitor);
        return dados;
    }

    internal static async Task<int> Gravar(string sql, params (string, object)[] args)
    {
        await using var c = ConexaoMySql.Criar();
        await c.OpenAsync();
        await using var cmd = Comando(c, sql, args);
        return await cmd.ExecuteNonQueryAsync();
    }
}
