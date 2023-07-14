using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Diagnostics;
using System.Linq;
using System.Reflection;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using TeamProject;

namespace _07._14_TeamProject
{
    public class Shop
    {

        PlayerInfo m_player = new PlayerInfo();
        PlayerSelect Player = null;
  
        PowerUp powerUp = new PowerUp();
        Potion potion = new Potion();
        KuemGangBul kGB = new KuemGangBul();
        public void SetPlayer(ref PlayerSelect mPlayer)
        { Player = mPlayer;}

        Player playerCheck = new Player();

        public void Progress() 
        {
            int input = 0;

            while(true) 
            {
                Console.Clear();

                ItemMenu();
               
                input = int.Parse(Console.ReadLine());

                if(input == 1)
                {
                    BuyPotion();
                }
                if (input == 2)
                {
                    BuyPowerUp();
                }
                if (input == 3)
                {
                    BuyKuem();
                }
                if (input == 4)
                {
                    break;
                }
            }
        }
        
        public void BuyPotion()
        {
            
            potion.price = 100;
       
            if (Money.Instance().GetMoney() >= potion.price)
            {
                Money.Instance().SubMoney(potion.price);
                GameManager.Instance().GetInfoPlayer().PotionCT += 1;
            }
        }
        public void BuyPowerUp()
        {

            powerUp.price = 1000;
            if (powerUp.isPurchased == false) { 
                if (Money.Instance().GetMoney() >= powerUp.price)
                {
                    Money.Instance().SubMoney(powerUp.price);
                    GameManager.Instance().GetInfoPlayer().PlayerATK += 2;
                    powerUp.isPurchased = true;
                }
            }
        }

        public void BuyKuem()
        {

            kGB.price = 1000;
            if (kGB.isPurchased == false)
            {
                if (Money.Instance().GetMoney() >= kGB.price)
                {
                    Money.Instance().SubMoney(kGB.price);
                    GameManager.Instance().GetInfoPlayer().PlayerHP += 3;
                    GameManager.Instance().GetInfoPlayer().CurPlayerHP += 3;
                    kGB.isPurchased = true;
                }
            }
        }

        public void ItemMenu()
        {
            PlayerInfo m_player = new PlayerInfo();
          
            Console.WriteLine("아이템 목록"+ "    \t\t\t│");
            Console.WriteLine("1.포션 \t가격 : 100\t\t│");
            Console.WriteLine("※설명 : 체력을 1 회복시켜준다\t│");
            Console.WriteLine("       :F키를 눌러 사용하세요\t│");
            Console.WriteLine("2.파워업 \t가격 : 1000\t│");
            Console.WriteLine("※설명 : 공격력을 2 증가시킨다\t│");
            Console.WriteLine("3.금강불괴 \t가격 : 10000\t│");
            Console.WriteLine("※설명 : 체력을 3 증가시킨다\t│");
            Console.WriteLine("4. 나가기\t\t\t│");
            Console.WriteLine("────────────────────────────────┘");
            Console.WriteLine("인벤토리");
            Console.WriteLine("소지금: " + Money.Instance().GetMoney()); //
            Console.WriteLine("포션" + GameManager.Instance().GetInfoPlayer().PotionCT + "개");

            if (powerUp.isPurchased == true)
            {
                Console.WriteLine("파워업 구매함");
            }else
                Console.WriteLine("파워업");
            if (kGB.isPurchased == true) { 
            Console.WriteLine("금강불괴 구매함");
            }else
                Console.WriteLine("금강불괴");

            if (playerCheck.shopCheck == true)
            {
                Console.WriteLine("들어옴");
            }
        }

        public Shop() { }
        ~Shop() { }
    }
}
