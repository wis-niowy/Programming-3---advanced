
namespace L6
{
    public class Building : Race
    {
        new public readonly string Name;

    // uzupełnić
        public Building(string Name, string _Race): base(_Race)
        {
            this.Name = Name;
        }

        public string GetRaceName()
        {
            return base.Name;
        }

        public override int GetHashCode()
        {
            return Name.GetHashCode();
        }

        public override bool Equals(object obj)
        {
            return (obj.GetType() == this.GetType() && base.Equals(obj) && ((Building)obj).Name == this.Name);
        }
    }
}
