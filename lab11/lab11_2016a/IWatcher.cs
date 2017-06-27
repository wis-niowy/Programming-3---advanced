using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab11a
{
    class SimpleWatcher
    {
        public void Watch(IChangeNotifing arg)
        {
            arg.Changed += ServiceEvent;
        }

        public void StopWatching(IChangeNotifing arg)
        {
            arg.Changed -= ServiceEvent;
        }

        public void ServiceEvent(object sender, NotifyEventArgs args)
        {
            Console.WriteLine("Object changed");
        }
    }
}
