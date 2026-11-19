-- Schema completo inicial do Beloop Manut. Não exclui dados existentes.
-- Beloop Manut: estrutura inicial para MySQL 8.0.16 ou superior.
-- Não apaga dados existentes. CREATE TABLE IF NOT EXISTS não atualiza tabelas antigas.
CREATE DATABASE IF NOT EXISTS beloop_manut
  CHARACTER SET utf8mb4 COLLATE utf8mb4_unicode_ci;

USE beloop_manut;

CREATE TABLE IF NOT EXISTS equipamentos (
    id INT UNSIGNED AUTO_INCREMENT PRIMARY KEY,
    codigo VARCHAR(30) NOT NULL UNIQUE,
    nome VARCHAR(120) NOT NULL,
    localizacao VARCHAR(120) NOT NULL,
    modelo VARCHAR(120) NULL,
    numero_serie VARCHAR(120) NULL,
    -- Estado quando não há manutenção aberta.
    situacao_base ENUM('Disponível', 'Indisponível') NOT NULL DEFAULT 'Disponível',
    criado_em DATETIME NOT NULL DEFAULT CURRENT_TIMESTAMP
) ENGINE=InnoDB;

CREATE TABLE IF NOT EXISTS manutencoes (
    id INT UNSIGNED AUTO_INCREMENT PRIMARY KEY,
    equipamento_id INT UNSIGNED NOT NULL,
    tipo ENUM('Preventiva', 'Corretiva') NOT NULL,
    responsavel VARCHAR(120) NOT NULL,
    problema TEXT NOT NULL,
    data_abertura DATE NOT NULL,
    situacao ENUM('Aguardando', 'Em andamento', 'Concluída') NOT NULL DEFAULT 'Aguardando',
    servico_realizado TEXT NULL,
    data_conclusao DATE NULL,
    -- Coluna gerada: impede duas manutenções abertas para um mesmo equipamento.
    equipamento_em_aberto INT UNSIGNED GENERATED ALWAYS AS
      (CASE WHEN situacao IN ('Aguardando', 'Em andamento') THEN equipamento_id ELSE NULL END) STORED,
    CONSTRAINT fk_manutencao_equipamento FOREIGN KEY (equipamento_id) REFERENCES equipamentos(id),
    CONSTRAINT uq_manutencao_aberta UNIQUE (equipamento_em_aberto),
    CONSTRAINT ck_datas_manutencao CHECK (data_conclusao IS NULL OR data_conclusao >= data_abertura),
    CONSTRAINT ck_conclusao_manutencao CHECK (
      (situacao = 'Concluída' AND data_conclusao IS NOT NULL AND servico_realizado IS NOT NULL AND CHAR_LENGTH(TRIM(servico_realizado)) > 0)
      OR (situacao <> 'Concluída' AND data_conclusao IS NULL)
    )
) ENGINE=InnoDB;

-- A situação exibida é calculada: manutenção aberta sempre torna o equipamento indisponível para uso.
CREATE OR REPLACE VIEW vw_equipamentos AS
SELECT e.id, e.codigo, e.nome, e.localizacao, e.modelo, e.numero_serie,
       e.situacao_base,
       CASE WHEN EXISTS (
           SELECT 1 FROM manutencoes m
           WHERE m.equipamento_id = e.id AND m.situacao IN ('Aguardando', 'Em andamento')
       ) THEN 'Em manutenção' ELSE e.situacao_base END AS situacao,
       e.criado_em
FROM equipamentos e;


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
