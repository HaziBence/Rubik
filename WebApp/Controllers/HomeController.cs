namespace WebApp.Controllers
{
    using System;
    using System.Web.Mvc;
    using Rubik;
    using WebApp.Models;

    public class HomeController : Controller
    {
        /// <summary>
        /// GET: Home
        /// </summary>
        /// <returns>Visszaadja az indexet</returns>
        public ActionResult Index()
        {
            return this.View();
        }

        /// <summary>
        /// Példányosítja az osztályokat, lefuttatja a backtracket, majd a az eredményét visszaadjuk.  
        /// </summary>
        /// <returns>Backtrack eredménye formázva, hogy webes felületre ki tudjuk küldeni.</returns>
        [HttpPost]
        public ActionResult Start()
        {
            // Felületek példányosítása.
            LapKeszito lk = new LapKeszito();

            // Forgatások mátrix példányosítása.
            Console.WriteLine("forgat:");
            Forgato forgatasok = new Forgato();

            // Pálya példányosítása.
            Console.WriteLine("palya:");
            PalyaKeszito palyakeszito = new PalyaKeszito();

            // Megoldáshoz szükséges osztály példányosítása és a Backtrack futtatása.
            Megoldas mo = new Megoldas(lk.Feluletek, forgatasok.Forgatasok, palyakeszito.Palya);
            mo.Backtrack();

            // Létrehozzuk a mezőket.
            Mezo[,] mezok = new Mezo[palyakeszito.Palya.GetLength(0), palyakeszito.Palya.GetLength(1)];

            // Mezőkhöz tartozó státuszokat hozzuk létre.
            string[,] allapotok = new string[palyakeszito.Palya.GetLength(0), palyakeszito.Palya.GetLength(1)];

            // Értékeket adunk a mezőknek és az állapotoknak, így megtudjuk, majd jeleníteni webes felületen.
            for (int y = 0; y < mezok.GetLength(0); y++)
            {
                for (int x = 0; x < mezok.GetLength(1); x++)
                {
                    int[] fonalak = new int[lk.Feluletek.GetLength(1)];
                    int index = palyakeszito.Palya[y, x];

                    for (int k = 0; k < fonalak.Length; k++)
                    {
                        fonalak[k] = lk.Feluletek[index, k];
                    }

                    switch (forgatasok.Forgatasok[index])
                    {
                        case 1:
                            allapotok[y, x] = "forgat90";
                            break;
                        case 2:
                            allapotok[y, x] = "forgat180";
                            break;
                        case 3:
                            allapotok[y, x] = "forgat270";
                            break;
                    }

                    mezok[y, x] = new Mezo(fonalak, "/Images");
                }
            }

            return this.View("Rubik", new HomeModel(mezok, allapotok));
        }
    }
}