using System;

namespace PO_Events
{
	class Program
	{
		static void Main()
		{
			// ETAP1
            Console.WriteLine("ETAP 1");
            var outer = new Matryoshka("Outer");
            outer.Color = "Red";
            outer.Theme = "Traditional";

            Console.WriteLine("Do tej pory nie powinno się nic wypisać \n");

            var simpleWatcher = new SimpleWatcher();
            simpleWatcher.Watch(outer);

            Console.WriteLine("-------------------------------");

            outer.Color = "Blue";
            outer.Theme = "Politics";

            // ETAP2
            Console.WriteLine("ETAP 2");
            var smartWatcher = new SmartWatcher();
            smartWatcher.Watch(outer);

            Console.WriteLine("-------------------------------");

            outer.Color = "Blue";
            outer.Theme = "Politics";

            simpleWatcher.StopWatching(outer);

            // ETAP3
            Console.WriteLine("ETAP 3");
            var firstLevel = new Matryoshka("First Inner Level");

            outer.InnerDoll = firstLevel;
            Console.WriteLine("-------------------------------");

            firstLevel.Color = "Red";

            Console.WriteLine("-------------------------------");

            smartWatcher.Watch(firstLevel);

            firstLevel.Theme = "Traditional";

            Console.WriteLine("-------------------------------");

            var secondLevel = new Matryoshka("Second Inner Level");

            outer.InnerDoll.InnerDoll = secondLevel;
            Console.WriteLine("-------------------------------");

            secondLevel.Color = "Red";

            Console.WriteLine("-------------------------------");

            smartWatcher.Watch(secondLevel);

            secondLevel.Theme = "Traditional";
            Console.WriteLine("-------------------------------");

            var firstLevel2 = new Matryoshka("First Inner Level2");

            outer.InnerDoll = firstLevel2;
            Console.WriteLine("-------------------------------");

            firstLevel.Color = "Blue";

            Console.WriteLine("-------------------------------");
            firstLevel2.Color = "Blue";

            smartWatcher.Watch(firstLevel2);
            Console.WriteLine("-------------------------------");

            firstLevel2.Theme = "Political";

            Console.WriteLine("-------------------------------");
            outer.InnerDoll = null;
            firstLevel.Color = "Green";
            firstLevel2.Color = "Green";

        }
	}

    public class NotifyEventArgs : EventArgs
    {
        public NotifyEventArgs(string propertyName)
        {
            this.PropertyName = propertyName;
        }
        public string PropertyName { get; private set; }
    }

	public interface IChangeNotifing
	{
		string Name { get; }
        event EventHandler<NotifyEventArgs> Changed;
	}
}
