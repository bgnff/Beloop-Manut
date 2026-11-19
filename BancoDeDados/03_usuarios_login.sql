-- Execute no banco existente. Nenhum usuário é removido ou alterado.
USE beloop_manut;
CREATE TABLE IF NOT EXISTS usuarios (
    id INT NOT NULL AUTO_INCREMENT PRIMARY KEY,
    nome VARCHAR(120) NOT NULL,
    login VARCHAR(80) NOT NULL UNIQUE,
    senha_salt VARBINARY(16) NOT NULL,
    senha_hash VARBINARY(32) NOT NULL,
    senha_iteracoes INT NOT NULL,
    ativo BOOLEAN NOT NULL DEFAULT TRUE,
    criado_em DATETIME NOT NULL DEFAULT CURRENT_TIMESTAMP
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_unicode_ci;

-- Conta inicial para desenvolvimento: login admin, senha Beloop@123.
-- Para evitar sobrescrever uma conta existente, o INSERT só ocorre se o login não existir.
INSERT INTO usuarios (nome, login, senha_salt, senha_hash, senha_iteracoes, ativo)
SELECT 'Administrador', 'admin', UNHEX('b42f815abae2a6f02e197644e240d65d'), UNHEX('4070086585912c806c291142545f3ec5e3bc5ece9a34ea5887a472058d16560f'), 600000, 1
WHERE NOT EXISTS (SELECT 1 FROM usuarios WHERE login = 'admin');
