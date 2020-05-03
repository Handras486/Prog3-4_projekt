// <copyright file="Program.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace LoLesports.Program
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using System.Xml.Linq;
    using LoLesports.Logic;

    /// <summary>
    /// Main Program class.
    /// Forwards input data to Logic.
    /// </summary>
    public class Program
    {
        private static ConsoleKeyInfo c;
        private static JatekosLogic jatekosLogic = new JatekosLogic();
        private static CsapatLogic csapatLogic = new CsapatLogic();
        private static LigaLogic ligaLogic = new LigaLogic();

        /// <summary>
        /// Initializes menu.
        /// </summary>
        public static void Main()
        {
            MenuExecute();
        }

        private static void MenuExecute()
        {
            do
            {
               try
                {
                 Console.Clear();
                 MainMenu();
                 c = Console.ReadKey();
                 switch (c.Key)
                 {
                    case ConsoleKey.D1:
                        ReadMenu();
                        break;
                    case ConsoleKey.D2:
                        CreateMenu();
                        break;
                    case ConsoleKey.D3:
                        UpdateMenu();
                        break;
                    case ConsoleKey.D4:
                        DeleteMenu();
                        break;
                    case ConsoleKey.D5:
                        JatekosInfo();
                        break;
                    case ConsoleKey.D6:
                        MatchCreator();
                        break;
                    case ConsoleKey.D7:
                        Console.Clear();
                        Console.WriteLine(jatekosLogic.GetPlayersByCountry());
                        Console.WriteLine("\nNyomj egy gombot, hogy visszakerülj a menübe!");
                        Console.ReadKey();
                        break;
                    case ConsoleKey.D8:
                        Console.Clear();
                        Console.WriteLine(jatekosLogic.OnlineDB());
                        Console.WriteLine("\nNyomj egy gombot, hogy visszakerülj a menübe!");
                        Console.ReadKey();
                        break;
                    case ConsoleKey.D9:
                        Console.Clear();
                        Console.WriteLine("Adja meg a játékos nevét:");
                        Console.WriteLine(jatekosLogic.JavaVegpont(Console.ReadLine()));
                        Console.WriteLine("\nNyomj egy gombot, hogy visszakerülj a menübe!");
                        Console.ReadKey();
                        break;
                    default:
                        break;
                 }
               }
               catch (Exception ex)
               {
                    Console.WriteLine("\nA menü működése közben hiba történt:\n" + ex.Message);
                    Console.WriteLine("\n(99.99% hogy túl hosszú adatot írtál egy mezőhöz / Nem jó kulcsot adtál másik táblához)");
                    Console.WriteLine("\nNyomj egy gombot, hogy visszakerülj a menübe!");
                    Console.ReadKey();
               }
            }
            while (c.Key != ConsoleKey.Escape);
        }

        private static void MatchCreator()
        {
            Console.Clear();
            Console.WriteLine("\nÍrd be egy létező csapat nevét:");
            var ellenfelek = csapatLogic.MatchCreator(Console.ReadLine());
            if (ellenfelek != null)
            {
                Random rnd = new Random();
                Console.WriteLine("Ellenfél csapat: ");
                Console.WriteLine();
                Console.WriteLine(ellenfelek.ElementAt(rnd.Next(0, ellenfelek.Count())));
                if (rnd.Next(1) == 0)
                {
                    Console.WriteLine("\nGyőzelem!");
                }
                else
                {
                    Console.WriteLine("\nVereség");
                }
            }
            else
            {
                Console.WriteLine("\nA csapat nem létezik!");
            }

            Console.WriteLine("\nNyomj egy gombot, hogy visszakerülj a menübe!");
            Console.ReadKey();
        }

        private static void JatekosInfo()
        {
            Console.Clear();
            Console.WriteLine("\nÍrd be egy létező játékos felhasználónevét:");
            Console.WriteLine(jatekosLogic.GetFullInfo(Console.ReadLine()));
            Console.WriteLine("\nNyomj egy gombot, hogy visszakerülj a menübe!");
            Console.ReadKey();
        }

        private static void DeleteMenu()
        {
            Console.Clear();
            TableChoiceMenu();
            c = Console.ReadKey();
            Console.Clear();
            switch (c.Key)
            {
                case ConsoleKey.D1:
                    DeleteLigaMenu();
                    Console.WriteLine("\n Nyomj egy gombot, hogy visszakerülj a menübe!");
                    Console.ReadKey();
                    break;
                case ConsoleKey.D2:
                    DeleteCsapatMenu();
                    Console.WriteLine("\n Nyomj egy gombot, hogy visszakerülj a menübe!");
                    Console.ReadKey();
                    break;
                case ConsoleKey.D3:
                    DeleteJatekosMenu();
                    Console.WriteLine("\n Nyomj egy gombot, hogy visszakerülj a menübe!");
                    Console.ReadKey();
                    break;
                default:
                    Console.WriteLine("Ez a tábla nem található!");
                    Console.WriteLine("\n Nyomj egy gombot, hogy visszakerülj a menübe!");
                    Console.ReadKey();
                    break;
            }
        }

        private static void DeleteJatekosMenu()
        {
            Console.WriteLine("\n Írd be egy létező Játékos felhasználónevét:");
            if (jatekosLogic.DeleteJatekosElement(Console.ReadLine()))
            {
                Console.WriteLine("\nSikeres törlés!");
            }
            else
            {
                Console.WriteLine("\nAz elem nem létezik!");
            }
        }

        private static void DeleteCsapatMenu()
        {
            Console.WriteLine("\n Írd be egy létező Csapat nevét:");
            if (csapatLogic.DeleteCsapatElement(Console.ReadLine()))
            {
                Console.WriteLine("\nSikeres törlés!");
            }
            else
            {
                Console.WriteLine("\nAz elem nem létezik!");
            }
        }

        private static void DeleteLigaMenu()
        {
            Console.WriteLine("\n Írd be egy létező Liga nevét:");
            if (ligaLogic.DeleteLigaElement(Console.ReadLine()))
            {
                Console.WriteLine("\nSikeres törlés!");
            }
            else
            {
                Console.WriteLine("\nAz elem nem létezik!");
            }
        }

        private static void UpdateMenu()
        {
            Console.Clear();
            TableChoiceMenu();
            c = Console.ReadKey();
            Console.Clear();
            switch (c.Key)
            {
                case ConsoleKey.D1:
                    UpdateLigaMenu();
                    Console.WriteLine("\n Nyomj egy gombot, hogy visszakerülj a menübe!");
                    Console.ReadKey();
                    break;
                case ConsoleKey.D2:
                    UpdateCsapatMenu();
                    Console.WriteLine("\n Nyomj egy gombot, hogy visszakerülj a menübe!");
                    Console.ReadKey();
                    break;
                case ConsoleKey.D3:
                    UpdateJatekosMenu();
                    Console.WriteLine("\n Nyomj egy gombot, hogy visszakerülj a menübe!");
                    Console.ReadKey();
                    break;
                default:
                    Console.WriteLine("Ez a tábla nem található!");
                    Console.WriteLine("\n Nyomj egy gombot, hogy visszakerülj a menübe!");
                    Console.ReadKey();
                    break;
            }
        }

        private static void UpdateJatekosMenu()
        {
            List<object> jatekoslist = new List<object>();
            Console.WriteLine("\n Írd be egy létező Játékos felhasználónevét:");
            jatekoslist.Add(Console.ReadLine());
            Console.WriteLine("\n Írd be a Játékos új vezetéknevét:");
            jatekoslist.Add(Console.ReadLine());
            Console.WriteLine("\n Írd be a Játékos új keresztnevét(opcionális):");
            jatekoslist.Add(Console.ReadLine());
            Console.WriteLine("\n Írd be a Játékos új életkorát(opcionális):");
            string temp1 = Console.ReadLine();
            if (temp1 != string.Empty)
            {
                try
                {
                    jatekoslist.Add(int.Parse(temp1));
                }
                catch (Exception ex)
                {
                    Console.Clear();
                    Console.WriteLine(ex.Message + "\nKezdje újra a feltöltést!");
                    return;
                }
            }
            else
            {
                jatekoslist.Add(null);
            }

            Console.WriteLine("\n Írd be a Játékos új pozícióját:");
            jatekoslist.Add(Console.ReadLine());
            Console.WriteLine("\n Írd be a Játékos új nemzetiségét(opcionális):");
            jatekoslist.Add(Console.ReadLine());
            Console.WriteLine("\n Írd be a Játékos csapatának új nevét(létezők közül):");
            jatekoslist.Add(Console.ReadLine());

            if (jatekosLogic.UpdateJatekosElement(jatekoslist))
            {
                Console.WriteLine("\nSikeres frissítés!");
            }
            else
            {
                Console.WriteLine("\nAz elem nem létezik!");
            }
        }

        private static void UpdateCsapatMenu()
        {
            List<object> csapatlist = new List<object>();
            Console.WriteLine("\n Írd be egy létező Csapat nevét:");
            csapatlist.Add(Console.ReadLine());
            Console.WriteLine("\n Írd be a Csapat ligájának új nevét(létezők közül):");
            csapatlist.Add(Console.ReadLine());
            Console.WriteLine("\n Írd be a Csapat nevének új rövidítését:");
            csapatlist.Add(Console.ReadLine());
            Console.WriteLine("\n Írd be a Csapat organizációjának új székhelyét(opcionális):");
            csapatlist.Add(Console.ReadLine());
            Console.WriteLine("\n Írd be a Csapat alapításának új dátumát(opcionális):");
            string temp1 = Console.ReadLine();
            if (temp1 != string.Empty)
            {
                try
                {
                    csapatlist.Add(DateTime.Parse(temp1));
                }
                catch (Exception ex)
                {
                    Console.Clear();
                    Console.WriteLine(ex.Message + "\nKezdje újra a feltöltést!");
                    return;
                }
            }
            else
            {
                csapatlist.Add(null);
            }

            Console.WriteLine("\n Írd be a Csapat új fő edzőjét(opcionális):");
            csapatlist.Add(Console.ReadLine());
            Console.WriteLine("\n Írd be hogy a Csapat részt vesz-e a bajnokságban:(true/false)");
            try
            {
                csapatlist.Add(bool.Parse(Console.ReadLine()));
            }
            catch (Exception ex)
            {
                Console.Clear();
                Console.WriteLine(ex.Message + "\nKezdje újra a feltöltést!");
                return;
            }

            if (csapatLogic.UpdateCsapatElement(csapatlist))
            {
                Console.WriteLine("\nSikeres frissítés!");
            }
            else
            {
                Console.WriteLine("\nAz elem nem létezik!");
            }
        }

        private static void UpdateLigaMenu()
        {
            List<object> ligalist = new List<object>();
            Console.WriteLine("\n Írd be egy létező Liga nevét:");
            ligalist.Add(Console.ReadLine());
            Console.WriteLine("\n Írd be a Liga új régióját:");
            ligalist.Add(Console.ReadLine());
            Console.WriteLine("\n Írd be a Liga új stúdiójának helyét(opcionális):");
            ligalist.Add(Console.ReadLine());
            Console.WriteLine("\n Írd be a Liga szezonjának új kezdetét(opcionális):");
            string temp1 = Console.ReadLine();
            if (temp1 != string.Empty)
            {
                try
                {
                    ligalist.Add(DateTime.Parse(temp1));
                }
                catch (Exception ex)
                {
                    Console.Clear();
                    Console.WriteLine(ex.Message + "\nKezdje újra a feltöltést!");
                    return;
                }
            }
            else
            {
                ligalist.Add(null);
            }

            Console.WriteLine("\n Írd be a Liga szezonjának új végét(opcionális):");
            string temp2 = Console.ReadLine();
            if (temp2 != string.Empty)
            {
                try
                {
                    ligalist.Add(DateTime.Parse(temp2));
                }
                catch (Exception ex)
                {
                    Console.Clear();
                    Console.WriteLine(ex.Message + "\nKezdje újra a feltöltést!");
                    return;
                }
            }
            else
            {
                ligalist.Add(null);
            }

            Console.WriteLine("\n Írd be a Liga csapatainak új számát:");
            try
            {
                ligalist.Add(int.Parse(Console.ReadLine()));
            }
            catch (Exception ex)
            {
                Console.Clear();
                Console.WriteLine(ex.Message + "\nKezdje újra a feltöltést!");
                return;
            }

            if (ligaLogic.UpdateLigaElement(ligalist))
            {
                Console.WriteLine("\nSikeres frissítés!");
            }
            else
            {
                Console.WriteLine("\nAz elem nem létezik!");
            }
        }

        private static void CreateMenu()
        {
            Console.Clear();
            TableChoiceMenu();
            c = Console.ReadKey();
            Console.Clear();
            switch (c.Key)
            {
                case ConsoleKey.D1:
                    CreateLigaMenu();
                    Console.WriteLine("\n Nyomj egy gombot, hogy visszakerülj a menübe!");
                    Console.ReadKey();
                    break;
                case ConsoleKey.D2:
                    CreateCsapatMenu();
                    Console.WriteLine("\n Nyomj egy gombot, hogy visszakerülj a menübe!");
                    Console.ReadKey();
                    break;
                case ConsoleKey.D3:
                    CreateJatekosMenu();
                    Console.WriteLine("\n Nyomj egy gombot, hogy visszakerülj a menübe!");
                    Console.ReadKey();
                    break;
                default:
                    Console.WriteLine("Ez a tábla nem található!");
                    Console.WriteLine("\n Nyomj egy gombot, hogy visszakerülj a menübe!");
                    Console.ReadKey();
                    break;
            }
        }

        private static void CreateJatekosMenu()
        {
            List<object> jatekoslist = new List<object>();
            Console.WriteLine("\n Írd be az új Játékos felhasználónevét:");
            jatekoslist.Add(Console.ReadLine());
            Console.WriteLine("\n Írd be az új Játékos vezetéknevét:");
            jatekoslist.Add(Console.ReadLine());
            Console.WriteLine("\n Írd be az új Játékos keresztnevét(opcionális):");
            jatekoslist.Add(Console.ReadLine());
            Console.WriteLine("\n Írd be az új Játékos életkorát(opcionális):");
            string temp1 = Console.ReadLine();
            if (temp1 != string.Empty)
            {
                try
                {
                    jatekoslist.Add(int.Parse(temp1));
                }
                catch (Exception ex)
                {
                    Console.Clear();
                    Console.WriteLine(ex.Message + "\nKezdje újra a feltöltést!");
                    return;
                }
            }
            else
            {
                jatekoslist.Add(null);
            }

            Console.WriteLine("\n Írd be az új Játékos pozícióját:");
            jatekoslist.Add(Console.ReadLine());
            Console.WriteLine("\n Írd be az új Játékos nemzetiségét(opcionális):");
            jatekoslist.Add(Console.ReadLine());
            Console.WriteLine("\n Írd be az új Játékos csapatának nevét(létezők közül):");
            jatekoslist.Add(Console.ReadLine());

            if (jatekosLogic.CreateJatekosElement(jatekoslist))
            {
                Console.WriteLine("\nSikeres hozzáadás!");
            }
            else
            {
                Console.WriteLine("\nAz elem már létezik!");
            }
        }

        private static void CreateCsapatMenu()
        {
            List<object> csapatlist = new List<object>();
            Console.WriteLine("\n Írd be az új Csapat nevét:");
            csapatlist.Add(Console.ReadLine());
            Console.WriteLine("\n Írd be az új Csapat ligájának nevét(létezők közül):");
            csapatlist.Add(Console.ReadLine());
            Console.WriteLine("\n Írd be az új Csapat nevének rövidítését:");
            csapatlist.Add(Console.ReadLine());
            Console.WriteLine("\n Írd be az új Csapat organizációjának székhelyét(opcionális):");
            csapatlist.Add(Console.ReadLine());
            Console.WriteLine("\n Írd be az új Csapat alapításának dátumát(opcionális):");
            string temp1 = Console.ReadLine();
            if (temp1 != string.Empty)
            {
                try
                {
                    csapatlist.Add(DateTime.Parse(temp1));
                }
                catch (Exception ex)
                {
                    Console.Clear();
                    Console.WriteLine(ex.Message + "\nKezdje újra a feltöltést!");
                    return;
                }
            }
            else
            {
                csapatlist.Add(null);
            }

            Console.WriteLine("\n Írd be az új Csapat fő edzőjét(opcionális):");
            csapatlist.Add(Console.ReadLine());
            Console.WriteLine("\n Írd be hogy az új Csapat részt vesz-e a bajnokságban:(true/false)");
            try
            {
                csapatlist.Add(bool.Parse(Console.ReadLine()));
            }
            catch (Exception ex)
            {
                Console.Clear();
                Console.WriteLine(ex.Message + "\nKezdje újra a feltöltést!");
                return;
            }

            if (csapatLogic.CreateCsapatElement(csapatlist))
            {
                Console.WriteLine("\nSikeres hozzáadás!");
            }
            else
            {
                Console.WriteLine("\nAz elem már létezik!");
            }
        }

        private static void CreateLigaMenu()
        {
            List<object> ligalist = new List<object>();
            Console.WriteLine("\n Írd be az új Liga nevét:");
            ligalist.Add(Console.ReadLine());
            Console.WriteLine("\n Írd be az új Liga régióját:");
            ligalist.Add(Console.ReadLine());
            Console.WriteLine("\n Írd be az új Liga stúdiójának helyét(opcionális):");
            ligalist.Add(Console.ReadLine());
            Console.WriteLine("\n Írd be az új Liga szezonjának kezdetét(opcionális):");
            string temp1 = Console.ReadLine();
            if (temp1 != string.Empty)
            {
                try
                {
                    ligalist.Add(DateTime.Parse(temp1));
                }
                catch (Exception ex)
                {
                    Console.Clear();
                    Console.WriteLine(ex.Message + "\nKezdje újra a feltöltést!");
                    return;
                }
            }
            else
            {
                ligalist.Add(null);
            }

            Console.WriteLine("\n Írd be az új Liga szezonjának végét(opcionális):");
            string temp2 = Console.ReadLine();
            if (temp2 != string.Empty)
            {
                try
                {
                    ligalist.Add(DateTime.Parse(temp2));
                }
                catch (Exception ex)
                {
                    Console.Clear();
                    Console.WriteLine(ex.Message + "\nKezdje újra a feltöltést!");
                    return;
                }
            }
            else
            {
                ligalist.Add(null);
            }

            Console.WriteLine("\n Írd be az új Liga csapatainak számát:");
            try
            {
                ligalist.Add(int.Parse(Console.ReadLine()));
            }
            catch (Exception ex)
            {
                Console.Clear();
                Console.WriteLine(ex.Message + "\nKezdje újra a feltöltést!");
                return;
            }

            if (ligaLogic.CreateLigaElement(ligalist))
            {
                Console.WriteLine("\nSikeres hozzáadás!");
            }
            else
            {
                Console.WriteLine("\nAz elem már létezik!");
            }
        }

        private static void ReadMenu()
        {
            Console.Clear();
            TableChoiceMenu();
            c = Console.ReadKey();
            Console.Clear();
            switch (c.Key)
            {
                case ConsoleKey.D1:
                    ReadLigaMenu();
                    Console.WriteLine("\nNyomj egy gombot, hogy visszakerülj a menübe!");
                    Console.ReadKey();
                    break;
                case ConsoleKey.D2:
                    ReadCsapatMenu();
                    Console.WriteLine("\nNyomj egy gombot, hogy visszakerülj a menübe!");
                    Console.ReadKey();
                    break;
                case ConsoleKey.D3:
                    ReadJatekosMenu();
                    Console.WriteLine("\nNyomj egy gombot, hogy visszakerülj a menübe!");
                    Console.ReadKey();
                    break;
                default:
                    Console.WriteLine("Ez a tábla nem található!");
                    Console.WriteLine("\nNyomj egy gombot, hogy visszakerülj a menübe!");
                    Console.ReadKey();
                    break;
            }
        }

        private static void ReadJatekosMenu()
        {
            Console.Clear();
            ReadChoiceMenu();
            c = Console.ReadKey();
            Console.Clear();
            switch (c.Key)
            {
                case ConsoleKey.D1:
                    Console.WriteLine(jatekosLogic.GetJatekosData());
                    break;
                case ConsoleKey.D2:
                    Console.WriteLine("Írj be egy létező felhasználónevet:");
                    Console.Clear();
                    Console.WriteLine(jatekosLogic.GetSingleJatekosData(Console.ReadLine()));
                    break;
                default:
                    Console.WriteLine("Nem jó opció!");
                    break;
            }
        }

        private static void ReadCsapatMenu()
        {
            Console.Clear();
            ReadChoiceMenu();
            c = Console.ReadKey();
            Console.Clear();
            switch (c.Key)
            {
                case ConsoleKey.D1:
                    Console.WriteLine(csapatLogic.GetCsapatData());
                    break;
                case ConsoleKey.D2:
                    Console.WriteLine("Írj be egy létező csapatnevet:");
                    Console.Clear();
                    Console.WriteLine(csapatLogic.GetSingleCsapatData(Console.ReadLine()));
                    break;
                default:
                    Console.WriteLine("Nem jó opció!");
                    break;
            }
        }

        private static void ReadLigaMenu()
        {
            Console.Clear();
            ReadChoiceMenu();
            c = Console.ReadKey();
            Console.Clear();
            switch (c.Key)
            {
                case ConsoleKey.D1:
                    Console.WriteLine(ligaLogic.GetLigaData());
                    break;
                case ConsoleKey.D2:
                    Console.WriteLine("Írj be egy létező liganevet:");
                    Console.Clear();
                    Console.WriteLine(ligaLogic.GetSingleLigaData(Console.ReadLine()));
                    break;
                default:
                    Console.WriteLine("Nem jó opció!");
                    break;
            }
        }

        private static void TableChoiceMenu()
        {
            Console.WriteLine("-------------------------------------------------");
            Console.WriteLine("\n Válasz ki melyik táblával szeretnél dolgozni -");
            Console.WriteLine("\n - 1 - Liga                                   -");
            Console.WriteLine("\n - 2 - Csapat                                 -");
            Console.WriteLine("\n - 3 - Játékos                                -");
            Console.WriteLine("\n-------------------------------------------------");
        }

        private static void ReadChoiceMenu()
        {
            Console.WriteLine("-------------------------------------------------");
            Console.WriteLine("\n Válasz ki mit szeretnél kiírni               -");
            Console.WriteLine("\n - 1 - Egész tábla                            -");
            Console.WriteLine("\n - 2 - Egy elem                               -");
            Console.WriteLine("\n-------------------------------------------------");
        }

        private static void MainMenu()
        {
            Console.WriteLine("-------------------------------------------------");
            Console.WriteLine("\n- 1 - Tábla - Tábla/Mező Kiolvasás            -");
            Console.WriteLine("\n- 2 - Tábla - Új mező hozzádás                -");
            Console.WriteLine("\n- 3 - Tábla - Létező mező módosítás           -");
            Console.WriteLine("\n- 4 - Tábla - Létező mező törlés              -");
            Console.WriteLine("\n- 5 - Játékos részletes információ            -");
            Console.WriteLine("\n- 6 - Új meccs létrehozása                    -");
            Console.WriteLine("\n- 7 - Játékosok száma / Nemzetiség            -");
            Console.WriteLine("\n- 8 - Online Adatbázis                        -");
            Console.WriteLine("\n- 9 - Játékos generálás - Java végpont        -");
            Console.WriteLine("\n- Esc - Kilépés                               -");
            Console.WriteLine("\n-------------------------------------------------");
        }
    }
}
