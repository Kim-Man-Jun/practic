using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace TicTaeToe
{
    public class Play
    {
        public int Player = 2;
        int input = 0;
        public bool inputCorrect = true;

        static char[,] playerField =
        {
            {'1','2','3'},
            {'4','5','6'},
            {'7','8','9'},
        };

        public void EnterOorX(int player, int input)
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
                    if (player == 'X')
                    {
                        Console.WriteLine("Player 1 Win");
                    }
                    else
                    {
                        Console.WriteLine("Player 2 Win");
                    }
                    break;
                }
            }

            char playerSign = ' ';

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
                }

                if ((input == 1) && (playerField[0, 0] == '1'))
                {
                    inputCorrect = true;
                }
                else if ((input == 2) && (playerField[0, 1] == '2'))
                {
                    inputCorrect = true;
                }
                else if ((input == 3) && (playerField[0, 2] == '3'))
                {
                    inputCorrect = true;
                }
                else if ((input == 4) && (playerField[1, 0] == '4'))
                {
                    inputCorrect = true;
                }
                else if ((input == 5) && (playerField[1, 1] == '5'))
                {
                    inputCorrect = true;
                }
                else if ((input == 6) && (playerField[1, 2] == '6'))
                {
                    inputCorrect = true;
                }
                else if ((input == 7) && (playerField[2, 0] == '7'))
                {
                    inputCorrect = true;
                }
                else if ((input == 8) && (playerField[2, 1] == '8'))
                {
                    inputCorrect = true;
                }
                else if ((input == 9) && (playerField[2, 2] == '9'))
                {
                    inputCorrect = true;
                }
                else
                {
                    Console.WriteLine("\n 잘못된 숫자 입력. 다른 위치의 숫자를 입력하세요.");
                    inputCorrect = false;
                }
            } while (!inputCorrect);
        }
    }
}

//https://wg-cy.tistory.com/127 
