# Beloop Manut

Sistema desktop para cadastro de equipamentos e acompanhamento de manutenções, desenvolvido pela equipe **Beloop** como parte do **Projeto Integrador 2**. A proposta é centralizar os registros da oficina e facilitar a consulta ao histórico e à situação de cada equipamento.

## O problema

Quando as intervenções ficam em anotações separadas, é difícil identificar quando um equipamento passou por manutenção, qual foi o problema, quem realizou o atendimento e qual é sua situação atual.

## Funcionalidades previstas

- Cadastrar e consultar equipamentos.
- Registrar manutenções preventivas e corretivas e descrever o problema.
- Identificar o responsável técnico e registrar datas relevantes.
- Acompanhar a situação das manutenções e dos equipamentos.
- Consultar o histórico e visualizar informações gerais e relatórios.

A primeira versão é destinada à equipe da oficina interna, será utilizada no Windows e deverá manter os dados disponíveis para consultas posteriores. A situação do equipamento deve ser coerente com suas manutenções. O controle de estoque de peças não faz parte do escopo inicial.

## Tecnologias

- **C#** e **Windows Forms** para a aplicação desktop.
- **MySQL** para armazenamento dos dados.

## Como abrir

Abra `Beloop-Manut.slnx` no Visual Studio com a carga de trabalho **Desenvolvimento para desktop com .NET** e o SDK .NET 8. Para preparar o banco e o login, consulte `BancoDeDados/04_instrucoes_login.md`.

## Estrutura

- `src/BeloopManut`: projeto Windows Forms.

- `Telas/Login` e `Telas/Principal`: formulário de entrada e navegação.
- `Telas/VisaoGeral`, `Equipamentos`, `EquipamentoNovo`, `EquipamentoDetalhes`, `Manutencoes`, `ManutencaoNova`, `Acompanhar`, `Concluir`, `Historico` e `Relatorios`: controles de usuário e arquivos Designer.
- `Dados`: conexão, autenticação e acesso a equipamentos.
- `Recursos/Imagens`: imagens e ícones do protótipo.
- `BancoDeDados`: scripts SQL e instruções de configuração.

## Situação do projeto

O frontend está em desenvolvimento e as 11 telas possuem uma estrutura inicial que ainda precisa de ajustes visuais e de responsividade em relação ao Figma. O login e o cadastro e a consulta de equipamentos têm integração inicial com o MySQL, ainda pendente de validação em um servidor acessível. As demais telas ainda contêm exemplos ou ações pendentes; o sistema não está pronto para operação com dados reais.

[Protótipo no Figma](https://www.figma.com/design/rNRAnDEcJw1qC6yB2Isi4r/)
