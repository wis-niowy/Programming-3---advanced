using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab11a
{
    class Matryoshka: IChangeNotifing
    {

        private String name;
        private String color;
        private String theme;
        private Matryoshka innerdoll;

        public event EventHandler<NotifyEventArgs> Changed;

        public Matryoshka(String arg)
        {
            this.Name = arg;
        }
        public String Name
        {
            get; set;
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
                if (Changed != null)
                    Changed(this, new NotifyEventArgs("Color"));
            }
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
        public Matryoshka InnerDoll
        {
            get
            {
                return innerdoll;
            }
            set
            {
                innerdoll = value;
                if (innerdoll != null) innerdoll.Changed -= ServiceInnerEvent;
                if (innerdoll != null) innerdoll.Changed += ServiceInnerEvent;
                if (Changed != null)
                    Changed(this, new NotifyEventArgs("InnerDoll"));
            }
        }

        public void ServiceInnerEvent(object sender, NotifyEventArgs args)
        {
            Console.WriteLine("InnerDoll.{0}", args.PropertyName);
        }
    }
}
