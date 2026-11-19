using System.Security.Cryptography;
using MySqlConnector;

namespace Beloop_Manut.Dados;

public sealed record UsuarioAutenticado(int Id, string Nome, string Login);

public static class AutenticacaoService
{
    public static async Task<UsuarioAutenticado?> AutenticarAsync(string login, string senha)
    {
        await using var conexao = ConexaoMySql.Criar();
        await conexao.OpenAsync();
        const string sql = "SELECT id, nome, login, senha_salt, senha_hash, senha_iteracoes FROM usuarios WHERE login = @login AND ativo = 1 LIMIT 1";
        await using var comando = new MySqlCommand(sql, conexao);
        comando.Parameters.AddWithValue("@login", login);
        await using var leitor = await comando.ExecuteReaderAsync();
        if (!await leitor.ReadAsync()) return null;
        var salt = (byte[])leitor["senha_salt"];
        var esperado = (byte[])leitor["senha_hash"];
        int iteracoes = leitor.GetInt32("senha_iteracoes");
        // O hash é calculado novamente; a senha nunca é armazenada em texto puro.
        byte[] calculado = Rfc2898DeriveBytes.Pbkdf2(senha, salt, iteracoes, HashAlgorithmName.SHA256, esperado.Length);
        bool valido = CryptographicOperations.FixedTimeEquals(calculado, esperado);
        CryptographicOperations.ZeroMemory(calculado);
        return valido ? new UsuarioAutenticado(leitor.GetInt32("id"), leitor.GetString("nome"), leitor.GetString("login")) : null;
    }
}
