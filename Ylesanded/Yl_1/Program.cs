using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

//Trükkida välja kõik kolmega jagunevad arvud vahemikus 1..100

namespace Yl_1
{
    class Program
    {
        static void Main(string[] args)
        {
            for (int i = 0; i <= 100; i++)
            {
                if (i % 3 == 0)
                {
                    Console.WriteLine(i + "\t");

                }
            }
            Console.ReadLine();
        }
    }
}
