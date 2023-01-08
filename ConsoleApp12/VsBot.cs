namespace Program;


    public class VsBot : Game
    {
        private static Operation _operation = new Operation();
        static string[] pos = new string[10] { "0", "1", "2", "3", "4", "5", "6", "7", "8", "9" };

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


            Console.WriteLine("{0} is X and {1} is 0.", PlayerTwo.UserName, PlayerOne.UserName);


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

                    if (turn == 1)
                    {
                        while (correctInput == false)
                        {
                            Random rnd = new Random();
                            choice =  rnd.Next(9);
                            if (choice > 0 && choice < 10)
                            {
                                correctInput = true;
                            }
                            else
                            {
                                continue;
                            }
                        }
                    }

                    if (turn == 2)
                    {
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
                    }
                    

                    correctInput = false;

                    if (turn == 1)
                    {
                        if (pos[choice] == "0")
                        {
                            Random rnd = new Random();
                            choice =  rnd.Next(9);
                            Console.Write("Try again.");
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
                    if (c == 9)
                    {
                        turn = 0;
                    }

                    winFlag = _operation.CheckWin(pos);

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


                if (turn == 1)
                {
                    Console.WriteLine("{0} wins!", PlayerOne.UserName);
                    PlayerOne.WinGame(PlayerTwo.UserName, this);
                    PlayerTwo.LoseGame(PlayerOne.UserName, this);
                    break;
                }

                if (turn == 2)
                {
                    Console.WriteLine("{0} wins!", PlayerTwo.UserName);
                    PlayerTwo.WinGame(PlayerOne.UserName, this);
                    PlayerOne.LoseGame(PlayerTwo.UserName, this);
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

        public VsBot(GameAccount p1, GameAccount p2) : base(p1, p2)
        {
        }
        public class ReturningClass
        {
            public static Game MatchmakingG(GameAccount playerOne, GameAccount playerTwo)
            {
                return new VsBot(playerOne, playerTwo);
            }
        }
    }