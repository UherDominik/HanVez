using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HanVez
{
    internal class Kotouc
    {
        public int Cislo { get; private set; }
        public Kotouc(int cislo)
        {
            Cislo = cislo;
        }
        public override string ToString()
        {
            string kostka = "██";
            string disk = "";
            for (int i = 0; i < Cislo; i++)
            {
                disk = disk + kostka;
            }
            int mezer = 10 - (Cislo * 2);
            for (int u =0; u< (mezer / 2); u++)
            {
                disk = " " + disk + " ";
            }
            return disk;
        }
    }
}
