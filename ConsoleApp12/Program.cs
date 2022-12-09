using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Net.Sockets;
using System.Xml;

namespace Program
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var playerOne = new GameAccount("Bender");
            var playerTwo = new GameAccount("Stepan");
            var g1 = Matchmaking.ReturningClass.MatchmakingG(playerOne, playerTwo);
            g1.Process();
            g1.Process();
            Console.WriteLine(playerOne.GetStats());
            Console.WriteLine(playerTwo.GetStats());


        }

        public class GameAccount
        {
            public string UserName { get; }
            public int GamesCount { get; }



            public int GameId
            {
                get
                {
                    int gameId = 1;
                    foreach (var t in allOperations)
                    {
                        gameId += t.GameId;
                    }

                    return gameId;
                }

            }

           




            public  void WinGame(string opponentName, Game game)
            {
                var winGame = new Operation( "Win", opponentName, 1);
                allOperations.Add(winGame);
            }
            public  void DrawGame(string opponentName, Game game)
            {
                var drawGame = new Operation( "Draw", opponentName, 1);
                allOperations.Add(drawGame);
            }

            public void LoseGame(string opponentName, Game game)
            {
               

                var loseGame = new Operation( "Lose", opponentName, 1);
                allOperations.Add(loseGame);
            }

            public string GetStats()
            {
                var rep = new System.Text.StringBuilder();
                int gameId = 0;
              
                rep.AppendLine("|Player|\t\t|Status|\t|OpponentName|\t|GameId|");
                foreach (var t in allOperations)
                {
                    
                    gameId += t.GameId;
                    rep.AppendLine(
                        $"|{UserName}|\t\t|{t.Status}|\t\t|{t.OpponentName}|\t\t|{gameId}|");
                }

                return rep.ToString();
            }

            public GameAccount(string name)
            {
                UserName = name;
                GamesCount = 0;

            }

            public List<Operation> allOperations = new List<Operation>();
        }





        public class Operation
        {
           
            public string Status { get; }
            public string OpponentName { get; }
            public int GameId { get; }

            public Operation( string status, string opponentName, int gameIndex)
            {
               
                Status = status;
                OpponentName = opponentName;
                GameId = gameIndex;
            }
        }

        public abstract class Game
        {
            public readonly GameAccount PlayerOne;
            public readonly GameAccount PlayerTwo;
          
            
            protected Game(GameAccount p1, GameAccount p2)
            {
                PlayerOne = p1;
                PlayerTwo = p2;
             
            }


            public abstract void Process();


        }

        public class Matchmaking : Game
        {
            public Matchmaking(GameAccount p1, GameAccount p2) : base(p1, p2)
            {
              

            }
            static string[] pos = new string[10] { "0", "1", "2","3","4","5","6","7","8","9" };

            public override void Process()
            {
                static void DrawBoard() 
                {
        Console.WriteLine("   {0}  |  {1}  |  {2}   ", pos[1], pos[2], pos[3]);
        Console.WriteLine("-------------------");
        Console.WriteLine("   {0}  |  {1}  |  {2}   ", pos[4], pos[5], pos[6]);
        Console.WriteLine("-------------------");
        Console.WriteLine("   {0}  |  {1}  |  {2}   ", pos[7], pos[8], pos[9]);
                }

    
        
        int choice = 0, turn = 1;
        bool winFlag = false, playing = true, correctInput = false;

        
        
       
        Console.WriteLine("{0} is X and {1} is 0." ,  PlayerTwo.UserName,PlayerOne.UserName);
       
        

        while (playing == true)
        {
            int c = 0;
            while (winFlag == false && c != 9) 
            {
                DrawBoard();
                Console.WriteLine("");
                if (turn == 1)
                {
                    Console.WriteLine("{0}'s (X) turn", PlayerOne.UserName);
                }
                if (turn == 2)
                {
                    Console.WriteLine("{0}'s (0) turn", PlayerTwo.UserName);
                }

                while (correctInput == false)
                {
                    Console.WriteLine("Which position would you like to take?");
                    choice = int.Parse(Console.ReadLine());
                    if (choice > 0 && choice < 10)
                    {
                        correctInput = true;
                    }
                    else
                    {
                        continue;
                    }
                }

                correctInput = false;
                
                if (turn == 1)
                {
                    if (pos[choice] == "0")
                    {
                        Console.WriteLine("You can't steal positions ! ");
                        Console.Write("Try again.");
                        Console.ReadLine();
                        Console.Clear();
                        continue;
                    }
                    else
                    {
                        pos[choice] = "X";
                        c++;
                    }
                }
                if (turn == 2)
                {
                    if (pos[choice] == "X") 
                    {
                        Console.WriteLine("You can't steal positions! ");
                        Console.Write("Try again.");
                        Console.ReadLine();
                        Console.Clear();
                        continue;
                    }
                    else
                    {
                        pos[choice] = "0";
                        c++;
                    }
                }
                Console.WriteLine(c);
                if (c == 9 )
                {
                    turn = 0;
                }
                winFlag = CheckWin();

                if (winFlag == false)
                {
                    if (turn == 1)
                    {
                        turn = 2;
                    }
                    else if (turn == 2)
                    {
                        turn = 1;
                    }
                    Console.Clear();
                }
            }

            Console.Clear();

            DrawBoard();

            for (int i = 1; i < 10; i++) 
            {
                pos[i] = i.ToString();
            }

           

           
                if(turn == 1)
                {
               
                    Console.WriteLine("{0} wins!" ,PlayerOne.UserName);
                    PlayerOne.WinGame(PlayerTwo.UserName,this);
                    PlayerTwo.LoseGame(PlayerOne.UserName,this);
                    break;
                    
                    
                }

                if (turn == 2)
                {
                    Console.WriteLine("{0} wins!" , PlayerTwo.UserName);
                    PlayerTwo.WinGame(PlayerOne.UserName,this);
                    PlayerOne.LoseGame(PlayerTwo.UserName,this);
                    break;
                    
                }

                if (turn == 0)
                {
                    Console.WriteLine("It's a draw!");
                    PlayerOne.DrawGame(PlayerTwo.UserName, this);
                    PlayerTwo.DrawGame(PlayerOne.UserName, this);
                    break;
                }
        }
            }

            static bool CheckWin() 
            {
                if (pos[1] == "O" && pos[2] == "O" && pos[3] == "O") 
                {
                    return true;
                }
                if (pos[4] == "O" && pos[5] == "O" && pos[6] == "O")
                {
                    return true;
                }
                 if(pos[7] == "O" && pos[8] == "O" && pos[9] == "O")
                {
                    return true;
                }

                 if(pos[1] == "O" && pos[5] == "O" && pos[9] == "O")
                {
                    return true;
                }
                 if(pos[7] == "O" && pos[5] == "O" && pos[3] == "O")
                {
                    return true;
                }

                 if(pos[1] == "O" && pos[4] == "O" && pos[7] == "O")
                {
                    return true;
                }
                 if(pos[2] == "O" && pos[5] == "O" && pos[8] == "O")
                {
                    return true;
                }
                if(pos[3] == "O" && pos[6] == "O" && pos[9] == "O")
                {
                    return true;
                }

                if (pos[1] == "X" && pos[2] == "X" && pos[3] == "X") 
                {
                    return true;
                }
                 if (pos[4] == "X" && pos[5] == "X" && pos[6] == "X")
                {
                    return true;
                }
                 if (pos[7] == "X" && pos[8] == "X" && pos[9] == "X")
                {
                    return true;
                }

                if (pos[1] == "X" && pos[5] == "X" && pos[9] == "X") 
                {
                    return true;
                }
                 if (pos[7] == "X" && pos[5] == "X" && pos[3] == "X")
                {
                    return true;
                }

                 if (pos[1] == "X" && pos[4] == "X" && pos[7] == "X") 
                {
                    return true;
                }
                 if (pos[2] == "X" && pos[5] == "X" && pos[8] == "X")
                {
                    return true;
                }
                 if (pos[3] == "X" && pos[6] == "X" && pos[9] == "X")
                {
                    return true;
                }
                
                 return false;
                
            }
            
            
            
            
            public class ReturningClass
            {
                public static Game MatchmakingG(GameAccount playerOne, GameAccount playerTwo)
                {
                    return new Matchmaking(playerOne, playerTwo);
                }
               
            }
        }
    }
}

