# 18_Ghosts

## Autor:

**Tiago Berlim** - a22006891

## Lista de tarefas
  Tudo neste projeto foi feito por mim usando as referencias referidas em
baixo.
  
## Arquitetura da solução:

<https://github.com/TiagoBerlim-22006891/18_Ghosts>

### Descrição da solução:

Comecei por tentar perceber o jogo de uma forma geral lendo as regras e criando 
uma versão do mesmo em papel. Com um melhor entendimento pela maneira de como o 
jogo funciona comecei por criar um meno para o jogo usando um site de conversão 
de texo para ascii art para obter a "imagem" inical que diz "18 Ghosts".

Após o menu ter sido criado passei para a class `Game` e logo de seguida a struct 
`Tile` que me permitiria criar o tabuleiro de jogo, ao mesmo tempo que isto foi 
realizdo criei tambem dois enums de suporte `TileOrientation` e `TileColor` após 
isto foi criada a class `Ghost` para ser responsavel por guardar todas as 
informações necessárias sobre cada fantasma.

Após isto houve certos porblemas com o render de characteres unicode que mais tarde 
descubri que éra um erro basico por minha parte. Criei então a class `Player` de 
maneira a guardar todas as informações sobre cada jogador, criando tambem um enum 
de suporte para a class chamado de `PlayerType` desta forma o jogador pode ser 
classificado como jogador A ou B.

Depois de ter estás classes criada passei para o jogo, criando uma forma de 
colocação automática dos fantasmas no tabuleiro isto é feito através do metodo 
`PlaceGhosts()`. Com os fantasmas já no tabuleiro verificou-se que a leitura do 
jogo era terrivel deste modo foram mudadas as sprites dos fantasmas. Logo após 
isto foram criados os metodos que permitem o jogador mover os fantasmas; 
`MoveGhost()` e `GhostFight()`.

Foi então feita a implementação dos metodos `CheckPortalRotation()` e 
`GhostTryEscape()` para os fantasmas poderem escapar do tabuleiro e o jogo poder 
ter um fim.

Com o jogo a poder ser terminado decidi começar a trabalhar no funcionamento da 
dungeon criando varios metodos (`FreeGhostFromDungeon()`, `CheckFreeableGhost()`) 
que permitem ao jogador remover fantasmas da dungeon e colocalos novamente em jogo 
com o metodo `TryPlacing()`.

Após o jogo estar terminado verifiquei que o aspeto ficou um bocado para trás e 
trabalhei mais na class `Renderer` para melhorar a leitura do jogo, criando um 
"desenho" para o tabuleiro com a dungeon incluida, uma legenda de ajuda e as 
stats do jogador actual.

Ao finalizar o jogo fiz umas sesões de playtest em que notei a existencia de 
alguns bugs, corrigi os mesmo de adicionei um polish final para mostrar no ecrã 
todos os fantasmas que se encontrão presos na dungeon.


### Diagrama UML:

Este diagrama mostra a estrutura de classes encontrada no programa como também
a relação entre elas.

![UMLDiagram](https://raw.githubusercontent.com/TiagoBerlim-22006891/18_Ghosts/main/UML.png)

## Referencias

* Grande parte das duvidas obtidas durante a realização do projeto foram rezolvidas
atraves de posts antigos no site: <https://stackoverflow.com/>

* Conversão de texto para ascii art: <https://patorjk.com/software/taag/>

* Characters unicode usados no projeto: <https://unicode-table.com/en/>

* Conversa de dicas de alguns colegas em partes mais complicadas do codigo.