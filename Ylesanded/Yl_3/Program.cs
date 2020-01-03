using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/*
 Loome pisikese mängu, kus kas vastane või arvuti paneb esmalt kirja numbri vahemikus
1..50 ja seejärel püüame pakutud arvu ära arvata. Vastusena igale pakkumisele peame
ütlema, kas tegu on pakutud arvuga, on see väiksem kui pakutu või suurem kui pakutu. Kui
tühi string pannakse, katkestatakse mäng. Lõpuks teavitatakse mitu katset on tehtud ja kas
õige tulemus leiti või mitte
 */

namespace Yl_3
{
    class Program
    {
        static void Main(string[] args)
        {
            int counter = 0;
            bool correct = false;
            
            Random rand = new Random();
            int randomInt = rand.Next(1, 50);
            //Console.Write(randomInt);
            Console.Write("Mängu lõpetamiseks vajutage lihtsalt ENTER ilma midagi kirjutamata.\nPalun sisesta number vahemikus 1-50: ");
            while (true)
            {
                
                string enteredValue = Console.ReadLine();
                
                if(string.IsNullOrWhiteSpace(enteredValue))
                {
                    break;
                }
                
                counter += 1;
                int number = Convert.ToInt32(enteredValue);

                if (number == randomInt)
                {
                    correct = true;
                }
                else if (number < randomInt)
                {
                    Console.WriteLine("Sisestatud arv on liiga väike. Proovi uuesti number kirjutada.");
                }
                else
                {
                    Console.WriteLine("Sisestatud arv on liiga suur. Proovi uuesti number kirjutada.");
                }

                if (correct)
                {
                    Console.Write($"Sa arvasid õige numbri ära: {randomInt}. Katsete arv: {counter}.");
                    Console.Read();
                }
            }
        }
    }
}
