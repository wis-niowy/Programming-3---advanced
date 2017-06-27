using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab11a
{
    class UnstableToyFactory: IToyFactory
    {
        public void BindToPostOffice(SantaPostOffice spo)
        {
            spo.MailArrived += this.ServiceEvent;
        }
        public void UnbindFromPostOffice(SantaPostOffice spo)
        {
            spo.MailArrived -= this.ServiceEvent;
        }

        public bool ServiceEvent(Message arg)
        {
            Random rand = new Random();
            int val = rand.Next();
            if (val % 2 == 0)
            {
                Console.WriteLine("UnstableToyFactory: Building toy: {0}", arg.PresentName);
                return true;
            }
            return false;
        }
    }
}
