using System;
using System.Collections.Generic;
using System.Linq;

namespace L14
{
    class Program
    {
        static void Main(string[] args)
        {
            List<Race> races = new List<Race>();
            List<Building> buildings = new List<Building>();
            List<Unit> units = new List<Unit>();

            //Filling data
            races.Add(new Race(0, "Ork"));
            races.Add(new Race(1, "Space Marine"));
            races.Add(new Race(2, "Imperial Guard"));

            buildings.Add(new Building(0, "Stronghold", 0, 400, -1, 1));
            buildings.Add(new Building(1, "Plasma Generator", 0, 100, 0, 1));
            buildings.Add(new Building(2, "Chapel-Barracks", 0, 250, 0, 1));
            buildings.Add(new Building(3, "Armoury", 25, 150, 2, 1));
            buildings.Add(new Building(4, "Machine Cult", 150, 250, 2, 1));
            buildings.Add(new Building(5, "Settlement", 0, 400, -1, 0));
            buildings.Add(new Building(6, "Da Boyz Hut", 0, 250, 5, 0));
            buildings.Add(new Building(7, "Waaagh! Banner", 0, 125, 5, 0));
            buildings.Add(new Building(8, "Da Mek Shop", 250, 125, 6, 0));
            buildings.Add(new Building(9, "Pile O Gunz!", 125, 25, 6, 0));

            units.Add(new Unit(0, "Servitor", 0, 50, 0, 1));
            units.Add(new Unit(1, "Space Marine", 0, 50, 2, 1));
            units.Add(new Unit(2, "Grey Knights", 50, 50, 2, 1));
            units.Add(new Unit(3, "Rhino Transport", 150, 150, 4, 1));
            units.Add(new Unit(4, "Dreadnought ", 125, 350, 4, 1));
            units.Add(new Unit(5, "Chaplain", 100, 150, 2, 1));
            units.Add(new Unit(6, "Ork Boyz", 0, 50, 6, 0));
            units.Add(new Unit(7, "Mad Dok", 50, 150, 6, 0));
            units.Add(new Unit(8, "Killa Kan", 150, 150, 8, 0));
            units.Add(new Unit(9, "Gretchin", 0, 25, 5, 0));

            Console.WriteLine("\n-> ETAP 1 (0.5 pkt.)\n");
            // Napisz zapytanie które zwróci listę z nazwami jednostek dla rasy "Ork" (w wynikach są tylko nazwy jednostek)

            var orcUnits = from p in units
                           join rc in races on p.RaceId equals rc.Id
                           where rc.Name == "Ork"
                           select p.Name;
            print(orcUnits);

            Console.WriteLine("\n-> ETAP 2 (1.0 pkt.)\n");
            // Napisz zapytanie które zwróci listę nazw jednostek dla rasy "Ork", wraz z nazwą budynku oraz kosztem budowy jednostki (gaz i minerały)

            var orcUnitsWithBuildings = from p in units
                                        where p.RaceId == 0
                                        join bd in buildings on p.BuildingId equals bd.Id 
                                        select new { p.Name , BdName = bd.Name, p.CostGas, p.CostMinerals };
            print(orcUnitsWithBuildings);

            Console.WriteLine("\n-> ETAP 3 (1.0 pkt.)\n");
            // Napisz zapytanie które zwróci listę nazw jednostek wraz z nazwą budynku którego wymagają, tylko dla budyków które wymagają innego budynku do wybudowania
            // (budynki nie wymagające innego bydynku pomijamy)

            var unitsWithBuildingsWithRequirements = from un in units
                                                     join bd in buildings on un.BuildingId equals bd.Id
                                                     where bd.BuildingId != -1
                                                     select new { un.Name, BuildingName = bd.Name };
            print(unitsWithBuildingsWithRequirements);

            Console.WriteLine("\n-> ETAP 4 (1.0 pkt.)\n");
            // Napisz zapytanie które zwróci liczbę różnych rodzajów jednostek zgrupowanych po konkretnym koszcie

            var unitCountByBuildingByCost = from un in units
                                            group un by new { un.CostGas, un.CostMinerals } into unGroupus
                                            select new { unGroupus.Key.CostGas, unGroupus.Key.CostMinerals, Count = unGroupus.Count() };
            print(unitCountByBuildingByCost);

            Console.WriteLine("\n-> ETAP 5 (1.5 pkt.)\n");
            // Napisz zapytanie które zwróci całkowity koszt budynków które należy wybudować (zaczynamy bez ani jednego budynku wybudowanego),
            // aby móc wybudować budynek "Machine Cult" (wraz z kosztem "Machine Cult")

            var unitRequiredBuildingsTotalCost = from 
            // print(unitRequiredBuildingsTotalCost);

            Console.WriteLine("\n-> KONIEC\n");
        }

        public static void print(System.Collections.IEnumerable data)
        {
            foreach (var t in data)
            {
                Console.WriteLine(t);
            }
        }

    }

    public static class EnumerableExtensions
    {

        public static IEnumerable<Building> SelectIterative(this IEnumerable<Building> source, int id)
        {
            Building b;
            List<Building> lb = new List<Building>();
            while ( id>=0 )
                {
                b = (from s in source where s.Id==id select s).Single();
                lb.Add(b);
                id=b.BuildingId;
                }
            return lb;
        }

    }

}
