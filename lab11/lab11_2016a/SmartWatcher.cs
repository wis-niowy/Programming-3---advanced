using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab11a
{
    class SmartWatcher
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
            var send = sender as IChangeNotifing;
            Console.WriteLine("Object {0} changed property: {1}", send.Name, args.PropertyName);
        }

    }
}