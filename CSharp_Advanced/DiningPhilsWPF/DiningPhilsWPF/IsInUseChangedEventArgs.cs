using System;

namespace DiningPhilsWPF
{
    public class IsInUseChangedEventArgs : EventArgs
    {


        public IsInUseChangedEventArgs(bool isNotBeingUsed, string msg = null)
        {
            message = msg;
            isNotInUse = isNotBeingUsed;
        }
        private string message;
        public string Message
        {
            get { return message; }
            set { message = value; }
        }
        private bool isNotInUse;
        public bool IsNotInUse
        {
            get { return isNotInUse; }
            set {
                isNotInUse = value;

            }
        }
    }
}
