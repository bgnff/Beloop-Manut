-- Dados fictícios para uma base de desenvolvimento já criada com 04_schema_completo.sql.
-- Este script adiciona registros; não altera nem apaga registros existentes.
-- Os códigos TESTE-... ficam reservados a estes exemplos.
SET NAMES utf8mb4;
USE beloop_manut;

INSERT INTO equipamentos (codigo, nome, localizacao, modelo, numero_serie, situacao_base)
SELECT 'TESTE-EQ-001', 'Compressor de ar', 'Oficina 01', 'CP-200', 'TESTE-04852', 'Disponível'
WHERE NOT EXISTS (SELECT 1 FROM equipamentos WHERE codigo = 'TESTE-EQ-001');
INSERT INTO equipamentos (codigo, nome, localizacao, modelo, numero_serie, situacao_base)
SELECT 'TESTE-EQ-002', 'Furadeira de bancada', 'Oficina 02', 'FB-100', 'TESTE-02841', 'Disponível'
WHERE NOT EXISTS (SELECT 1 FROM equipamentos WHERE codigo = 'TESTE-EQ-002');
INSERT INTO equipamentos (codigo, nome, localizacao, modelo, numero_serie, situacao_base)
SELECT 'TESTE-EQ-003', 'Serra elétrica', 'Oficina 01', 'SE-150', 'TESTE-03125', 'Indisponível'
WHERE NOT EXISTS (SELECT 1 FROM equipamentos WHERE codigo = 'TESTE-EQ-003');

-- Só insere manutenção aberta se o equipamento de teste não tiver outra aberta.
INSERT INTO manutencoes (equipamento_id, tipo, responsavel, problema, data_abertura, situacao)
SELECT e.id, 'Corretiva', 'Carlos Silva', '[TESTE] Vazamento de ar próximo à válvula de saída.', CURRENT_DATE(), 'Em andamento'
FROM equipamentos e
WHERE e.codigo = 'TESTE-EQ-001'
  AND NOT EXISTS (SELECT 1 FROM manutencoes m WHERE m.equipamento_id = e.id AND m.situacao IN ('Aguardando', 'Em andamento'))
  AND NOT EXISTS (SELECT 1 FROM manutencoes m WHERE m.equipamento_id = e.id AND m.problema = '[TESTE] Vazamento de ar próximo à válvula de saída.');

INSERT INTO manutencoes (equipamento_id, tipo, responsavel, problema, data_abertura, situacao, servico_realizado, data_conclusao)
SELECT e.id, 'Preventiva', 'Ana Souza', '[TESTE] Revisão periódica.', CURRENT_DATE(), 'Concluída', 'Inspeção e limpeza realizadas.', CURRENT_DATE()
FROM equipamentos e
WHERE e.codigo = 'TESTE-EQ-002'
  AND NOT EXISTS (SELECT 1 FROM manutencoes m WHERE m.equipamento_id = e.id AND m.problema = '[TESTE] Revisão periódica.');

SELECT codigo, nome, situacao FROM vw_equipamentos WHERE codigo LIKE 'TESTE-EQ-%' ORDER BY codigo;

SELECT DATABASE() AS banco,
       (SELECT COUNT(*) FROM equipamentos WHERE codigo LIKE 'TESTE-EQ-%') AS equipamentos_teste,
       (SELECT COUNT(*) FROM manutencoes m JOIN equipamentos e ON e.id = m.equipamento_id
        WHERE e.codigo LIKE 'TESTE-EQ-%') AS manutencoes_teste;
