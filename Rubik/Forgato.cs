namespace Rubik
{
    using System;

    /// <summary>
    /// Ebben az osztályban hozzuk létre a forgatások tömböt amiben egy felületnek a státusza van.
    /// A forgatások tömbön kívül, van még ForgatEgyFelulet metódus, ami segítségével forgatunk egy felületet. 
    /// </summary>
    public class Forgato
    {
        /// <summary>
        /// <see cref="Forgato"/> osztály konstruktora.
        /// Létrehozzuk a tömböt és megadjuk a kezdő értékeit.
        /// Azért 24 a tömb nagysága, mert összesen ennyi felületünk lehet.
        /// </summary>
        public Forgato()
        {
            this.Forgatasok = new int[24];

            for (int i = 0; i < this.Forgatasok.Length; i++)
            {
                this.Forgatasok[i] = -1;
            }
        }

        /// <summary>
        /// Ebben a tömbben tároljuk az adott felületek helyzetét
        /// -1 esetén nem használjuk a képet
        /// 0 esetén a kép nincs elforgatva
        /// 1 esetén a kép 90 fokkal jobbra el van forgatva
        /// 2 esetén 180 fokkal van elforgatva jobbra
        /// 3 esetén 270 fokkal van elforgatva jobbra
        /// </summary>
        public int[] Forgatasok { get; }

        /// <summary>
        /// Egy felületet forgatunk jobbra.
        /// </summary>
        /// <param name="felulet">Egy felülethez tartozó oldalainak színei.</param>
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
        /// <param name="forgatasok">Felületek státuszai</param>
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
