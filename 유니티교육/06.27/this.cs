using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _06._27_C_
{
    class Scope
    {
        int zoom = 1;
        public void print()
        {
            int zoom = 2;
            Console.WriteLine(zoom + ", " + this.zoom);
        }

        public void a(int x)
        {
            Console.WriteLine("인수는 " + x);
        }
        public void b()
        {
            a(5);
        }
    }

    internal class _06
    {
        static void Main(string[] args)
        {
            Scope scope = new Scope();
            scope.print();
            scope.b();
        }
    }
}
