namespace Rubik
{
    using System;

    public class PalyaKeszito
    {
        /// <summary>
        /// Létrehozzuk a pályát és beállítjuk a kezdő értékeit.
        /// </summary>
        public PalyaKeszito()
        {
            Palya = new int[3, 3];

            for (int i = 0; i < Palya.GetLength(0); i++)
            {
                for (int j = 0; j < Palya.GetLength(1); j++)
                {
                    Palya[i, j] = -1;
                }
            }
        }

        /// <summary>
        /// A pályán lévő képek sorszámát tartalmazza
        /// </summary>
        public int[,] Palya { get; }

        /// <summary>
        /// Kiírjuk a pálya tartalmát a konzolra.
        /// </summary>
        /// <param name="palya">Pálya elemeit tartalmazza</param>
        public static void Kiiras(int[,] palya)
        {
            for (int y = 0; y < palya.GetLength(1); y++)
            {
                for (int x = 0; x < palya.GetLength(0); x++)
                {
                    Console.Write(palya[y, x]);
                    Console.Write(" ");
                }

                Console.WriteLine();
            }

            Console.WriteLine(Environment.NewLine);
        }
    }
}
