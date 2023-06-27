using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace _06._27_C_
{
    class AssetsStore
    {
        //데이터
        public string AssetsName;
        public int AssetsPrice;


        public int AssetsPriceUpdate(int UpPrice)
        {
            AssetsPrice += UpPrice;
            return (AssetsPrice);
        }

        //기능 메소드
        public void Hello()
        {
            Console.WriteLine("안녕하세요. 유니티 에셋스토어 입니다.");
        }
        public void AssetsRegister(string _AssetsName, int _AssetsPrice)
        {
            AssetsName = _AssetsName;
            AssetsPrice = _AssetsPrice;
        }

        public string GetAssetsName()
        {
            return AssetsName;
        }
        public int GetAssetsPrice()
        {
            return AssetsPrice;
        }

        public void PrintAsset()
        {
            Console.WriteLine("AssetName : " + AssetsName + " AssetsPrice : " + AssetsPrice);
        }
    }
    internal class _06
    {
        static void Main(string[] args)
        {
            AssetsStore asts = new AssetsStore();
            asts.AssetsName = "픽셀히어로";
            asts.AssetsPrice = 23000;

            asts.Hello();
            asts.AssetsRegister("픽셀히어로", 23000);
            asts.PrintAsset();

            string str = asts.GetAssetsName();
            Console.WriteLine(str);

            int a = asts.GetAssetsPrice();
            Console.WriteLine(a);

            int UpPrice = 10000;
            Console.WriteLine(asts.AssetsPriceUpdate(UpPrice));
        }
    }
}
