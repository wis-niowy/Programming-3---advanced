
namespace L6
{
    public class Race
    {
        public readonly string Name;

        // uzupełnić

        public Race(string name)
        {
            this.Name = name;
        }

        public override int GetHashCode()
        {
            return Name.GetHashCode();
        }

        public override bool Equals(object obj)
        {
            return (obj.GetType() == this.GetType() && ((Race)obj).Name == this.Name);
        }
    }
        
}
