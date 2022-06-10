using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DiningPhilsWPF
{
    public class Fork
    {
        public int Id { get; set; }
        private bool isNotInUse;
        public bool IsNotInUse
        {
            get
            {
                return isNotInUse;
            }
            set
            {
                isNotInUse = value;
                RaiseIsInUseChangedEvent(isNotInUse);
            }
        }
        public Fork(int id)
        {
            Id = id;
            IsNotInUse = true;
        }
        public event EventHandler<IsInUseChangedEventArgs> IsInUseChangedEvent;

        public void RaiseIsInUseChangedEvent(bool isNotUsed)
        {
            // Copy to a temporary variable to be thread-safe.
            IsInUseChangedEvent?.Invoke(this, new IsInUseChangedEventArgs(isNotUsed));
        }
    }
}
