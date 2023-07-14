using System.Security.Cryptography.X509Certificates;

namespace TicTaeToe
{
    public class Play
    {
        static int Player = 1;
        public int input = 0;
        static bool inputCorrect = false;
        static int turns = 1;

        static char[,] playerField =
        {
            {'1','2','3'},
            {'4','5','6'},
            {'7','8','9'},
        };

        static char[,] playerFieldInitial =
        {
            {'1','2','3'},
            {'4','5','6'},
            {'7','8','9'},
        };

        public void SetField()
        {
            Console.Clear();

            Play play = new Play();

            gotoxy(0, 0);
            Console.WriteLine("■■■■■■■■■■■■■■■■");
            gotoxy(0, 1);
            Console.WriteLine("■        ■        ■        ■");
            gotoxy(0, 2);
            Console.WriteLine("■    {0}   ■    {1}   ■    {2}   ■", playerField[0, 0], playerField[0, 1], playerField[0, 2]);
            gotoxy(0, 3);
            Console.WriteLine("■        ■        ■        ■");
            gotoxy(0, 4);
            Console.WriteLine("■■■■■■■■■■■■■■■■");
            gotoxy(0, 5);
            Console.WriteLine("■        ■        ■        ■");
            gotoxy(0, 6);
            Console.WriteLine("■    {0}   ■    {1}   ■    {2}   ■", playerField[1, 0], playerField[1, 1], playerField[1, 2]);
            gotoxy(0, 7);
            Console.WriteLine("■        ■        ■        ■");
            gotoxy(0, 8);
            Console.WriteLine("■■■■■■■■■■■■■■■■");
            gotoxy(0, 9);
            Console.WriteLine("■        ■        ■        ■");
            gotoxy(0, 10);
            Console.WriteLine("■    {0}   ■    {1}   ■    {2}   ■", playerField[2, 0], playerField[2, 1], playerField[2, 2]);
            gotoxy(0, 11);
            Console.WriteLine("■        ■        ■        ■");
            gotoxy(0, 12);
            Console.WriteLine("■■■■■■■■■■■■■■■■");

            Console.WriteLine("Turns : {0}", turns);

            EnterOX(Player, play.input);
            PlayerWin();

        }

        public void gotoxy(int x, int y)
        {
            Console.SetCursorPosition(x, y);
        }

