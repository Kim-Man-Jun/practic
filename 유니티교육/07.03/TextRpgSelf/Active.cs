using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Schema;

namespace _06._30_RPG_TEST
{
    internal class Program
    {
        static void Main(string[] args)
        {
            MainGame mainGame = new MainGame();
            mainGame.Initialize();
            mainGame.Progress();
        }
    }
}
