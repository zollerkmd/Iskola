using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace Iskola
{
	class Program
	{
        static List<VersenyClass> lista_Verseny = new List<VersenyClass>();        
        static string fajlnev = "versenyek.txt";
        static int srsz;

        // 2. feladat OK
        static void Beker() {
            srsz = lista_Verseny.Count;
            //Console.WriteLine(srsz);
            //Console.ReadKey();
            string benev = "a";
            while (benev != "") {
                Console.Clear();
                Console.WriteLine("==========   A D A T O K   B E K É R É S E   ==========");
                Console.WriteLine("2. feladat:");
                Console.WriteLine("Kérem a versenyző nevét (Üres jelre kilép)!");
                benev = Console.ReadLine();

                if (benev == "") {
                    Console.WriteLine("Visszalépés főmenübe...");
                } else {
                    VersenyClass versenyzo = new VersenyClass();
                    versenyzo.nev = benev;

                    Console.WriteLine("Kérem a tantárgy nevét!");
                    versenyzo.tantargy = Console.ReadLine();

                    int beszazalek = 0;
                    int van = 0;

                    do {
                        Console.WriteLine("Kérem az elért százalékos eredményt (0-100)!");
                        beszazalek = Convert.ToInt32(Console.ReadLine());
                        if (beszazalek >= 0 || beszazalek <= 100) {
                            van = 1;
                        }
                    }
                    while (van != 1);
                    versenyzo.szazalek = beszazalek;
                    srsz++;
                    versenyzo.id = srsz;
                    Console.WriteLine("Versenyző azonosítója: " + Convert.ToString(versenyzo.id));
                    lista_Verseny.Add(versenyzo);
                    Console.ReadKey();

                }

            }
            // Lista kiiratása
            Console.WriteLine("Lista elemeinek kiiratása: ");
            foreach (VersenyClass a in lista_Verseny) {
                Console.WriteLine(Convert.ToString(a.id) + "\t" + a.nev + "\t" + a.tantargy + "\t" + Convert.ToString(a.szazalek));
            }

            Console.Write("\nVisszalépés főmenübe...");
            Console.ReadKey();
            Fomenu();
        }

        // 3. feladat OK
        static void ListaDarabszama() {
            Console.Clear();
            Console.WriteLine("==========   L I S T A     D A R A B S Z Á M A   ==========");
            Console.WriteLine("3. feladat:");
            Console.WriteLine("Határozza meg és írja ki a képernyőre, hogy hány diák adatai kerültek rögzítésre!");

            Console.WriteLine("Rögzített diákok száma: " + Convert.ToString(lista_Verseny.Count));

            Console.Write("\nVisszalépés főmenübe...");
            Console.ReadKey();
            Fomenu();
        }

        // 4. feladat OK
        static void ListaAtlag() {
            Console.Clear();
            Console.WriteLine("==========   L I S T A     Á T L A G A   ==========");
            Console.WriteLine("4. feladat:");
            Console.WriteLine("!");

            int osszeg = 0;
            foreach (VersenyClass a in lista_Verseny) {
                osszeg = osszeg + a.szazalek;
			}
			Console.WriteLine(osszeg);
			Console.WriteLine(lista_Verseny.Count);
            double atlag = osszeg / lista_Verseny.Count;
            double atlag2 = Math.Round(value: atlag, digits: 1);

            //Console.WriteLine("Elért átlagos százalék: " + (osszeg / lista_Verseny.Count) + "\t" + Convert.ToString(atlag) + "\t");
            string strAtlag = String.Format("A tanulók elért százalákos eredménye {0:N1}% volt.", atlag2);
			Console.WriteLine(strAtlag);

            Console.Write("\nVisszalépés főmenübe...");
            Console.ReadKey();
            Fomenu();
        }

        // 5. feladat OK
        static void LegrosszabbEredmeny() {
            int min = 100;
            int minhely = 0;
            Console.Clear();
            Console.WriteLine("==========     L E G K I S E B B     E L É R T     S Z Á Z A L É K     ==========");
            Console.WriteLine("5. feladat:");
            Console.WriteLine("!");

            for (int i = 0; i < lista_Verseny.Count; i++) {
                if (lista_Verseny[i].szazalek < min) {
                    min = lista_Verseny[i].szazalek;
                    minhely = i;
                }
            }
            Console.WriteLine(Convert.ToString(lista_Verseny[minhely].id) + "\t" + lista_Verseny[minhely].nev + "\t" + lista_Verseny[minhely].tantargy + "\t" + Convert.ToString(lista_Verseny[minhely].szazalek));

            Console.Write("\nVisszalépés főmenübe...");
            Console.ReadKey();
            Fomenu();
        }

        // 6. feladat OK
        static void ListaKiiratasa() {
            Console.Clear();
            Console.WriteLine("==========   L I S T A     K I I R A T Á S A   ==========");
            Console.WriteLine("6. feladat:");
            Console.WriteLine("Azonosítóval jelenítse meg a rögzített adatokat versenyzőkként külön sorban, pontosvesszővel elválasztva!");

            // Lista kiiratása
            Console.WriteLine("Lista elemeinek kiiratása: ");
            foreach (VersenyClass a in lista_Verseny) {
                Console.WriteLine(Convert.ToString(a.id) + ";" + a.nev + ";" + a.tantargy + ";" + Convert.ToString(a.szazalek));
            }

            Console.Write("\nVisszalépés főmenübe...");
            Console.ReadKey();
            Fomenu();
        }

        // 7. feldat OK
        static void Fajlbair() {
            Console.Clear();
            Console.WriteLine("\n==========   F Á J L B A   Í R Á S   ==========");
            Console.WriteLine("7. feladat:");
            Console.WriteLine("Készítsen új UTF-8 kódolású állományt versenyek.txt néven a versenyzők adataiból!");
            StreamWriter kiir = new StreamWriter(fajlnev);
            // Lista kiiratása fájlba
            Console.WriteLine("Lista elemeinek kiírása fájlba... ");
            foreach (VersenyClass a in lista_Verseny) {
                kiir.WriteLine(Convert.ToString(a.id) + ";" + a.nev + ";" + a.tantargy + ";" + Convert.ToString(a.szazalek));
            }
            kiir.Flush();
            kiir.Close();

            Console.Write("\nVisszalépés főmenübe...");
            Console.ReadKey();
            Fomenu();
        }

        // 8. feladat OK
        static void f8() {
            Console.Clear();
            Console.WriteLine("==========     T A N T Á R G Y A K     É S     S Z Á M A     ==========");
            Console.WriteLine("8. feladat:");
            Console.WriteLine("Határozza meg milyen különböző tantárgyakból versenyeztek a diákok, és a tantárgyak előfordulásának számát is.");

            List<TantargyakClass> lista_tantargyak = new List<TantargyakClass>();           

            for (int i = 0; i < lista_Verseny.Count; i++) {
                for (int j = 0; j < lista_tantargyak.Count; j++) {
                    if (lista_Verseny[i].tantargy == lista_tantargyak[j].tantargy) {
                        lista_tantargyak[j].darab++;
					} else {
                        TantargyakClass tantargyak = new TantargyakClass();
                        tantargyak.tantargy = lista_Verseny[i].tantargy;
                        tantargyak.darab = 1;
                        lista_tantargyak.Add(tantargyak);
					}
				}
			}

            Console.Write("\nVisszalépés főmenübe...");
            Console.ReadKey();
            Fomenu();
        }

        // 9. feladat OK
        static void Buborek() {
            Console.Clear();
            Console.WriteLine("==========     B U B O R É K     ==========");
            Console.WriteLine("9. feladat:");
            Console.WriteLine("!");

            for (int i = lista_Verseny.Count - 1; i >= 0; i--) {
                for (int j = 0; j < i; j++) {
                    if (lista_Verseny[j].szazalek > lista_Verseny[j + 1].szazalek) {
                        int temp = lista_Verseny[j].szazalek;
                        lista_Verseny[j].szazalek = lista_Verseny[j + 1].szazalek;
                        lista_Verseny[j + 1].szazalek = temp;
                    }
                }
            }

            // Lista kiiratása
            Console.WriteLine("Lista elemeinek kiiratása: ");
            foreach (VersenyClass a in lista_Verseny) {
                Console.WriteLine(Convert.ToString(a.szazalek));
            }

            Console.Write("\nVisszalépés főmenübe...");
            Console.ReadKey();
            Fomenu();
        }

        // 10. feladat OK
        static void Fajlbolbe() {
            Console.Clear();
            Console.WriteLine("\n==========   F Á J L B Ó L   B E O L V A S Á S   ==========");
            Console.WriteLine("10. feladat:");
            StreamReader beolvas = new StreamReader(fajlnev, Encoding.UTF8);
            Console.WriteLine("Lista elemeinek beolvasása fájlból... ");
            // IDE JÖN A BEOLVASÁS
            string s;
            var egyeblista = new List<string[]>();

            while ((s = beolvas.ReadLine()) != null) {
                Console.WriteLine(Convert.ToString(s));
                egyeblista.Add(s.Split(';'));
            }

            foreach (string[] a in egyeblista) {
                //Console.WriteLine(a);
                VersenyClass versenyzo = new VersenyClass();
                versenyzo.id = Convert.ToInt32(a[0]);
                versenyzo.nev = a[1];
                versenyzo.tantargy = a[2];
                versenyzo.szazalek = Convert.ToInt32(a[3]);
                lista_Verseny.Add(versenyzo);
            }

            // BEOLVASÁS VÉGE
            beolvas.Close();


            Console.Write("\nVisszalépés főmenübe...");
            Console.ReadKey();
            Fomenu();
        }

        //11. feladat OK
        static void KeresesDiak() {
            Console.Clear();
            Console.WriteLine("==========   K E R E S É S     D I Á K R A   ==========");
            Console.WriteLine("11. feladat:");
            Console.WriteLine("!");

            Console.Write("Kérem a keresendő diák nevét! ");
            string keres_nev = Console.ReadLine();
            bool megvan = false;
            int hely = 0;

            for (int i = 0; i < lista_Verseny.Count; i++) {
                if (keres_nev == lista_Verseny[i].nev) {
                    megvan = true;
                    hely = i;
                }
            }

            if (megvan == true) {
                Console.WriteLine("Megvan!");
                Console.WriteLine(Convert.ToString(lista_Verseny[hely].id) + "\t" + lista_Verseny[hely].nev + "\t" + lista_Verseny[hely].tantargy + "\t" + Convert.ToString(lista_Verseny[hely].szazalek));
            } else {
                Console.WriteLine("Nincs ilyen nevű diák!");
            }

            Console.Write("\nVisszalépés főmenübe...");
            Console.ReadKey();
            Fomenu();
        }

        // 12. feladat OK
        static void KeresesTantargy() {
            Console.Clear();
            Console.WriteLine("==========   K E R E S É S     T A N T Á R G Y R A   ==========");
            Console.WriteLine("12. feladat:");
            Console.WriteLine("!");

            Console.Write("Kérem a keresendő tantárgy nevét! ");
            string keres_tantargy = Console.ReadLine();
            bool megvan = false;
            int hely = 0;
            List<VersenyClass> lista_tantargy = new List<VersenyClass>();
            

            for (int i = 0; i < lista_Verseny.Count; i++) {
                if (keres_tantargy == lista_Verseny[i].tantargy) {
                    megvan = true;
                    VersenyClass tantargydiak = new VersenyClass();
                    //hely = i;
                    tantargydiak.id = lista_Verseny[i].id;
                    tantargydiak.nev = lista_Verseny[i].nev;
                    tantargydiak.tantargy = lista_Verseny[i].tantargy;
                    tantargydiak.szazalek = lista_Verseny[i].szazalek;
                    lista_tantargy.Add(tantargydiak);
                }
            }

            if (megvan == true) {
                Console.WriteLine("Megvan!");
                // Lista kiiratása
                Console.WriteLine("Lista elemeinek kiiratása: ");
                foreach (VersenyClass a in lista_tantargy) {
                    Console.WriteLine(Convert.ToString(a.id) + ";" + a.nev + ";" + a.tantargy + ";" + Convert.ToString(a.szazalek));
                }
            } else {
                Console.WriteLine("Nincs ilyen nevű tantárgy!");
            }

            Console.Write("\nVisszalépés főmenübe...");
            Console.ReadKey();
            Fomenu();
        }

        // FŐMENÜ
        static void Fomenu() {
            Console.Clear();
            Console.WriteLine("==========   F Ő M E N Ű   ==========");
            Console.WriteLine("2., Adatok bekérése");
            Console.WriteLine("3., Lista darabszáma");
            Console.WriteLine("4., Versenyzők átlagos elért százaléka");
            Console.WriteLine("5., Legrosszabb eredmény");
            Console.WriteLine("6., Lista kiiratása");
            Console.WriteLine("7., Fájlba írás");
            Console.WriteLine("8., Tantárgyak előfordulása");
            Console.WriteLine("9., Buborék");
            Console.WriteLine("10., Fájlból betöltés");
            Console.WriteLine("11., Keresés diákra");
            Console.WriteLine("12., Keresés tantárgyra");
            Console.WriteLine("0., Kilépés");
            string menupont = Console.ReadLine();
            switch (Convert.ToInt32(menupont)) {
                case 2:
                    Beker();
                    break;
                case 3:
                    ListaDarabszama();
                    break;
                case 4:
                    ListaAtlag();
                    break;
                case 5:
                    LegrosszabbEredmeny();
                    break;
                case 6:
                    ListaKiiratasa();
                    break;
                case 7:
                    Fajlbair();
                    break;
                case 8:
                    f8();
                    break;
                case 9:
                    Buborek();
                    break;
                case 10:
                    Fajlbolbe();
                    break;
                case 11:
                    KeresesDiak();
                    break;
                case 12:
                    KeresesTantargy();
                    break;
                case 0:
                    return;
                default:
                    return;
            }
        }
		static void Main(string[] args) {
			Fomenu();
		}
	}
}
