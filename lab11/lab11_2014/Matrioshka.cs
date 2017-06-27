using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PO_Events
{
    class Matryoshka: IChangeNotifing
    {
        private String theme;
        private String color;
        private Matryoshka innerdoll;

        public event EventHandler<NotifyEventArgs> Changed;

        public Matryoshka(String arg)
        {
            this.Name = arg;
        }
        public String Name
        {
            get;
        }
        public String Theme
        {
            get
            {
                return theme;
            }
            set
            {
                theme = value;
                if (Changed != null)
                    Changed(this, new NotifyEventArgs("Theme"));
            }
        }
        public String Color
        {
            get
            {
                return color;
            }
            set
            {
                color = value;
                if(Changed != null)
                    Changed(this, new NotifyEventArgs("Color"));
            }
        }
        public Matryoshka InnerDoll
        {
            get
            {
                return innerdoll;
            }
            set
            {
                innerdoll = value;
                if (Changed != null)
                    Changed(this, new NotifyEventArgs("InnerDoll"));
            }
        }
   }
}
