using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HanVez
{
    class Program
    {
        static void Main(string[] args)
        {
            Kotouc k1 = new Kotouc(1);
            Kotouc k2 = new Kotouc(2);
            Kotouc k3 = new Kotouc(3);
            Kotouc k4 = new Kotouc(4);
            Kotouc k5 = new Kotouc(5);
            Stack<Kotouc> tyc1 = new Stack<Kotouc>();
            Stack<Kotouc> tyc2 = new Stack<Kotouc>();
            Stack<Kotouc> tyc3 = new Stack<Kotouc>();
            Kotouc[] tycVykr1;
            Kotouc[] tycVykr2;
            Kotouc[] tycVykr3;
            tyc3.Push(k5);
            tyc2.Push(k4);
            tyc1.Push(k3);
            tyc3.Push(k2);
            tyc2.Push(k1);
            bool vyhra = false;
            Stack<Kotouc>[] tyce = new Stack<Kotouc>[3];
            tyce[0] = tyc1;
            tyce[1] = tyc2;
            tyce[2] = tyc3;

            while (!vyhra)
            {
                Console.Clear();
                vykresliHru();
                Console.WriteLine();
                Console.Write("Přesunout kotouč z věže: ");
                int zVeze = int.Parse(Console.ReadLine());
                while (zVeze > 3)
                {
                    Console.WriteLine("Neplatný sloupec");
                    Console.ReadKey();
                    Console.Clear();
                    vykresliHru();
                    Console.WriteLine();
                    Console.Write("Přesunout kotouč z věže: ");
                    zVeze = int.Parse(Console.ReadLine());
                }
                Console.Write("Přesunout kotouč na věž: ");
                int onTower = int.Parse(Console.ReadLine());
                while (onTower > 3)
                {
                    Console.WriteLine("Neplatný sloupec");
                    Console.ReadKey();
                    Console.Clear();
                    vykresliHru();
                    Console.WriteLine();
                    Console.WriteLine("Přesunout kotouč z věže: {0}", zVeze);
                    Console.Write("Přesunout kotouč na věže: ");
                    onTower = int.Parse(Console.ReadLine());
                }
                PresunKotouce(zVeze, onTower);
                Console.Clear();
                vykresliHru();
                KontrolaVyhry();

                

            }

            void PresunKotouce (int zVeze, int naVez)
            {

                if (tyce[zVeze - 1].Count == 0)
                {
                    Console.WriteLine("Nejsou zde žádné kotouče");
                    Console.ReadKey();
                }
                else if (tyce[zVeze - 1].Count != 0)
                {

                        Kotouc presun = tyce[zVeze - 1].Pop();
                        tyce[naVez - 1].Push(presun);
                    if (tyce[naVez - 1].Count > 1)
                    {
                        Kotouc vrchni = tyce[naVez - 1].Pop();
                        Kotouc spodni = tyce[naVez-1].Peek();
                        if (vrchni.Cislo > spodni.Cislo)
                        {
                            tyce[zVeze - 1].Push(vrchni);
                            Console.WriteLine("Spodní koutouč je menší, proto nelze kotouč umístit");
                            Console.ReadKey();
                        }
                        else
                            tyce[naVez - 1].Push(vrchni);

                    }


                          
                }
                
            }

            

            void vykresliHru()
            {
                Console.WriteLine("1" + "2".PadLeft(10) + "3".PadLeft(11));
                for (int i = 5; i > 0; i--)
                {
                    if (tyc1.Count >= i)
                    {
                        tycVykr1 = tyc1.ToArray();
                        Console.Write(tycVykr1[tyc1.Count - i].ToString().PadLeft(1));
                    }
                    if (tyc1.Count < i)
                        Console.Write("".PadLeft(10) );
                    if (tyc2.Count >= i)
                    {
                        tycVykr2 = tyc2.ToArray();
                        Console.Write(tycVykr2[tyc2.Count - i].ToString().PadLeft(11));
                    }
                    if (tyc2.Count < i)
                        Console.Write("".PadLeft(11) );
                    if (tyc3.Count >= i)
                    {
                        tycVykr3 = tyc3.ToArray();
                        Console.Write(tycVykr3[tyc3.Count - i].ToString().PadLeft(11));
                    }

                    Console.WriteLine();
                }

            }

            void KontrolaVyhry()
            {
                for (int p = 0; p < 3; p++)
                {
                    if (tyce[p].Count == 5)
                    {
                        Console.WriteLine("Vyhrál jsi!");
                        vyhra = true;
                        Console.ReadKey();
                    }
                }
            }













        }
    }
}