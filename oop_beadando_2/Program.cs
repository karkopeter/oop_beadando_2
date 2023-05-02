using System;
using System.Linq;
using System.Collections.Generic;

namespace oop_beadando_2
{
    internal class Program
    {
        static void Main(string[] args)
        {
            horgaszverseny horgaszverseny = new();
            Caches caches = new Caches();

            Console.WriteLine("Filenév:");

            while (!horgaszverseny.IsFileOpen())
            {
                try
                {
                    string? ln = Console.ReadLine();

                    if (ln == null)
                    {
                        continue;
                    }

                    horgaszverseny.OpenFile(ln);
                }
                catch (Exception)
                {
                    Console.WriteLine("Hibás fájlnév!");
                }
            }

            horgaszverseny.Start();


            string MostCarp = "Ponty";
            string Comp = "";
            double FishWeight = 0;
            string BiggestCarpCompetitor = "";
            string MostFishCompetitor = "";

            while (horgaszverseny.HasNext())
            {
                horgaszverseny.Next();
                
                // a
                if (caches.FishWeight.Max() > FishWeight)
                {
                    FishWeight = caches.FishWeight.Max();
                    Comp = horgaszverseny.Id;
                    BiggestCarpCompetitor = horgaszverseny.Name;
                }

                //b

                Dictionary<string, double> counts = new Dictionary<string, double>();

                foreach(string fish in caches.FishName)
                {
                    if (counts.ContainsKey(fish))
                    {
                        counts[fish]++;
                    }
                    else
                    {
                        counts[fish] = 1;
                    }
                }
                double maxCount = 0;
                string maxFish = "";

                foreach (var pair in counts)
                {
                    if (pair.Value > maxCount)
                    {
                        maxCount = pair.Value;
                        maxFish = pair.Key;
                    }
                }

                if(MostCarp == maxFish)
                {
                    MostFishCompetitor = horgaszverseny.Name;
                }
            }

           
            Console.WriteLine("Legnehezebb ponty súlya: " + FishWeight);
            Console.WriteLine("Verseny: " + Comp + " versenyző: " + BiggestCarpCompetitor);
            Console.WriteLine("Legtöbb ponty: " + MostCarp + " kifogta: " + MostFishCompetitor);
            Console.WriteLine("Kész");
        }
    }
}