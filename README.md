# 1º Projeto de Linguagens de Programação II

## Autoria

### Nome dos Autores

Nelson Salvador 21904295 | Vasco Duarte 21905658

### Informação de trabalho

#### Nelson Salvador

- Level1.cs
- Level2.cs
- Player.cs
- Metodo SwitchSprite no CoreGameEngine em ConsoleSprite.cs
- Relatório

#### Vasco Duarte

- Menu.cs
- Help.cs
- Indicator.cs
- CoinConfirmation.cs
- BoxConfirmation.cs
- Score.cs
- Time.cs
- Title.cs
- ReturnMenu.cs
- Diagrama UML
- Fluxograma

### [Link GitHub](https://github.com/Vascord/LP2_2project)

## Arquitetura da Solução

### Descrição da Solução

Foi utilizado o CoreGameEngin do professor para a realização do nosso projeto,
este _engin_ tem um _gameloop_ que têm a _thread_ principal do jogo executada
pelo _gameloop_ e um _thread_ para _inputs_ do jogador. É utilizado o
_Update Method_, temos no nosso jogo uma coleção de objetos que processam um
comportamento por frame e implementamos o component pattern.

O nosso jogo tem o menu principal, que o `Program` chama. `Menu` que a partir
dele é possível jogar o nível 1 ou 2 criadas pelas respectivas classes `Level1`
e `Level2`, também é possível chamar o help, `Help` que contém as instruções
do jogo, ou sair do jogo. Isto é possível com o `Indicator`, que permite
selecionar essas opções. O `ReturnMenu` é uma classe mais simples idêntica
mas para o `Help`.

A classe `Score` contém o score do jogador e a classe `Player` controla as
interações e o movimento do jogador em cada nível. Os `BoxConfirmation` e
`CoinConfirmation` são iniciados para todos os blocos e moedas no níveis e
servem para confirmar se uma moeda foi apanhada ou se um bloco foi usado. O
`Time` também é iniciado a cada nível e se chega a 0, então o jogador volta
ao menu.

### UML

![Diagrama de classes](UMLProject2.png)

### Fluxograma

![Fluxograma](Flowchart.png)

## Referências

 Utilizamos a API do C# muito raramente para tirarmos umas pequenas dúvidas, de
 resto não usamos mais nada para código.
 A Sprite do jogador foi é uma sprite da net de autor desconhecido.
 Tambem discutimos com o Francisco Pires sobre como meter colições. Mas au
 final, depois da conversa, optamos por uma otra maneira de fazer as colições.
