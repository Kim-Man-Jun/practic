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
    class Book
    {
        public string title;
        public string genre;

        public void printBook()
        {
            Console.WriteLine("제      목 : " + title);
            Console.WriteLine("분      야 : " + genre);
        }
    }

    class Novel : Book
    {
        public string writer;
        public void printNov()
        {
            printBook();
            Console.WriteLine("저      자 : " + writer);
        }
    }

    class Magazine : Book
    {
        public int day;
        public void printMag()
        {
            printBook();
            Console.WriteLine("발  매  일 : " + day + "일");
        }
    }
    internal class Bookshelf
    {
        static void Main(string[] args)
        {
            Novel nov = new Novel();
            nov.title = "미희의 비경 발견";
            nov.genre = "판타지";
            nov.writer = "앤크";

            Magazine mag = new Magazine();
            mag.title = "월간 C# 그림책";
            mag.genre = "컴퓨터";
            mag.day = 20;

            nov.printNov();
            Console.WriteLine();
            mag.printMag();
        }
    }
}
