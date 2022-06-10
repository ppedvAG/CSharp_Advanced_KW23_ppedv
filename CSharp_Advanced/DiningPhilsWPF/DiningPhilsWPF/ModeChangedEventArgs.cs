using System;

namespace DiningPhilsWPF
{
    public class ModeChangedEventArgs : EventArgs
    {


        public ModeChangedEventArgs(PhilosopherMode mode, string msg = null)
        {
            message = msg;
            philMode = mode;
        }
        private string message;
        public string Message
        {
            get { return message; }
            set { message = value; }
        }
        private PhilosopherMode philMode;
 public PhilosopherMode PhilMode
        {
            get { return philMode; }
            set { philMode = value; }
        }
    }

}
