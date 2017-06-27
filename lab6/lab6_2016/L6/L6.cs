
using System.Collections.Generic;

namespace L6
{
    public class L6
    {
        Race _Race;
        public List<Building> Buildings = new List<Building>();
        public List<Unit> Units = new List<Unit>();

    // uzupełnić

        public void SetRace(Race race)
        {
            if (race.GetType() == typeof(Race))
            {
                this._Race = race;
            }
        }

        public bool? AddBuilding(Building build)
        {
            if ( this._Race == null || build.GetType() != typeof(Building) || /*!( this._Race.Equals((Race)build) )*/ this._Race.Name != build.GetRaceName() )
            {
                return null;
            }
            return AddBuildingIgnoreConstraints(build);
        }

        public bool AddBuildingIgnoreConstraints(Building build)
        {
            for (int i = 0; i < this.Buildings.Count; ++i)
            {
                if (this.Buildings[i].Equals(build))
                {
                    return false;
                }
            }
            this.Buildings.Add(build);
            return true;
        }

        public bool? AddUnit(Unit un)
        {
            bool found = false;
            if (un == null || this._Race == null || un.GetType() != typeof(Unit) || this._Race.Name != un.GetRaceName())
            {
                return null;
            }
            for (int i = 0; i < this.Buildings.Count; ++i)
            {
                if (this.Buildings[i].Name == un.GetBuildingName())
                {
                    found = true;
                }
            }
            if (!found)
            {
                return null;
            }
            return AddUnitIgnoreConstraints(un);
        }

        public bool AddUnitIgnoreConstraints(Unit un)
        {
            for (int i = 0; i < this.Units.Count; ++i)
            {
                if (this.Units[i].Equals(un))
                {
                    return false;
                }
            }
            this.Units.Add(un);
            return true;
        }

        public bool? AreUnitsSameRace()
        {
            if (this.Units.Count == 0) return null;
            if (this.Units.Count == 1) return true;
            for (int i = 0; i < this.Units.Count-1; ++i)
            {
                if (this.Units[i].GetRaceName() != this.Units[i+1].GetRaceName())
                {
                    return false;
                }
            }
            return true;
        }

    }
}
