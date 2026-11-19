# Banco e login de desenvolvimento

1. Inicie o MySQL pelo Laragon e confira a porta configurada.
2. No terminal do Visual Studio, abra o cliente MySQL com sua conta administrativa. Para o usuário root com senha:

   ```powershell
   & "C:\laragon\bin\mysql\mysql-8.4.3-winx64\bin\mysql.exe" -u root -p
   ```

   Se sua conta local não tiver senha, retire `-p`.
3. No prompt `mysql>`, execute:

   ```sql
   SOURCE C:/Users/bgn/Documents/Codex/2026-11-18/a/Beloop-Manut/BancoDeDados/04_schema_completo.sql;
   USE beloop_manut;
   SHOW TABLES;
   SELECT id, nome, login, ativo FROM usuarios;
   ```

4. Abra `conexao.local.json` na pasta do projeto `Beloop-Manut/Beloop-Manut` e revise os dados do MySQL (servidor, porta, usuário e senha). Esse arquivo já existe neste computador e não precisa ser substituído. Ao compilar, o Visual Studio o copia automaticamente para a pasta de execução. Ele é ignorado pelo Git.
5. Execute o projeto. Para a conta criada pelo schema: usuário `admin` e senha `Beloop@123`.

Se `admin` já existir, o script não troca sua senha; ele preserva o usuário existente. O script também não recria tabelas existentes: se foram criadas com estrutura diferente, será necessária uma migração. A conta com senha conhecida destina-se apenas a desenvolvimento. As demais telas ainda não estão conectadas aos dados do banco.
