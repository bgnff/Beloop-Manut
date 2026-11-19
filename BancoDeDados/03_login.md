# Login com MySQL

1. Inicie o MySQL e execute `03_usuarios_login.sql` no banco `beloop_manut`. Ele cria a tabela `usuarios` e uma conta de desenvolvimento (`admin`, senha `Beloop@123`). Se o login `admin` já existir, não é sobrescrito; use outra conta ou altere-a conscientemente. Não utilize essa senha conhecida para dados reais.
2. O projeto usa o pacote NuGet `MySqlConnector` 3.0.0; restaure os pacotes no Visual Studio.
3. Copie o arquivo `conexao.exemplo.json` para a pasta `bin/Debug/net8.0-windows` do projeto e renomeie a cópia para `conexao.local.json`. Edite o usuário e a senha do **MySQL** no arquivo. Ele é ignorado pelo Git. Para outra configuração de compilação, use a pasta correspondente ao executável.
4. Execute o programa pelo Visual Studio e entre com `admin` e `Beloop@123`.

A senha do aplicativo é armazenada como hash PBKDF2-SHA256 com salt, separada da senha do MySQL. O sistema ainda não possui cadastro de usuários, troca de senha, recuperação de acesso, perfis ou bloqueio por tentativas. As outras telas ainda utilizam dados fictícios.

