using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Schema;

namespace _07._05
{
    interface A
    {
        void say();             //추상메소드 abstract
        int prop                //추상속성
        {
            get;
            set;
        }
    }

    class X : A
    {
        public int b;
        public void say()       //인터페이스 함수 구현
        {
            Console.WriteLine("Hello");
        }
        public int prop         //인터페이스 속성 구현
        {
            get { return b; }   //속성으로 b 가져오기
            set { b = value; }  // 속성으로 b에 값 넣기
        }
    }

    internal class Base
    {
        static void Main(string[] args)
        {
            X x = new X();
            x.say();
            x.prop = 52;
            Console.WriteLine(x.prop);
        }
    }
}
