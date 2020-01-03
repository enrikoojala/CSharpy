using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
/*
Trips-traps-trull konsoolil. Esmalt trükitakse välja mänguväli (3 rida ja 3 veergu) ja siis
palutakse sisestada esimese või teise mängija (kuvatakse kumma kord parasjagu on) poolt
komaga eraldatud koordinaadid (1,3), millisele positsioonile oma märk kirjutada. Peab
kontrollima, et sisestatud on korrektne ja peale seda uuesti välja trükkima
 */
namespace Yl_4
{
    class Program
    {

        static string[] board = { " ", " ", " ",
                                  " ", " ", " ",
                                  " ", " ", " " };
        //Player 1 on X ja Player 2 on O
        static int player = 1;

        static void Main(string[] args)
        {
            Console.WriteLine("Tere, tulemast Trips-traps-trull mängu!");
            PrintBoard();
            Play();
        }

        static void Play()
        {
            Console.WriteLine("Sisesta rida ja veerg kujul RIDA,VEERG 3,2.");
            Console.WriteLine($"Mängija {player} kord.");
            char[] delim = { ',' };
            string[] positions = Console.ReadLine().Split(delim); // --> "1, 1" -> ["1", "2"]

            //Kui string on tühi (ENTER) või rohkem kui 3, siis läheb konsool kinni
            if (
                (positions[0].Length - 1 < 0 || positions[0].Length - 1 > 3)
                ||
                (positions[1].Length - 1 < 0 || positions[1].Length - 1 > 3))
            {
                System.Environment.Exit(0);
            }

            //Tekib error kui midagi muud kirjutada kui 1,1 - 3,3 vahemikus.
            int x = Int32.Parse(positions[0]);
            int y = Int32.Parse(positions[1]);

            if (!(ValidateInput(x) && ValidateInput(y)))
            {
                Play();
            }

            int index = GetIndex(x, y);

            if (player == 1 && IsSpotOpen(index))
            {
                board[index] = "X";
            }
            else if (player == 2 && IsSpotOpen(index))
            {
                board[index] = "O";
            }
            else
            {
                Play();
            }

            if (CheckForWinner())
            {
                PrintBoard();
                Console.WriteLine($"Võitis mängija {player}!");
                Console.ReadLine();
            }
            else
            {
                CheckDraw();
            }
            PrintBoard();

            //Vahetab mängijat
            if (player == 1)
            {
                player = 2;
            }
            else
            {
                player = 1;
            }

            Play();
        }

        static int GetIndex(int x, int y)
        {
            //Tagastab arvu board[0-8], et pärast kontrollimisel seda kasutada
            return (x - 1) + (y - 1) * 3;
        }

        //Mängulaua joonistamine
        static void PrintBoard()
        {
            Console.WriteLine(" {0} | {1} | {2} ", board[0], board[1], board[2]);
            Console.WriteLine("-----------");
            Console.WriteLine(" {0} | {1} | {2} ", board[3], board[4], board[5]);
            Console.WriteLine("-----------");
            Console.WriteLine(" {0} | {1} | {2} ", board[6], board[7], board[8]);
        }

        static bool ValidateInput(int z)
        {
            //Kasutaja sisestatu valideerimine, valideerib 1-3.
            if (z > 0 && z <= 3)
            {
                return true;
            }
            else
            {
                Console.WriteLine("Sisesta õiged koordinaadid, palun proovi uuesti.");
                return false;
            }
        }

        static bool IsSpotOpen(int i)
        {
            if (board[i] == "X" || board[i] == "O")
            {
                Console.WriteLine("See koht on juba võetud, proovi uuesti.");
                return false;
            }
            else
            {
                return true;
            }

        }

        static bool CheckForWinner()
        {
            //Rea, tulba ja diagonaali kontroll
            if (
                (board[0] == board[1] && board[1] == board[2] && board[2] != " ") ||
                (board[3] == board[4] && board[4] == board[5] && board[5] != " ") ||
                (board[6] == board[7] && board[7] == board[8] && board[8] != " ") ||
                (board[0] == board[4] && board[4] == board[8] && board[8] != " ") ||
                (board[2] == board[4] && board[4] == board[6] && board[6] != " ") ||
                (board[0] == board[3] && board[3] == board[6] && board[6] != " ") ||
                (board[1] == board[4] && board[4] == board[7] && board[7] != " ") ||
                (board[2] == board[5] && board[5] == board[8] && board[8] != " ")
                )
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        static bool CheckDraw()
        {
            //Kui ei saa rida, tulpa ega diagonaali, siis tuleb viik. 
            if ((board[0] != " " && CheckForWinner() == false) &&
                (board[1] != " " && CheckForWinner() == false) &&
                (board[2] != " " && CheckForWinner() == false) &&
                (board[3] != " " && CheckForWinner() == false) &&
                (board[4] != " " && CheckForWinner() == false) &&
                (board[5] != " " && CheckForWinner() == false) &&
                (board[6] != " " && CheckForWinner() == false) &&
                (board[7] != " " && CheckForWinner() == false) &&
                (board[8] != " " && CheckForWinner() == false))
            {
                Console.WriteLine("Viik");
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}