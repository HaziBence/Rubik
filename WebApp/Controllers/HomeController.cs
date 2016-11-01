using Rubik;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApp.Models;

namespace WebApp.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Start()
        {
            //Felületek példányosítása.
            LapKeszito lk = new LapKeszito();

            //Forgatások mátrix példányosítása.
            Console.WriteLine("forgat:");
            Forgato forgatasok = new Forgato();

            //Pálya példányosítása.
            Console.WriteLine("palya:");
            PalyaKeszito palyakeszito = new PalyaKeszito();

            //Megoldáshoz szükséges osztály példányosítása és a Backtrack futtatása.
            Megoldas mo = new Megoldas(lk.feluletek, forgatasok.forgatasok, palyakeszito.palya);
            mo.Backtrack();


            //Létrehozzuk a mezőket.
            Mezo[,] mezok = new Mezo[palyakeszito.palya.GetLength(0), palyakeszito.palya.GetLength(1)];
            //Mezőkhöz tartozó státuszokat hozzuk létre.
            string[,] allapotok = new string[palyakeszito.palya.GetLength(0), palyakeszito.palya.GetLength(1)];

            //Értékeket adunk a mezőknek és az állapotoknak, így megtudjuk, majd jeleníteni webes felületen.
            for (int y = 0; y < mezok.GetLength(0); y++)
            {
                for (int x = 0; x < mezok.GetLength(1); x++)
                {
                    int[] fonalak = new int[lk.feluletek.GetLength(1)];
                    int index = palyakeszito.palya[y, x];

                    for (int k = 0; k < fonalak.Length; k++)
                    {
                        fonalak[k] = lk.feluletek[index,k];
                    }

                    switch (forgatasok.forgatasok[index])
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

            return View("Rubik", new HomeModel(mezok, allapotok));
        }
    }
}