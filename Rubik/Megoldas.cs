namespace Rubik
{
    using System;

    /// <summary>
    /// A feladat megoldását végző osztály.
    /// </summary>
    public class Megoldas
    {
        private int[,] feluletek;

        private int[] forgatasok;

        private int[,] palya;

        private int[] elozoElem;

        private int[] mostaniElem;

        /// <summary>
        /// <see cref="Megoldas"/> konstruktora.
        /// </summary>
        /// <param name="feluletek">Felületek tömbje</param>
        /// <param name="forgatasok">Felületekhez tartozó státuszok</param>
        /// <param name="palya">Pálya tömbje</param>
        public Megoldas(int[,] feluletek, int[] forgatasok, int[,] palya)
        {
            this.feluletek = feluletek;
            this.forgatasok = forgatasok;
            this.palya = palya;
        }

        /// <summary>
        /// Értéket adunk a pálya egyik bizonyos pontjának.
        /// A forgatások tömbben pedig megváltoztatjuk a státuszát.
        /// </summary>
        /// <param name="y">Magasság</param>
        /// <param name="x">Szélesség</param>
        /// <param name="feluletSzam">Hányadik felületet használjuk</param>
        /// <param name="forgatasSzam">Felület státusza</param>
        public void ErtekAdas(int y, int x, int feluletSzam, int forgatasSzam)
        {
            this.palya[y, x] = feluletSzam;
            this.forgatasok[feluletSzam] = forgatasSzam;
        }

        /// <summary>
        /// A pályát feltöltjük a megadott feltételeknek megfelelően.
        /// </summary>
        public void Backtrack()
        {
            int x = 0;
            int y = 0;

            elozoElem = new int[8];
            mostaniElem = new int[8];

            // Megadjuk a kezdő elemet
            ErtekAdas(y, x, 0, -1);

            while (x > -1 && y > -1)
            {
                // A pálya adott pontjából kiszedjük az információt, hogy hányadik felületet tartalmazza.
                int feluletSzam = palya[y, x];

                // Adott felületről kérdezzük le a státuszát.
                int forgatasSzam = forgatasok[feluletSzam];

                while (feluletSzam < 24)
                {
                    // Azt vizsgáljuk, hogy nem forgattuk-e már körbe az adott felületet.
                    if (feluletSzam > -1 && forgatasSzam < 3)
                    {
                        forgatasSzam++;
                    }
                    else
                    {
                        // Ha nem tudjuk elhelyezni a felületet akkor a státuszát -1-re állítjuk.
                        if (feluletSzam != -1)
                        {
                            forgatasok[feluletSzam] = -1;
                            forgatasSzam = 0;
                        }

                        // Egy olyan felületet keresünk, ami nincs még fel használva.
                        do
                        {
                            feluletSzam++;

                            if (feluletSzam == 24)
                            {
                                palya[y, x] = -1;
                                x--;

                                if (x == -1)
                                {
                                    x = 2;
                                    y--;
                                }

                                // vége az algoritmusnak
                                if (y == -1)
                                {
                                    Console.WriteLine("vége");
                                    Console.WriteLine();
                                }

                                break;
                            }
                        } while (forgatasok[feluletSzam] > -1);
                    }

                    // Ha egyik felület sem volt megfelelő, akkor kilépünk a ciklusból.
                    if (feluletSzam == 24)
                    {
                        continue;
                    }

                    // Használva van-e az aktuális felület hátoldala.
                    if ((feluletSzam < 12 && forgatasok[feluletSzam + 12] > -1) ||
                        (feluletSzam > 11 && forgatasok[feluletSzam - 11] > -1))
                    {
                        continue;
                    }

                    if (x > 0)
                    {
                        // Kimentjük egy másk tömbbe az előző és mostani elemek színeit.
                        for (int i = 0; i < feluletek.GetLength(1); i++)
                        {
                            elozoElem[i] = feluletek[palya[y, x - 1], i];
                            mostaniElem[i] = feluletek[feluletSzam, i];
                        }

                        // Forgatjuk a felületeket
                        for (int j = 0; j < forgatasok[palya[y, x - 1]]; j++)
                        {
                            Forgato.ForgatEgyFelulet(elozoElem);
                        }

                        for (int k = 0; k < forgatasSzam; k++)
                        {
                            Forgato.ForgatEgyFelulet(mostaniElem);
                        }

                        // Ellenőrizzük, hogy összeillik-e a 2 felület
                        if (elozoElem[2] != mostaniElem[7] ||
                            elozoElem[3] != mostaniElem[6])
                        {
                            continue;
                        }
                    }

                    if (y > 0)
                    {
                        // Kimentjük egy másk tömbbe az előző és mostani elemek színeit.
                        for (int i = 0; i < feluletek.GetLength(1); i++)
                        {
                            elozoElem[i] = feluletek[palya[y - 1, x], i];
                            mostaniElem[i] = feluletek[feluletSzam, i];
                        }

                        // Forgatjuk a felületeket
                        for (int j = 0; j < forgatasok[palya[y - 1, x]]; j++)
                        {
                            Forgato.ForgatEgyFelulet(elozoElem);
                        }

                        for (int k = 0; k < forgatasSzam; k++)
                        {
                            Forgato.ForgatEgyFelulet(mostaniElem);
                        }

                        // Ellenőrizzük, hogy összeillik-e a 2 felület
                        if (elozoElem[5] != mostaniElem[0] ||
                            elozoElem[4] != mostaniElem[1])
                        {
                            continue;
                        }
                    }

                    // Elhelyezzük az aktuális felületet.
                    ErtekAdas(y, x, feluletSzam, forgatasSzam);

                    x++;

                    if (x == 3)
                    {
                        x = 0;
                        y++;
                    }

                    // van megoldás
                    if (y == 3) 
                    {
                        Console.WriteLine("megvan");
                        LapKeszito.Kiiras(feluletek);
                        Forgato.Kiiras(forgatasok);
                        PalyaKeszito.Kiiras(palya);
                        Console.WriteLine();

                        return;
                    }

                    feluletSzam = -1;
                    forgatasSzam = 0;
                    palya[y, x] = -1;
                }
            }
        }
    }
}