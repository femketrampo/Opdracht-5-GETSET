using System;
using System.Collections;
using System.Collections.Generic;

namespace Opdracht_5
{
    class Program
    {
        static void Main(string[] args)
        {
            List<object> Leerlingen = new List<object>();
            int keuze;
            string antwoord;

            do
            {
                Console.Clear();
                Console.ForegroundColor = ConsoleColor.Blue;

                Console.WriteLine("1) Nieuwe leerling toevoegen");
                Console.WriteLine("2) Leerling verwijderen");
                Console.WriteLine("3) Puntenlijst");
                Console.WriteLine("4) Exit");
                Console.Write("keuze: ");
                keuze = Convert.ToInt32(Console.ReadLine());

                if (keuze <= 4)
                {
                    switch (keuze)
                    {
                        case 1:
                            {
                                do
                                {
                                    Leerlingen.Add(Toevoegen());

                                    Console.Write("Wilt u nog een leerling toevoegen?(J/N) ");
                                    antwoord = Console.ReadLine();
                                } while (antwoord.ToUpper() == "J");
                            }
                            break;
                        case 2:
                            {
                                do
                                {
                                    Verwijderen(Leerlingen);

                                    Console.Write("Wilt u nog een leerling verwijderen?(J/N) ");
                                    antwoord = Console.ReadLine();
                                } while (antwoord.ToUpper() == "j");
                            }
                            break;
                        case 3:
                            {
                                Puntenlijst(Leerlingen);
                                Console.ReadLine();
                            }
                            break;
                    }
                }
                else
                {
                    Console.Clear();
                    Console.ForegroundColor = ConsoleColor.DarkRed;

                    Console.WriteLine("Dit is geen geldige optie!");
                    Console.ReadLine();
                }
            } while (keuze != 4);
        }

        private static object Toevoegen()
        {
            Console.Clear();

            Resultaat resultaat = new Resultaat();

            Console.Write("Geef de naam in: ");
            resultaat.Naam = Console.ReadLine();
            Console.Write("Geef het percentage voor Nederlands in: ");
            resultaat.Nederlands = Convert.ToDouble(Console.ReadLine());
            Console.Write("Geef het percentage voor Frans in: ");
            resultaat.Frans = Convert.ToDouble(Console.ReadLine());
            Console.Write("Geef het percentage voor Engels in: ");
            resultaat.Engels = Convert.ToDouble(Console.ReadLine());

            return resultaat;
        }
        private static void Verwijderen(List<object> leerlingen)
        {
            Console.Clear();

            int nummer;

            Console.WriteLine("Er zijn {0} leerlingen ingegeven.", leerlingen.Count);
            Console.Write("Welke leerling wilt u verwijderen? ");
            nummer = Convert.ToInt32(Console.ReadLine());

            leerlingen.RemoveAt(nummer - 1);
        }
        private static void Puntenlijst(List<object> Leerlingen)
        {
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.Green;

            int Teller = 1;
            string StrResultaat;

            Console.WriteLine("-|2021-2022|-");

            foreach (Resultaat resultaat in Leerlingen)
            {
                double Gemiddelde = (resultaat.Nederlands + resultaat.Frans + resultaat.Engels) / 3;

                if (Gemiddelde >= 85)
                {
                    StrResultaat = "Grootste onderscheiding";
                }
                else if (Gemiddelde >= 75)
                {
                    StrResultaat = "Grote onderscheiding";
                }
                else if (Gemiddelde >= 68)
                {
                    StrResultaat = "Onderscheiding";
                }
                else if (Gemiddelde >= 50)
                {
                    StrResultaat = "Voldoende";
                }
                else
                {
                    StrResultaat = "Niet geslaagd";
                }

                if (StrResultaat == "Niet geslaagd")
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                }
                else if (StrResultaat == "Voldoende")
                {
                    Console.ForegroundColor = ConsoleColor.DarkYellow;
                }

                Console.WriteLine();
                Console.WriteLine(Teller + ": {0}", resultaat.Naam);
                Console.WriteLine("\n\t- Nederlands: {0}%\tFrans: {1}%\tEngels: {2}%", resultaat.Nederlands, resultaat.Frans, resultaat.Engels);
                Console.WriteLine("\n   Resultaat: {0}\tGemiddelde: {1}%\n\n", StrResultaat, Math.Round(Gemiddelde, 2));

                Teller++;
            }
        }
    }
}