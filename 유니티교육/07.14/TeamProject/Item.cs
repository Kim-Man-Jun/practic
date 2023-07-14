using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _07._14_TeamProject
{
    public class Item
    {
        public string name;
        public int price;
    }
    public class Potion : Item 
    {
        public int count;
    
    }

    public class PowerUp : Item
    {
        public bool isPurchased = false;
    }

    public class KuemGangBul : Item 
    {
        public bool isPurchased = false;
    }
}
