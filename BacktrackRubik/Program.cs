using Rubik;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BacktrackRubik
{
    class Program
    {
        static void Main(string[] args)
        {
            //Felületek példányosítása
            LapKeszito lk = new LapKeszito();
            LapKeszito.Kiiras(lk.feluletek);

            //Forgatások mátrix példányosítása
            Console.WriteLine("forgat:");
            Forgato forgatasok = new Forgato();
            Forgato.Kiiras(forgatasok.forgatasok);

            //Pálya példányosítása
            Console.WriteLine("palya:");
            PalyaKeszito palyakeszito = new PalyaKeszito();
            PalyaKeszito.Kiiras(palyakeszito.palya);

            //Megoldáshoz szükséges osztály példányosítása és a Backtrack futtatása
            Megoldas mo = new Megoldas(lk.feluletek, forgatasok.forgatasok, palyakeszito.palya);
            mo.Backtrack();
        }
    }
}
