using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace Compare
{
    internal class Program
    {
        static void Main(string[] args)
        {
            /*
            int a = 10; int b = 20;
            Console.WriteLine("a = " + a + " b = " + b);

            Console.WriteLine("a < b : " + (a < b));
            Console.WriteLine("a > b : " + (a > b));
            Console.WriteLine("a == b : " + (a == b));
            Console.WriteLine("a = b : " + (a = b));
            

            int a = 10; int b = 20;
            bool c, d, e;

            c = a < b;
            d = a > b;
            e = a == b;

            Console.WriteLine("a = " + a + " b = " + b);    
            Console.WriteLine("a < b : " + c);    
            Console.WriteLine("a > b : " + d);    
            Console.WriteLine("a == b : " + e);    
            

            bool sel = true;
            int a = sel ? 0 : 1;
            

            string right = "정답", wrong = "오답";
            bool value;

            value = true;
            string answer = value ? right : wrong;

            Console.WriteLine(answer);

            value = false;
            answer = value ? right : wrong;
            Console.WriteLine(answer);
            int a = 10; int b = 20;
            bool k = (a >= 10) && (a < 50);
            Console.WriteLine(k);


            int a = 3, b = 4;
            bool x, y;

            x = (a < 0);
            y = (b > 0);
            Console.WriteLine((a == 3) && (b == 3));
            Console.WriteLine(x || y);
            

            //연산 우선순위
            Console.WriteLine(" 2 * 8 - 6 / 2 = " + (2 * 8 - 6 / 2));
            Console.WriteLine(" 2 * (8 - 6) / 2 = " + (2 * (8 - 6) / 2));
            Console.WriteLine(" 1 - 2 + 3 = " + (1 - 2 + 3));
            Console.WriteLine(" 1 - (2 + 3) = " + (1 - (2 + 3)));
            

            //형변환
            Console.WriteLine(" 3 / 2 = " + (3 / 2));
            Console.WriteLine(" 3.0 / 2.0 = " + (3.0 / 2.0));
            Console.WriteLine(" 3.0 / 2 = " + (3.0 / 2));
            Console.WriteLine(" 3 / 2.0 = " + (3 / 2.0));
            

            string Name, sAge;

            Console.WriteLine("이름을 입력하세요 : ");
            Name = Console.ReadLine();
            Console.WriteLine(Name);

            Console.Write("나이를 입력하세요 " ");
            sAge = Console.ReadLine;
            sAge = Convert.ToInt32(sAge);
            Console.WriteLine(sAge);

            

            int A;

            Console.WriteLine("숫자를 입력하세요 : ");
            A = int.Parse(Console.ReadLine());
            Console.WriteLine("숫자는 : " + a);


            //국어 영어 수학 점수 
            //합계 평균

            int kor;
            int eng;
            int maf;

            int total;
            float aver;

            Console.WriteLine("국어 점수 : ");
            kor = int.Parse(Console.ReadLine());

            Console.WriteLine("영어 점수 : ");
            eng = int.Parse(Console.ReadLine());

            Console.WriteLine("수학 점수 : ");
            maf = int.Parse(Console.ReadLine());

            total = kor + eng + maf;
            aver = (float)total / 3;

            Console.WriteLine("합계 : " + total);
            Console.WriteLine("{0:f2}", aver);
            

            Console.WriteLine("로딩중... 키를 입력하세요.");
            Console.ReadKey();  //키입력 받기
            Thread.Sleep(1000); //1000단위가 1초
            Console.Clear();    //콘솔화면 지우기
            Console.WriteLine("게임 시작");

            ┏━━━━━━━━━┓
            ┃      로딩중      ┃
            ┗━━━━━━━━━┛
            */

            Console.WriteLine("┏━━━━━━━━━┓");
            Thread.Sleep(1000);
            Console.WriteLine("┃  로딩중 ┃");
            Thread.Sleep(1000);
            Console.WriteLine("┗━━━━━━━━━┛");
            Thread.Sleep(1000);
            Console.Clear();
            Console.WriteLine("게임 시작");


        }
    }
}
