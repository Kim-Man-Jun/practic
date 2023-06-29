using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Schema;

namespace _06._29_C_
{
    internal class _06
    {
        class Book
        {
            public string title;
            public string writer;

            public Book(string t, string w)
            {
                title = t;
                writer = w;
            }

            public Book(Book copy)
            {
                title = copy.title;
                writer = copy.writer;
            }

            public void print()
            {
                Console.WriteLine("제  목 : " + title);
                Console.WriteLine("저  자 : " + writer);
            }
        }

        static void Main(string[] args)
        {
            Book book1 = new Book("C# 그림책", "앤크");
            book1.print();
            Book book2 = new Book(book1);
            book2.title = "C 그림책";
            book2.print();
        }
    }

}
