using System;
using System.Threading;
using System.Threading.Tasks;

namespace DiningPhilsWPF
{
    public class Philosopher
    {
        private Fork LeftFork;
        private Fork RightFork;
        public int Id { get; set; }
        public string Name { get; set; }
        public Philosopher(string name, Fork leftFork, Fork rightFork)
        {
            Name = name;
            LeftFork = leftFork;
            RightFork = rightFork;
           
        }
        private PhilosopherMode mode;
        public PhilosopherMode Mode
        {
            get
            {
                return mode;
            }
            set
            {
                mode= value;
                RaiseModeChangedEvent(Mode);

            }
        }



        public event EventHandler<ModeChangedEventArgs> ModeChangedEvent;

        public void RaiseModeChangedEvent(PhilosopherMode mode)
        {
            
            ModeChangedEvent?.Invoke(this, new ModeChangedEventArgs(mode));
        }

        public async Task StartAsync(Random random, CancellationToken ct)
        {
            bool isEating = false;

            // the 'while' loop ends when the cancellation token cancels Task.Delay
            //and a TaskCanceledException is thrown
            while (true)
            {
                Mode=PhilosopherMode.Thinking;
                int thinkingTime = random.Next(Constants.ThinkingMin, Constants.ThinkingMax);
                int eatingTime = random.Next(Constants.EatingMin, Constants.EatingMax);
                //asynchronous wait  until thinking time has passed
                await Task.Delay(TimeSpan.FromSeconds(thinkingTime), ct);
                Mode=PhilosopherMode.Hungry;
                while (!isEating)
                {
                    //monitor the two forks every few millisecs to see if they are in use
                    await Task.Delay(Constants.MonitoringIntervalMilliSecs, ct);
                    //if the forks are not in use, grab them and start eating
                    if (LeftFork.IsNotInUse && RightFork.IsNotInUse)
                    {
                        LeftFork.IsNotInUse = false;
                        RightFork.IsNotInUse = false;
                        isEating = true;
                    }

                }
                 Mode=PhilosopherMode.Eating;
                 await Task.Delay(TimeSpan.FromSeconds(eatingTime), ct);
                //when the eating time has passed, put down the forks and stop eating
                LeftFork.IsNotInUse = true;
                RightFork.IsNotInUse = true;
                isEating = false;
            }
        }
    }
}
