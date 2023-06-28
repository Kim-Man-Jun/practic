using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Schema;

namespace _06._28_C_
{
    class Cat
    {
        string name;
        string place;
        int age;

        public void setData(string n, string p, int a)
        {
            name = n;
            place = p;
            age = a;
        }

        public void print()     //오버로딩 시작
        {
            Console.WriteLine(place + " : " + name + " " + age + "세");
        }
        public void print(string p, int a)
        {
            place = p;
            Console.WriteLine(place + " : 고양이는 " + a + "마리 입니다.");
        }

        public void print(string varienty)
        {
            Console.WriteLine(place + " : " + name + " " + age + "세" + varienty);
        }

    }
    internal class _06
    {
        static void Main(string[] args)
        {
            Cat cat1 = new Cat();
            Cat cat2 = new Cat();
            Cat cat3 = new Cat();

            cat1.setData("로빈", "우리집", 10);
            cat2.setData("꼬마", "옆집", 14);
            cat1.print(" 잡종");
            cat2.print();
            cat3.print("뒷집", 0);


        }
    }
}
