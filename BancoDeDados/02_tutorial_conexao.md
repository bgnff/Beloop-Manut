# Conectar o Beloop Manut ao MySQL

Este guia prepara e testa a conexão. As telas atuais ainda usam dados fictícios; criar o banco e testar a conexão não conecta automaticamente login, cadastros, histórico ou relatórios. Essas integrações precisam ser implementadas em C# depois.

## 1. Iniciar o MySQL e criar o banco

Inicie o MySQL no Laragon ou no serviço usado no computador. No MySQL Workbench, conecte-se à instância, abra `01_schema.sql` e execute o script inteiro. Ele cria o banco `beloop_manut`, as tabelas `equipamentos` e `manutencoes` e a consulta `vw_equipamentos`.

Alternativa no PowerShell: abra o cliente MySQL com seu usuário (o comando solicita a senha sem colocá-la no histórico):

```powershell
mysql -u root -p
```

Se `mysql` não for reconhecido, use o caminho do executável mostrado pelo Laragon. No console do MySQL, execute (com barras `/`):

```sql
SOURCE C:/Users/bgn/Documents/Codex/2026-11-18/a/Beloop-Manut/BancoDeDados/01_schema.sql;
USE beloop_manut;
SHOW TABLES;
```

Se root não tiver senha no seu ambiente local de desenvolvimento, use `mysql -u root` sem `-p`. Não altere nem recrie contas de banco por este tutorial.

## 2. Instalar o conector no Visual Studio

No Gerenciador de Soluções, clique com o botão direito no projeto **Beloop-Manut** → **Gerenciar Pacotes do NuGet** → **Procurar** → instale **MySqlConnector**. Aguarde a restauração. O conector ainda não está instalado neste projeto.

## 3. Configurar uma conexão local

Para um teste local, configure a variável de ambiente de usuário `BELOOP_MYSQL` no Windows com seus dados. Exemplo de valor — substitua os trechos entre `< >`:

```text
Server=127.0.0.1;Port=3306;Database=beloop_manut;User ID=<seu_usuario>;Password=<sua_senha>;
```

No Windows, pesquise **Editar variáveis de ambiente da conta** → **Novo**. Informe `BELOOP_MYSQL` como nome e a conexão como valor. Se seu usuário local não tiver senha, deixe `Password=;`. Feche e reabra o Visual Studio para ele receber a nova variável. Evite salvar senhas no código ou enviá-las ao GitHub.

## 4. Testar a conexão

Após instalar o pacote, crie a classe `ConexaoMySql.cs` no projeto:

```csharp
using MySqlConnector;

namespace Beloop_Manut.Dados;

public static class ConexaoMySql
{
    public static MySqlConnection Criar()
    {
        string? conexao = Environment.GetEnvironmentVariable("BELOOP_MYSQL");
        if (string.IsNullOrWhiteSpace(conexao))
            throw new InvalidOperationException("Configure a variável BELOOP_MYSQL e reabra o Visual Studio.");

        return new MySqlConnection(conexao);
    }
}
```

Para testar uma vez, execute o trecho abaixo em um evento de botão temporário `async`, como o `Click` de um botão de teste no Designer:

```csharp
try
{
    await using var conexao = Beloop_Manut.Dados.ConexaoMySql.Criar();
    await conexao.OpenAsync();
    await using var comando = new MySqlConnector.MySqlCommand("SELECT DATABASE()", conexao);
    string? banco = Convert.ToString(await comando.ExecuteScalarAsync());
    MessageBox.Show($"Conexão realizada com: {banco}");
}
catch (Exception ex)
{
    MessageBox.Show($"Não foi possível conectar: {ex.Message}");
}
```

Por exemplo, a assinatura do evento pode ser `private async void btnTestarConexao_Click(object sender, EventArgs e)`. Remova o botão de teste quando não for mais necessário.

## 5. Entender os dados

- `equipamentos` guarda identificação, nome, localização e situação base.
- `manutencoes` guarda tipo, problema, responsável, datas, situação e serviço realizado.
- `vw_equipamentos` apresenta `Em manutenção` quando houver manutenção aberta; caso contrário, apresenta a situação base. Consulte essa visão para mostrar a situação atual.
- Para concluir uma manutenção, atualize a situação, o serviço realizado e a data de conclusão; se necessário, atualize também `situacao_base` do equipamento na mesma transação. O banco impede duas manutenções abertas para o mesmo equipamento.

O esquema não cria contas ou senhas de usuários do aplicativo. Autenticação, gerenciamento de técnicos e permissões continuam pendentes.

## Problemas comuns

- **Unable to connect:** verifique se o MySQL está ligado, o servidor e a porta.
- **Access denied:** confira usuário, senha e permissões no banco.
- **Unknown database:** execute o script de criação no servidor correto.
- **BELOOP_MYSQL não configurada:** revise a variável e reinicie o Visual Studio.
