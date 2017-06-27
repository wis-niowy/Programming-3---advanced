using System;

namespace Lab11a
{
	public class SantaPostOffice
	{
        //TU napisać zdarzenie i ew. metody pomocniczne

        public event Func<Message, bool> MailArrived;


		public void ReceiveMessage(Message message)
        {
            bool check = false;
            if (MailArrived != null)
            {
                foreach (Func<Message, bool> fun in MailArrived.GetInvocationList())
                {
                    if ((check = fun(message))) break;
                }
            }
            if (!check)
            {
                Console.WriteLine("{0} {1}", this, message.ToString());
            }
		}
        public override string ToString()
        {
            return "Unhandled message ";
        }
    }
}

