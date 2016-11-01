using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rubik
{
    public class Megoldas
    {
        int[,] feluletek;
        int[] forgatasok;
        int[,] palya;

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
        /// <param name="x"></param>
        /// <param name="y"></param>
        /// <param name="feluletSzam"></param>
        /// <param name="forgatasSzam"></param>
        public void ErtekAdas(int y, int x, int feluletSzam, int forgatasSzam)
        {
            palya[y, x] = feluletSzam;
            forgatasok[feluletSzam] = forgatasSzam;
        }


        int FeluletSzam = 0;
        //Adott felületről kérdezzük le a státuszát.
        int ForgatasSzam = 0;

        int[] ElozoElem;
        int[] MostaniElem;
        int valami = 0;

        /// <summary>
        /// A pályát feltöltjük a megadott feltételeknek megfelelően.
        /// </summary>
        public void Backtrack()
        {
            int x = 0;
            int y = 0;

            ElozoElem = new int[8];
            MostaniElem = new int[8];

            //Megadjuk a kezdő elemet
            ErtekAdas(x, y, 0, -1);

            while (x > -1 && y > -1)
            {
                //A pálya adott pontjából kiszedjük az információt, hogy hányadik felületet tartalmazza.
                FeluletSzam = palya[y, x];
                //Adott felületről kérdezzük le a státuszát.
                ForgatasSzam = forgatasok[FeluletSzam];

                while (FeluletSzam < 24)
                {
                    //Azt vizsgáljuk, hogy nem forgattuk-e már körbe az adott felületet.
                    if (FeluletSzam > -1 && ForgatasSzam < 3)
                    {
                        ForgatasSzam++;
                    }
                    else
                    {
                        //Ha nem tudjuk elhelyezni a felületet akkor a státuszát -1-re állítjuk.
                        if (FeluletSzam != -1)
                        {
                            forgatasok[FeluletSzam] = -1;
                            ForgatasSzam = 0;
                        }

                        //Egy olyan felületet keresünk, ami nincs még fel használva.
                        do
                        {
                            FeluletSzam++;

                            if (FeluletSzam == 24)
                            {
                                palya[y, x] = -1;
                                x--;

                                if (x == -1)
                                {
                                    x = 2;
                                    y--;
                                }
                                if (y == -1) // vége az algoritmusnak
                                {
                                    Console.WriteLine("vége");
                                    Console.WriteLine();
                                }
                                break;
                            }

                        } while (forgatasok[FeluletSzam] > -1);
                    }

                    //Ha egyik felület sem volt megfelelő, akkor kilépünk a ciklusból.
                    if (FeluletSzam == 24)
                    {
                        continue;
                    }

                    //Használva van-e az aktuális felület hátoldala.
                    //if ((FeluletSzam < 12 && forgatasok[FeluletSzam + 12] > -1) ||
                    //    (FeluletSzam > 11 && forgatasok[FeluletSzam - 11] > -1))
                    //{
                    //    continue;
                    //}

                    if (x > 0)
                    {
                        for (int i = 0; i < feluletek.GetLength(1); i++)
                        {
                            ElozoElem[i] = feluletek[palya[y, x - 1], i];
                            MostaniElem[i] = feluletek[FeluletSzam, i];
                        }

                        for (int j = 0; j < forgatasok[palya[y, x - 1]]; j++)
                        {
                            Forgato.ForgatEgyFelulet(ElozoElem);
                        }

                        for (int k = 0; k < ForgatasSzam; k++)
                        {
                            Forgato.ForgatEgyFelulet(MostaniElem);
                        }

                        if ((ElozoElem[2] != MostaniElem[7] ||
                             ElozoElem[3] != MostaniElem[6]))
                        {
                            continue;
                        }
                    }

                    if (y > 0)
                    {
                        for (int i = 0; i < feluletek.GetLength(1); i++)
                        {
                            ElozoElem[i] = feluletek[palya[y - 1, x], i];
                            MostaniElem[i] = feluletek[FeluletSzam, i];
                        }

                        for (int j = 0; j < forgatasok[palya[y - 1, x]]; j++)
                        {
                            Forgato.ForgatEgyFelulet(ElozoElem);
                        }

                        for (int k = 0; k < ForgatasSzam; k++)
                        {
                            Forgato.ForgatEgyFelulet(MostaniElem);
                        }

                        if (y > 0 && (ElozoElem[5] != MostaniElem[0] ||
                                      ElozoElem[4] != MostaniElem[1]))
                        {
                            continue;
                        }
                    }

                    //Elhelyezzük az aktuális felületet.
                    ErtekAdas(y, x, FeluletSzam, ForgatasSzam);

                    x++;

                    if (x == 3)
                    {
                        x = 0;
                        y++;
                        //PalyaKeszito.Kiiras(palya);
                    }

                    if (y == 3)
                    { // van megoldás
                        Console.WriteLine("megvan");
                        LapKeszito.Kiiras(feluletek);
                        PalyaKeszito.Kiiras(palya);
                        Forgato.Kiiras(forgatasok);
                        Console.WriteLine();

                        //y--;

                        return;
                    }

                    FeluletSzam = -1;
                    ForgatasSzam = 0;
                    palya[y, x] = -1;
                }
            }
        }
    }
}