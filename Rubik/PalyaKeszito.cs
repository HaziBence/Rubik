using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rubik
{
    public class PalyaKeszito
    {
        /// <summary>
        /// A pályán lévő képek sorszámát tartalmazza
        /// </summary>
        public int[,] palya { get; }

        /// <summary>
        /// Létrehozzuk a pályát és beállítjuk a kezdő értékeit.
        /// </summary>
        public PalyaKeszito()
        {
            palya = new int[3, 3];

            for (int i = 0; i < palya.GetLength(0); i++)
            {
                for (int j = 0; j < palya.GetLength(1); j++)
                {
                    palya[i, j] = -1;
                }
            }
        }


        /// <summary>
        /// Kiírjuk a pálya tartalmát a konzolra.
        /// </summary>
        /// <param name="palya"></param>
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
