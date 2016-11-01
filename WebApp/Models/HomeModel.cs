namespace WebApp.Models
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Web;
    using Rubik;

    public class HomeModel
    {
        /// <summary>
        /// <see cref="HomeModel"/> konstruktora
        /// </summary>
        /// <param name="mezok">Mezők</param>
        /// <param name="forgatasok">Felületek státusza</param>
        public HomeModel(Mezo[,] mezok, string[,] forgatasok)
        {
            this.Mezok = mezok;
            this.Forgatasok = forgatasok;
        }

        /// <summary>
        /// A pálya mezőit tartalmazza.
        /// </summary>
        public Mezo[,] Mezok { get; }

        /// <summary>
        /// A mezőkhöz tartozó státuszokat tartalmazza.
        /// </summary>
        public string[,] Forgatasok { get; }
    }
}