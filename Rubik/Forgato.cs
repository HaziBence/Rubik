using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rubik
{
    public class Forgato
    {
        /*Ebben a tömbben tároljuk az adott felületek helyzetét
          -1 esetén nem használjuk a képet
          0 esetén a kép nincs elforgatva
          1 esetén a kép 90 fokkal jobbra el van forgatva
          2 esetén 180 fokkal van elforgatva jobbra
          3 esetén 270 fokkal van elforgatva jobbra
        */
        public int[] forgatasok { get; }

        //létrehozzuk a tömböt és megadjuk a kezdő értékeit
        public Forgato()
        {
            forgatasok = new int[24];

            for (int i = 0; i < forgatasok.Length; i++)
            {
                forgatasok[i] = -1;
            }
        }

        /// <summary>
        /// A megadott felületet forgatja egyel jobbra
        /// </summary>
        /// <param name="feluletek"></param>
        /// <param name="forgatasok"></param>
        /// <param name="FeluletSzam"></param>
        public static void Forgat(int[,] feluletek, int[] forgatasok, int FeluletSzam)
        {
            if (forgatasok[FeluletSzam] > 0)
            {
                //ha már 3szor megforgattuk és most is forgatunk rajta, emiatt visszakerül az alap állapotába
                if (forgatasok[FeluletSzam] == 3)
                {
                    forgatasok[FeluletSzam] = 0;
                }

                int csere1;
                int csere2;

                csere1 = feluletek[FeluletSzam, 6];
                csere2 = feluletek[FeluletSzam, 7];

                feluletek[FeluletSzam, 6] = feluletek[FeluletSzam, 4];
                feluletek[FeluletSzam, 7] = feluletek[FeluletSzam, 5];

                feluletek[FeluletSzam, 4] = feluletek[FeluletSzam, 2];
                feluletek[FeluletSzam, 5] = feluletek[FeluletSzam, 3];

                feluletek[FeluletSzam, 2] = feluletek[FeluletSzam, 0];
                feluletek[FeluletSzam, 3] = feluletek[FeluletSzam, 1];

                feluletek[FeluletSzam, 0] = csere1;
                feluletek[FeluletSzam, 1] = csere2; 
            }
        }


        /// <summary>
        /// Egy felületet forgatunk jobbra.
        /// </summary>
        /// <param name="felulet"></param>
        public static void ForgatEgyFelulet(int[] felulet)
        {

            int csere1;
            int csere2;

            csere1 = felulet[6];
            csere2 = felulet[7];

            felulet[6] = felulet[4];
            felulet[7] = felulet[5];

            felulet[4] = felulet[2];
            felulet[5] = felulet[3];

            felulet[2] = felulet[0];
            felulet[3] = felulet[1];

            felulet[0] = csere1;
            felulet[1] = csere2;
        }

        /// <summary>
        /// Kiírja a forgatások tömb értékeit a konzolra.
        /// </summary>
        /// <param name="forgatasok"></param>
        public static void Kiiras(int[] forgatasok)
        {
            for (int i = 0; i < forgatasok.Length; i++)
            {
                Console.Write(forgatasok[i]);
                Console.Write(" ");
            }
            Console.WriteLine(Environment.NewLine);
        }
    }
}
