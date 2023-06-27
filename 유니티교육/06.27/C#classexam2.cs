using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _06._27_C_
{
    class Player
    {
        public string PlayerClass = "창병";
        public string PlayerName = "김씨";
        public int PlayerAttack = 20;
        public int PlayerDefence = 5;

        public void PlayerPrint()
        {
            Console.WriteLine(PlayerClass + " " + PlayerName + " " + PlayerAttack + " " + PlayerDefence);
        }
    }

    internal class _06
    {
        static void Main(string[] args)
        {
            Player player = new Player();
            {
                player.PlayerClass = "창병";
                player.PlayerName = "김씨";
                player.PlayerAttack = 20;
                player.PlayerDefence = 5;

                player.PlayerPrint();

            }
        }
    }
}
