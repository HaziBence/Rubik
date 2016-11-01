namespace Rubik
{
    using System;

    /// <summary>
    /// Ebben az osztályban készítjük el a felületeket.
    /// </summary>
    public class LapKeszito
    {
        /// <summary>
        /// Létrehozzuk ebben a konstruktorban a felületeket.
        /// </summary>
        public LapKeszito()
        {
            this.Feluletek = this.Keszites();
        }

        /// <summary>
        /// A felületekhez tartozó oldalaiknak a fonál színét tartalmazza.
        /// </summary>
        public int[,] Feluletek { get; }

        /// <summary>
        /// Kiírja az összes felület oldalához tartozó fonál színeket.
        /// </summary>
        /// <param name="feluletek">Felületek az oldalaik színeivel.</param>
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

        /// <summary>
        /// Elkészíti a felületeket.
        /// </summary>
        /// <returns>Visszaadja a felületek tömböt, amiben az elkészült felületek oldalaik színével van feltöltve.</returns>
        private int[,] Keszites()
        {
            int[,] feluletek = new int[24, 8]; // 24 oldal és a hozzájuk tartozó színek
            int darab = 0;

            for (int i = 0; i < 4; i++)
            {
                for (int j = 0; j < 4; j++)
                {
                    for (int k = 0; k < 4; k++)
                    {
                        for (int l = 0; l < 4; l++)
                        {
                            // kizárjuk azokat a lehetőségeket, amelyeknél olyan oldalak készülnének, amelyeke nem felelnek meg a játék leírásának
                            if (i != j && i != k && k != j && i != l && j != l && k != l)
                            {
                                // felül
                                feluletek[darab, 0] = i;
                                feluletek[darab, 1] = j;

                                // jobb oldalon
                                feluletek[darab, 2] = k;
                                feluletek[darab, 3] = l;

                                // alul
                                feluletek[darab, 4] = i;
                                feluletek[darab, 5] = k;

                                // bal oldalon
                                feluletek[darab, 6] = l;
                                feluletek[darab, 7] = j;

                                darab++; // következő oldal
                            }
                        }
                    }
                }
            }

            return feluletek;
        }
    }
}
