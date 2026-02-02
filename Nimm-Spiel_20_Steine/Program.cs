using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Nimm_Spiel_20_Steine
{
    internal class Program
    {
        static void Main()
        {
            int gesSteine = 20;
            Console.WriteLine("Es liegen " + gesSteine + " Steine auf dem Tisch!");
            Console.WriteLine(new String('o', gesSteine));

            Random rand=new Random();
            int amZug = rand.Next(2);

            Console.WriteLine(amZug == 0 ? "Computer fängt an!" : "Du fängst an!");
            Thread.Sleep(2000);

            while (gesSteine >0) 
            {
                if (amZug == 0)
                {
                    //Gewinnstrategie
                    int nehmen = (gesSteine - 1) % 4;
                    
                    if (nehmen == 0)
                    {
                        nehmen = new Random().Next(1, 4);
                    }

                    Console.WriteLine("Computer nimmt " + nehmen + " Steine.");
                    Thread.Sleep(2000);

                    gesSteine -= nehmen;

                    if (gesSteine <1)
                    {
                        Console.WriteLine("********Computer hat verloren!!!********");
                    }
                    else
                    {
                        Console.WriteLine("Auf dem Tisch bleiben " + gesSteine + " Steine");
                        Console.WriteLine(new String('o', gesSteine));
                        Thread.Sleep(2000);
                    }


                }
                else
                {
                    int spielerNimmt;
                    do
                    {
                        Console.WriteLine("Wieviele Steine nimmst du (1 bis 3)?");
                    }    while(!int.TryParse(Console.ReadLine(), out spielerNimmt)
                            || spielerNimmt < 1 || spielerNimmt >3);
                    
                    
                    gesSteine -= spielerNimmt;
                    if (gesSteine < 1)
                    {
                        Console.WriteLine("********Du hast verloren!!!********");
                    }
                    else
                    {
                        Console.WriteLine("Auf dem Tisch bleiben " + gesSteine + " Steine");
                        Console.WriteLine(new String('o', gesSteine));
                    }
                    
                }
                
                amZug = 1-amZug;
                 

                 
            }



        }
    }
}


