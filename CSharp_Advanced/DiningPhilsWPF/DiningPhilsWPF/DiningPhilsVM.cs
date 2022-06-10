using Prism.Commands;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Threading;
using System.Threading.Tasks;

namespace DiningPhilsWPF
{

    public class DiningPhilsVM : INotifyPropertyChanged
    {
        private Philosopher[] philosophers;
        private Fork[] forks;
        private CancellationTokenSource cts;

        public DelegateCommand<object> StartCommand { get; private set; }
        public DelegateCommand<object> CancelCommand { get; private set; }

        public DiningPhilsVM()
        {
            StartCommand = new DelegateCommand<object>(OnStartAsync, o => !isStarted);
            CancelCommand = new DelegateCommand<object>(OnCancel, o => isStarted);
            int numberOfPhils = Constants.PhilosopherCount;
            forks = new Fork[numberOfPhils];
            philosophers = new Philosopher[numberOfPhils];
            string[] names = Constants.PhilosophersNames.Split(',');

            for (int i = 0; i < numberOfPhils; i++)
            {
                forks[i] = new Fork(i);

            }
            for (int i = 0; i < numberOfPhils; i++)
            {
                Fork leftFork = forks[i];
                Fork rightFork = i == 0 ? forks[forks.Length - 1] : forks[i - 1];
                leftFork.IsNotInUse = true;
                philosophers[i] = new Philosopher(names[i], leftFork, rightFork);
            }
            SubscribeToForkInUseChangedEvents();
            SubscribeToModeChangedEvents();
            InitialisePhilsMode();
            InitialiseForks();
        }



        #region Subscribe To Events 
        private void SubscribeToForkInUseChangedEvents()
        {
            forks[0].IsInUseChangedEvent += (s, e) => Fork0IsNotInUse = e.IsNotInUse;
            forks[1].IsInUseChangedEvent += (s, e) => Fork1IsNotInUse = e.IsNotInUse;
            forks[2].IsInUseChangedEvent += (s, e) => Fork2IsNotInUse = e.IsNotInUse;
            forks[3].IsInUseChangedEvent += (s, e) => Fork3IsNotInUse = e.IsNotInUse;
            forks[4].IsInUseChangedEvent += (s, e) => Fork4IsNotInUse = e.IsNotInUse;
        }


        private void SubscribeToModeChangedEvents()
        {
            philosophers[0].ModeChangedEvent += (s, e) => Phil0Mode = e.PhilMode;
            philosophers[1].ModeChangedEvent += (s, e) => Phil1Mode = e.PhilMode;
            philosophers[2].ModeChangedEvent += (s, e) => Phil2Mode = e.PhilMode;
            philosophers[3].ModeChangedEvent += (s, e) => Phil3Mode = e.PhilMode;
            philosophers[4].ModeChangedEvent += (s, e) => Phil4Mode = e.PhilMode;
        }
        #endregion



        private bool isStarted;
        public bool IsStarted
        {
            get
            {
                return isStarted;
            }
            set
            {
                isStarted = value;
                StartCommand.RaiseCanExecuteChanged();
                CancelCommand.RaiseCanExecuteChanged();

            }
        }
        private void OnCancel(object arg)
        {
            cts.Cancel();
            IsStarted = false;

        }
        private async void OnStartAsync(object arg)
        {
            IsStarted = true;

            cts = new CancellationTokenSource();
            CancellationToken token = cts.Token;
            Random random = new Random();
            List<Task> philosopherTasks = new List<Task>();
            foreach (Philosopher philosopher in philosophers)
            {
                //start all the async methods and store the returned tasks
                philosopherTasks.Add(philosopher.StartAsync(random, token));
            }

            try
            {
                //asynchronously wait for all the tasks to end
                //the cancellation token will cancel them all
                await Task.WhenAll(philosopherTasks);
            }
            catch (TaskCanceledException)
            {
                IsStarted = false;
                InitialisePhilsMode();
                InitialiseForks();

            }


        }

        #region ForkNotInUse Properties
        private bool fork0IsNotInUse;
        public bool Fork0IsNotInUse
        {
            get
            {
                return fork0IsNotInUse;
            }
            set
            {
                fork0IsNotInUse = value;
                NotifyPropertyChanged();
            }
        }
        private bool fork1IsNotInUse;
        public bool Fork1IsNotInUse
        {
            get
            {
                return fork1IsNotInUse;
            }
            set
            {
                fork1IsNotInUse = value;
                NotifyPropertyChanged();
            }
        }

