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
    class A
    {
        public virtual void m()
        {
            Console.WriteLine("A 클래스의 메소드");
        }
    }

    class B : A
    {
        public override void m()
        {
            Console.WriteLine("B 클래스의 메소드");
        }
    }

    internal class Base 
    {
        static void Main(string[] args)
        {
            A a = new A();      //부모 타입의 부모만큼 메모리 할당. 자식으로 못 가서 부모 M을 사용한다.
            a.m();

            B b = new B();      //B타입의 자식 객체 만들어서 오버라이드 된 함수를 호출
            b.m();

            A ab = new A();     //상황에 알맞게 변수를 만들어 주면서 위에 있는걸 취사선택해서 가져올 수 있음.
            ab.m();
        }
    }
}
