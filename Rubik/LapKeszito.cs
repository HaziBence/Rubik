using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rubik
{
    public class LapKeszito
    {
        /// <summary>
        /// A felületekhez tartozó oldalaiknak a fonál színét tartalmazza.
        /// </summary>
        public int[,] feluletek { get; }

        /// <summary>
        /// Létrehozzuk ebben a konstruktorban a felületeket.
        /// </summary>
        public LapKeszito()
        {
            feluletek = Keszites();
        }

        /// <summary>
        /// Elkészíti a felületeket.
        /// </summary>
        /// <returns></returns>
        private int[,] Keszites()
        {
            int[,] feluletek = new int[24, 8]; //24 oldal és a hozzájuk tartozó színek
            int darab = 0;

            for (int i = 0; i < 4; i++)
            {
                for (int j = 0; j < 4; j++)
                {
                    for (int k = 0; k < 4; k++)
                    {
                        for (int l = 0; l < 4; l++)
                        {
                            //kizárjuk azokat a lehetőségeket, amelyeknél olyan oldalak készülnének, amelyeke nem felelnek meg a játék leírásának
                            if (i != j && i != k && k != j && i != l && j != l && k != l)
                            {
                                //felül
                                feluletek[darab, 0] = i;
                                feluletek[darab, 1] = j;

                                //jobb oldalon
                                feluletek[darab, 2] = k;
                                feluletek[darab, 3] = l;

                                //alul
                                feluletek[darab, 4] = i;
                                feluletek[darab, 5] = k;

                                //bal oldalon
                                feluletek[darab, 6] = l;
                                feluletek[darab, 7] = j;

                                darab++; //következő oldal
                            }
                        }
                    }
                }
            }
            return feluletek;
        }

        /// <summary>
        /// Kiírja az összes felület oldalához tartozó fonál színeket.
        /// </summary>
        /// <param name="feluletek"></param>
        public static void Kiiras(int[,] feluletek)
        {
            for (int i = 0; i < feluletek.GetLength(1); i++)
            {
                for (int j = 0; j < feluletek.GetLength(0); j++)
                {
                    Console.Write(feluletek[j, i]);
                    Console.Write(" ");
                }
                Console.WriteLine();
            }
            Console.WriteLine(Environment.NewLine);
        }
    }
}
