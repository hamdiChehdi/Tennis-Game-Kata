# Tennis-Game-Kata

## SPRINT1 : manage a tennis GAME within a set of a tennis match

### User Story 1 :
As a tennis referee
I want to manage the score of a game of a set of a tennis match between 2 players with simple Game rules
In order to display the current Game score of each player
 
Rules details:
·         The game starts with a score of 0 point for each player
·         Each time a player win a point, the Game score changes as follow:
          0 -> 15 -> 30 -> 40-> Win game

### User Story 2 :
As a tennis referee
I want to manage the specific of the rule DEUCE at the end of a Game
In order to display the current Game score of each player
 
Rules details:
·         If the 2 players reach the score 40, the DEUCE rule is activated
·         If the score is DEUCE , the player who  win the point take the ADVANTAGE
·         If the player who has the ADVANTAGE win the  point, he win the game
·         If the player who has the ADVANTAGE looses the point, the score is DEUCE


## SPRINT2 : manage a Tennis SET within a tennis match
### User Story 1 :
As a tennis referee
I want to manage the score of a set of a tennis match between 2 players
In order to display the current Game (SPRINT 1) & Set score of each player
 
Rules details:
· The set starts with a score of 0 Game for each player
· Each time a player win a Game (see SPRINT 1), the Set score changes as follow:
1 -> 2 -> 3 -> 4 -> 5 -> 6 (-> 7)
· If a player reach the Set score of 6 and the other player has a Set score of 4 or lower, the player win the Set
·         If a player wins a Game and reach the Set score of 6 and the other player has a Set score of 5, a new Game must be played and the first player who reach the score of 7 wins the match

### User Story 2 :
As a tennis referee
I want to manage the specific of the rule of Tie-Break at the end of the Set
In order to display the current Game, Set score & Tie-Break score of each player
 
Rules details:
·         If the 2 players reach the score of 6 Games , the Tie-Break rule is activated
·         Each time a player win a point, the score changes as follow:
1 -> 2 -> 3 -> 4 -> 5 -> 6 -> 7 (-> 8-> 9-> 10-> …)
·         The Tie-Break ends as soon as a player gets a least 7 points and 2 points more than his opponent
·         The player who wins the Tie-Break wins the Set and the match
