namespace BacktrackRubik
{
    using System;
    using Rubik;

    /// <summary>
    /// Konzolos osztály, amit debuggolás szempontjából készítettem
    /// </summary>
    internal class Program
    {
        /// <summary>
        /// Main metódus, ebben példányosítom a feladathoz szükséges osztályokat.
        /// string[] args-ot nem használtam fel az egész solution alatt.
        /// </summary>
        /// <param name="args">Bejövő paraméterek</param>
        public static void Main(string[] args)
        {
            // Felületek példányosítása
            LapKeszito lk = new LapKeszito();
            LapKeszito.Kiiras(lk.Feluletek);

            // Forgatások mátrix példányosítása
            Console.WriteLine("forgat:");
            Forgato forgatasok = new Forgato();
            Forgato.Kiiras(forgatasok.Forgatasok);

            // Pálya példányosítása
            Console.WriteLine("palya:");
            PalyaKeszito palyakeszito = new PalyaKeszito();
            PalyaKeszito.Kiiras(palyakeszito.Palya);

            // Megoldáshoz szükséges osztály példányosítása és a Backtrack futtatása
            Megoldas mo = new Megoldas(lk.Feluletek, forgatasok.Forgatasok, palyakeszito.Palya);
            mo.Backtrack();
        }
    }
}
