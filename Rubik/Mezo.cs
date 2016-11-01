using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rubik
{
    public class Mezo
    {
        /// <summary>
        /// Adott séma elérési útvonalát tartalmazza.
        /// </summary>
        public string Path { get; }

        /// <summary>
        /// Hozzárendeljük a felülethez a képet.
        /// A ciklus végén
        /// </summary>
        /// <param name="fonalak"></param>
        /// <param name="prefix"></param>
        public Mezo(int[] fonalak, string prefix)
        {
            Path = prefix;

            //sema0
            if (fonalak[0] == 0 && fonalak[1] == 1 &&
                fonalak[2] == 2 && fonalak[3] == 3 &&
                fonalak[4] == 0 && fonalak[5] == 2 &&
                fonalak[6] == 3 && fonalak[7] == 1)
            {
                Path += "/sema0.png";
            }


            //sema1
            if (fonalak[0] == 0 && fonalak[1] == 1 &&
                fonalak[2] == 3 && fonalak[3] == 2 &&
                fonalak[4] == 0 && fonalak[5] == 3 &&
                fonalak[6] == 2 && fonalak[7] == 1)
            {
                Path += "/sema1.png";
            }


            //sema2
            if (fonalak[0] == 0 && fonalak[1] == 2 &&
                fonalak[2] == 1 && fonalak[3] == 3 &&
                fonalak[4] == 0 && fonalak[5] == 1 &&
                fonalak[6] == 3 && fonalak[7] == 2)
            {
                Path += "/sema2.png";
            }

            //sema3
            if (fonalak[0] == 0 && fonalak[1] == 2 &&
                fonalak[2] == 3 && fonalak[3] == 1 &&
                fonalak[4] == 0 && fonalak[5] == 3 &&
                fonalak[6] == 1 && fonalak[7] == 2)
            {
                Path += "/sema3.png";
            }

            //sema4
            if (fonalak[0] == 0 && fonalak[1] == 3 &&
                fonalak[2] == 1 && fonalak[3] == 2 &&
                fonalak[4] == 0 && fonalak[5] == 1 &&
                fonalak[6] == 2 && fonalak[7] == 3)
            {
                Path += "/sema4.png";
            }

            //sema5
            if (fonalak[0] == 0 && fonalak[1] == 3 &&
                fonalak[2] == 2 && fonalak[3] == 1 &&
                fonalak[4] == 0 && fonalak[5] == 2 &&
                fonalak[6] == 1 && fonalak[7] == 3)
            {
                Path += "/sema5.png";
            }

            //sema6
            if (fonalak[0] == 1 && fonalak[1] == 0 &&
                fonalak[2] == 2 && fonalak[3] == 3 &&
                fonalak[4] == 1 && fonalak[5] == 2 &&
                fonalak[6] == 3 && fonalak[7] == 0)
            {
                Path += "/sema6.png";
            }

            //sema7
            if (fonalak[0] == 1 && fonalak[1] == 0 &&
                fonalak[2] == 3 && fonalak[3] == 2 &&
                fonalak[4] == 1 && fonalak[5] == 3 &&
                fonalak[6] == 2 && fonalak[7] == 0)
            {
                Path += "/sema7.png";
            }

            //sema8
            if (fonalak[0] == 1 && fonalak[1] == 2 &&
                fonalak[2] == 0 && fonalak[3] == 3 &&
                fonalak[4] == 1 && fonalak[5] == 0 &&
                fonalak[6] == 3 && fonalak[7] == 2)
            {
                Path += "/sema8.png";
            }

            //sema9
            if (fonalak[0] == 1 && fonalak[1] == 2 &&
                fonalak[2] == 3 && fonalak[3] == 0 &&
                fonalak[4] == 1 && fonalak[5] == 3 &&
                fonalak[6] == 0 && fonalak[7] == 2)
            {
                Path += "/sema9.png";
            }

            //sema10
            if (fonalak[0] == 1 && fonalak[1] == 3 &&
                fonalak[2] == 2 && fonalak[3] == 0 &&
                fonalak[4] == 1 && fonalak[5] == 2 &&
                fonalak[6] == 0 && fonalak[7] == 3)
            {
                Path += "/sema10.png";
            }

            //sema11
            if (fonalak[0] == 1 && fonalak[1] == 3 &&
                fonalak[2] == 0 && fonalak[3] == 2 &&
                fonalak[4] == 1 && fonalak[5] == 0 &&
                fonalak[6] == 2 && fonalak[7] == 3)
            {
                Path += "/sema11.png";
            }


            //sema12
            if (fonalak[0] == 2 && fonalak[1] == 0 &&
                fonalak[2] == 1 && fonalak[3] == 3 &&
                fonalak[4] == 2 && fonalak[5] == 1 &&
                fonalak[6] == 3 && fonalak[7] == 0)
            {
                Path += "/sema12.png";
            }

            //sema13
            if (fonalak[0] == 2 && fonalak[1] == 0 &&
                fonalak[2] == 3 && fonalak[3] == 1 &&
                fonalak[4] == 2 && fonalak[5] == 3 &&
                fonalak[6] == 1 && fonalak[7] == 0)
            {
                Path += "/sema13.png";
            }

            //sema14
            if (fonalak[0] == 2 && fonalak[1] == 1 &&
                fonalak[2] == 0 && fonalak[3] == 3 &&
                fonalak[4] == 2 && fonalak[5] == 0 &&
                fonalak[6] == 3 && fonalak[7] == 1)
            {
                Path += "/sema14.png";
            }

            //sema15
            if (fonalak[0] == 2 && fonalak[1] == 1 &&
                fonalak[2] == 3 && fonalak[3] == 0 &&
                fonalak[4] == 2 && fonalak[5] == 3 &&
                fonalak[6] == 0 && fonalak[7] == 1)
            {
                Path += "/sema15.png";
            }

            //sema16
            if (fonalak[0] == 2 && fonalak[1] == 3 &&
                fonalak[2] == 0 && fonalak[3] == 1 &&
                fonalak[4] == 2 && fonalak[5] == 0 &&
                fonalak[6] == 1 && fonalak[7] == 3)
            {
                Path += "/sema16.png";
            }

            //sema17
            if (fonalak[0] == 2 && fonalak[1] == 3 &&
                fonalak[2] == 1 && fonalak[3] == 0 &&
                fonalak[4] == 2 && fonalak[5] == 1 &&
                fonalak[6] == 0 && fonalak[7] == 3)
            {
                Path += "/sema17.png";
            }

            //sema18
            if (fonalak[0] == 3 && fonalak[1] == 0 &&
                fonalak[2] == 1 && fonalak[3] == 2 &&
                fonalak[4] == 3 && fonalak[5] == 1 &&
                fonalak[6] == 2 && fonalak[7] == 0)
            {
                Path += "/sema18.png";
            }

            //sema19
            if (fonalak[0] == 3 && fonalak[1] == 0 &&
                fonalak[2] == 2 && fonalak[3] == 1 &&
                fonalak[4] == 3 && fonalak[5] == 2 &&
                fonalak[6] == 1 && fonalak[7] == 0)
            {
                Path += "/sema19.png";
            }

            //sema20
            if (fonalak[0] == 3 && fonalak[1] == 1 &&
                fonalak[2] == 0 && fonalak[3] == 2 &&
                fonalak[4] == 3 && fonalak[5] == 0 &&
                fonalak[6] == 2 && fonalak[7] == 1)
            {
                Path += "/sema20.png";
            }

            //sema21
            if (fonalak[0] == 3 && fonalak[1] == 1 &&
                fonalak[2] == 2 && fonalak[3] == 0 &&
                fonalak[4] == 3 && fonalak[5] == 2 &&
                fonalak[6] == 0 && fonalak[7] == 1)
            {
                Path += "/sema21.png";
            }

            //sema22
            if (fonalak[0] == 3 && fonalak[1] == 2 &&
                fonalak[2] == 0 && fonalak[3] == 1 &&
                fonalak[4] == 3 && fonalak[5] == 0 &&
                fonalak[6] == 1 && fonalak[7] == 2)
            {
                Path += "/sema22.png";
            }

            //sema23
            if (fonalak[0] == 3 && fonalak[1] == 2 &&
                fonalak[2] == 1 && fonalak[3] == 0 &&
                fonalak[4] == 3 && fonalak[5] == 1 &&
                fonalak[6] == 0 && fonalak[7] == 2)
            {
                Path += "/sema23.png";
            }

        }
    }
}