        static void EnterOX(int player, int input)
        {
            char playerSign = ' ';

            Play play = new Play();

            if (player == 1)
            {
                playerSign = 'X';
            }
            else if (player == 2)
            {
                playerSign = 'O';
            }

            switch (input)
            {
                case 1: playerField[0, 0] = playerSign; break;
                case 2: playerField[0, 1] = playerSign; break;
                case 3: playerField[0, 2] = playerSign; break;
                case 4: playerField[1, 0] = playerSign; break;
                case 5: playerField[1, 1] = playerSign; break;
                case 6: playerField[1, 2] = playerSign; break;
                case 7: playerField[2, 0] = playerSign; break;
                case 8: playerField[2, 1] = playerSign; break;
                case 9: playerField[2, 2] = playerSign; break;
            }

            if (turns == 10)
            {
                Console.WriteLine("\nDraw");
                Console.WriteLine("\nPlease press Any Key to Quit the Game");
                Console.ReadKey();
                Console.Clear();
                Environment.Exit(0);
            }

            do
            {
                Console.WriteLine("\nPlayer {0} : Choose your field!", player);

                try
                {
                    input = Convert.ToInt32(Console.ReadLine());
                }
                catch
                {
                    Console.WriteLine("Please enter a number");
                    Console.WriteLine("----------------------");
                }

                //별개의 if문
                if ((input == 1) && (playerField[0, 0] == '1'))
                {
                    playerField[0, 0] = playerSign;
                    turns++;
                    inputCorrect = true;
                    if (Player == 1)
                    {
                        Player = 2;
                    }
                    else if (Player == 2)
                    {
                        Player = 1;
                    }
                }
                else if ((input == 2) && (playerField[0, 1] == '2'))
                {
                    playerField[0, 1] = playerSign;
                    turns++;
                    inputCorrect = true;
                    if (Player == 1)
                    {
                        Player = 2;
                    }
                    else if (Player == 2)
                    {
                        Player = 1;
                    }
                }
                else if ((input == 3) && (playerField[0, 2] == '3'))
                {
                    playerField[0, 2] = playerSign;
                    turns++;
                    inputCorrect = true;
                    if (Player == 1)
                    {
                        Player = 2;
                    }
                    else if (Player == 2)
                    {
                        Player = 1;
                    }
                }
                else if ((input == 4) && (playerField[1, 0] == '4'))
                {
                    playerField[1, 0] = playerSign;
                    turns++;
                    inputCorrect = true;
                    if (Player == 1)
                    {
                        Player = 2;
                    }
                    else if (Player == 2)
                    {
                        Player = 1;
                    }
                }
                else if ((input == 5) && (playerField[1, 1] == '5'))
                {
                    playerField[1, 1] = playerSign;
                    turns++;
                    inputCorrect = true;
                    if (Player == 1)
                    {
                        Player = 2;
                    }
                    else if (Player == 2)
                    {
                        Player = 1;
                    }
                }
                else if ((input == 6) && (playerField[1, 2] == '6'))
                {
                    playerField[1, 2] = playerSign;
                    turns++;
                    inputCorrect = true;
                    if (Player == 1)
                    {
                        Player = 2;
                    }
                    else if (Player == 2)
                    {
                        Player = 1;
                    }
                }
                else if ((input == 7) && (playerField[2, 0] == '7'))
                {
                    playerField[2, 0] = playerSign;
                    turns++;
                    inputCorrect = true;
                    if (Player == 1)
                    {
                        Player = 2;
                    }
                    else if (Player == 2)
                    {
                        Player = 1;
                    }
                }
                else if ((input == 8) && (playerField[2, 1] == '8'))
                {
                    playerField[2, 1] = playerSign;
                    turns++;

                    if (Player == 1)
                    {
                        Player = 2;
                    }
                    else if (Player == 2)
                    {
                        Player = 1;
                    }
                }
                else if ((input == 9) && (playerField[2, 2] == '9'))
                {
                    playerField[2, 2] = playerSign;
                    turns++;
                    inputCorrect = true;

                    if (Player == 1)
                    {
                        Player = 2;
                    }
                    else if (Player == 2)
                    {
                        Player = 1;
                    }
                }

                else
                {
                    Console.WriteLine("\n 잘못된 숫자 입력. 다른 위치의 숫자를 입력.");
                    Console.WriteLine("---------------------------------------------");
                    inputCorrect = false;
                    if (turns == 10) { break; }
                }
                PlayerWin();

            } while (inputCorrect == false);

        }

        public static void ResetField()
        {
            Play play = new Play();
            playerField = playerFieldInitial;
            turns = 1;
            Player = 1;
            Console.Clear();
            play.SetField();
        }

        public static void PlayerWin()
        {
            char[] playerChars = { 'X', 'O' };
            foreach (char playerChar in playerChars)
            {
                if (((playerField[0, 0] == playerChar) && (playerField[0, 1] == playerChar) && (playerField[0, 2] == playerChar))
        || ((playerField[1, 0] == playerChar) && (playerField[1, 1] == playerChar) && (playerField[1, 2] == playerChar))
        || ((playerField[2, 0] == playerChar) && (playerField[2, 1] == playerChar) && (playerField[2, 2] == playerChar))
        || ((playerField[0, 0] == playerChar) && (playerField[1, 0] == playerChar) && (playerField[2, 0] == playerChar))
        || ((playerField[0, 1] == playerChar) && (playerField[1, 1] == playerChar) && (playerField[2, 1] == playerChar))
        || ((playerField[0, 2] == playerChar) && (playerField[1, 2] == playerChar) && (playerField[2, 2] == playerChar))
        || ((playerField[0, 0] == playerChar) && (playerField[1, 1] == playerChar) && (playerField[2, 2] == playerChar))
        || ((playerField[0, 2] == playerChar) && (playerField[1, 1] == playerChar) && (playerField[2, 0] == playerChar)))

                {
                    if (playerChar == 'X')
                    {
                        Console.WriteLine("\nPlayer 1 Win");
                        Console.WriteLine("\nPlease Press Any key to restart");
                        Console.ReadLine();
                        Console.Clear();
                        ResetField();
                    }
                    else
                    {
                        Console.WriteLine("\nPlayer 2 Win");
                        Console.WriteLine("\nPlease Press Any key to restart");
                        Console.ReadLine();
                        Console.Clear();
                        ResetField();
                    }
                    break;
                }
            }
        }
    }
}
//https://wg-cy.tistory.com/127 
