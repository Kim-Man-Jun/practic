using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Schema;
using F = Fishing;

namespace Fishing
{
    class Fish
    {
        int num;
        string name;
        public Fish(string m, int n)
        {
            name = m;
            num = n;
        }
        public void print()
        {
            Console.WriteLine(name + " 낚은 수 " + num + " 마리");
        }
    }
    internal class FishingSample
    {
        static void Main(string[] args)
        {
            F.Fish iwashi = new F.Fish("정어리", 12);
            F.Fish hugu = new F.Fish("복어", 5);
            iwashi.print();
            hugu.print();
        }
    }
}
