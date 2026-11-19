# Beloop Manut

Aplicação desktop em C# e Windows Forms para acompanhar equipamentos e manutenções da oficina. O banco de dados previsto é MySQL.

## Como abrir

Abra `Beloop-Manut/Beloop-Manut.slnx` no Visual Studio com a carga de trabalho **Desenvolvimento para desktop com .NET** e o SDK .NET 8.

## Estrutura

- `Telas/Login`: formulário de entrada.
- `Telas/Principal`: janela principal e navegação.
- `Telas/VisaoGeral`, `Equipamentos`, `EquipamentoNovo`, `EquipamentoDetalhes`, `Manutencoes`, `ManutencaoNova`, `Acompanhar`, `Concluir`, `Historico` e `Relatorios`: controles de usuário separados, com seus arquivos Designer.
- `Recursos/Imagens`: imagens e ícones fornecidos no protótipo.

## Estado atual

O frontend está em desenvolvimento. As 11 telas possuem uma estrutura inicial, ainda sujeita a ajustes visuais, de responsividade e de usabilidade em relação ao Figma. As tabelas mostram dados fictícios; pesquisas, filtros, gravação, relatórios e exportação ainda não funcionam. O botão de login abre uma demonstração sem autenticação: não use esta versão com dados reais. O MySQL ainda não está conectado.

Protótipo: https://www.figma.com/design/rNRAnDEcJw1qC6yB2Isi4r/

## Integração em andamento

O cadastro e a consulta de equipamentos foram ligados ao MySQL, incluindo pesquisa e filtro por situação. A integração ainda precisa ser testada com o servidor acessível. O login depende da tabela `usuarios` e da configuração local. As demais telas ainda usam exemplos ou ações pendentes e não devem ser consideradas prontas para operação.
