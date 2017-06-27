using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab11a
{
    class DollFactory: IToyFactory
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
            if (arg.PresentType == "Doll")
            {
                Console.WriteLine("Doll Factory: Building toy: {0}", arg.PresentName);
                return true;
            }
            return false;
        }
    }
}
