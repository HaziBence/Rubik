using Rubik;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApp.Models
{
    public class HomeModel
    {
        /// <summary>
        /// A pálya mezőit tartalmazza.
        /// </summary>
        public Mezo[,] mezok;

        /// <summary>
        /// A mezőkhöz tartozó státuszokat tartalmazza.
        /// </summary>
        public string[,] forgatasok;

        public HomeModel(Mezo[,] mezok, string[,] forgatasok)
        {
            this.mezok = mezok;
            this.forgatasok = forgatasok;
        }
    }
}