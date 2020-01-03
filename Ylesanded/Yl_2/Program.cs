using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
/*
Lase kasutajal sisestada arve kuni tühi string vastuseks tuleb (ehk ENTER ilma midagi
kirjutamata). Arvuta nende arvude summa ning min ja max väärtused. Trüki saadud
tulemused ekraanile
 */
namespace Yl_2
{
    class Program
    {
        static void Main(string[] args)
        {
            while (true)
            {
                Console.Write("Sisesta suvaline number 1: ");
                string value_1 = Console.ReadLine();

                //Kasutaja peab sisestama esimese nr, et edasi minna muidu läheb while lausesse
                while (string.IsNullOrWhiteSpace(value_1))
                {
                    Console.Write("Sisesta suvaline number 1: ");
                    value_1 = Console.ReadLine();
                }

                Console.Write("Sisesta suvaline number 2: ");
                string value_2 = Console.ReadLine();

                //Kasutaja peab sisestama teise nr, et edasi minna muidu läheb while lausesse
                while (string.IsNullOrWhiteSpace(value_2))
                {
                    Console.Write("Sisesta suvaline number 2: ");
                    value_2 = Console.ReadLine();
                }

                int number_1;
                bool check_1 = int.TryParse(value_1, out number_1);
                //Muudab mitte numbrilised väärtused 0-iks
                int number_2;
                bool check_2 = int.TryParse(value_2, out number_2);

                Console.WriteLine("Numbrite summa on: " + (number_1 + number_2));
                Console.WriteLine("Min väärtus: " + Math.Min(number_1, number_2));
                Console.WriteLine("Max väärtus: " + Math.Max(number_1, number_2));

                Console.ReadLine();

            }
            
        }
    }
}
