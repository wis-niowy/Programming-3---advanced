
namespace L6
{
    public class Unit : Building
    {
        new public readonly string Name;

    // uzupełnić

        public Unit(string Name, string Building, string _Race): base(Building, _Race)
        {
            this.Name = Name;
        }

        public string GetBuildingName()
        {
            return base.Name;
        }

        public override int GetHashCode()
        {
            return Name.GetHashCode();
        }

        public override bool Equals(object obj)
        {
            return (obj.GetType() == this.GetType() && base.Equals(obj) && ((Unit)obj).Name == this.Name);
        }
    }
}