        private bool fork2IsNotInUse;
        public bool Fork2IsNotInUse
        {
            get
            {
                return fork2IsNotInUse;
            }
            set
            {
                fork2IsNotInUse = value;
                NotifyPropertyChanged();
            }
        }

        private bool fork3IsNotInUse;
        public bool Fork3IsNotInUse
        {
            get
            {
                return fork3IsNotInUse;
            }
            set
            {
                fork3IsNotInUse = value;
                NotifyPropertyChanged();
            }
        }

        private bool fork4IsNotInUse;
        public bool Fork4IsNotInUse
        {
            get
            {
                return fork4IsNotInUse;
            }
            set
            {
                fork4IsNotInUse = value;
                NotifyPropertyChanged();
            }
        }
        #endregion

        #region PhilStatus Properties
        private string phil0Status;
        public string Phil0Status
        {
            get
            {
                return phil0Status;
            }
            set
            {
                phil0Status = value;
                NotifyPropertyChanged();
            }
        }
        private string phil1Status;
        public string Phil1Status
        {
            get
            {
                return phil1Status;
            }
            set
            {
                phil1Status = value;
                NotifyPropertyChanged();
            }
        }
        private string phil2Status;
        public string Phil2Status
        {
            get
            {
                return phil2Status;
            }
            set
            {
                phil2Status = value;
                NotifyPropertyChanged();
            }
        }
        private string phil3Status;
        public string Phil3Status
        {
            get
            {
                return phil3Status;
            }
            set
            {
                phil3Status = value;
                NotifyPropertyChanged();
            }
        }
        private string phil4Status;
        public string Phil4Status
        {
            get
            {
                return phil4Status;
            }
            set
            {
                phil4Status = value;
                NotifyPropertyChanged();
            }
        }
        #endregion

        #region PhilMode Properties
        private PhilosopherMode phil0Mode;
        public PhilosopherMode Phil0Mode
        {
            get
            {
                return phil0Mode;
            }
            set
            {
                phil0Mode = value;

                NotifyPropertyChanged();
                Phil0Status = FormatStatusMessage(philosophers[0]);

            }
        }


        private PhilosopherMode phil1Mode;
        public PhilosopherMode Phil1Mode
        {
            get
            {
                return phil1Mode;
            }
            set
            {
                phil1Mode = value;
                NotifyPropertyChanged();
                Phil1Status = FormatStatusMessage(philosophers[1]);
            }
        }
        private PhilosopherMode phil2Mode;
        public PhilosopherMode Phil2Mode
        {
            get
            {
                return phil2Mode;
            }
            set
            {
                phil2Mode = value;
                NotifyPropertyChanged();
                Phil2Status = FormatStatusMessage(philosophers[2]);
            }
        }
        private PhilosopherMode phil3Mode;
        public PhilosopherMode Phil3Mode
        {
            get
            {
                return phil3Mode;
            }
            set
            {
                phil3Mode = value;
                NotifyPropertyChanged();
                Phil3Status = FormatStatusMessage(philosophers[3]);
            }
        }
        private PhilosopherMode phil4Mode;
        public PhilosopherMode Phil4Mode
        {
            get
            {
                return phil4Mode;
            }
            set
            {
                phil4Mode = value;
                NotifyPropertyChanged();
                Phil4Status = FormatStatusMessage(philosophers[4]);
            }
        }
        #endregion

        #region private methods
        private string FormatStatusMessage(Philosopher philosopher)
        {
            return string.Format(Constants.FormatString, philosopher.Name, philosopher.Mode.ToString());
        }

        private void InitialiseForks()
        {
            foreach (Fork fork in forks)
            {
                fork.IsNotInUse = true;
            }
        }
        private void InitialisePhilsMode()
        {
            foreach (Philosopher philosopher in philosophers)
            {
                philosopher.Mode = PhilosopherMode.Waiting;

            }


        }
        #endregion

        public event PropertyChangedEventHandler PropertyChanged;
        protected virtual void NotifyPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

    }
}
