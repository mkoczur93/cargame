namespace MainProject.UI
{
    using UnityEngine;
    using System.ComponentModel;
    using UnityWeld.Binding;
    using System;
    using MainProject.UI;
    using RacingMap;

    [Binding]
    public class GameGUIViewModel : ViewModel, INotifyPropertyChanged
    {

        private int counterFps = 0;
        private int counterLaps = 1;
        private string min = string.Empty;
        private string sec = string.Empty;
        private string msec = string.Empty;
        [SerializeField]
        private int maxLaps = 0;

        
       

 
        // Start is called before the first frame update
        protected override void Start()
        {
            LapsSystem.Instance.SubscribeOnCheckPointReached(IncrementCounterLap);
            FpsSystem.Instance.SubscribeOnCheckPointReached(IncrementCounterFps);
            FpsSystem.Instance.SubscribeOnCheckPointReached(IncrementWatch);
            base.Start();
        }

        // Update is called once per frame


        public void IncrementCounterLap() { CounterLaps++; }
        public void IncrementCounterFps() { CounterFps = FpsSystem.Instance.Fps; }
        public void IncrementWatch() 
        {   Min = LapTimeSystem.Instance.Min.ToString("00");
            Sec = LapTimeSystem.Instance.Sec.ToString("00");
            Msec = LapTimeSystem.Instance.Msec.ToString("00"); 
        }

        private void OnDestroy()
        {
            LapsSystem.Instance.UnSubscribeOnCheckPointReached(IncrementCounterLap);
            LapsSystem.Instance.UnSubscribeOnCheckPointReached(IncrementCounterFps);
            LapTimeSystem.Instance.UnSubscribeOnCheckPointReached(IncrementWatch);
        }


        [Binding]
        public int CounterFps
        {
            get
            {
                return counterFps;
            }
            set
            {
                if (counterFps == value)
                {
                    return;
                }
               


                counterFps = value;

                OnPropertyChanged(nameof(CounterFps));
            }
        }

        [Binding]
        public int CounterLaps
        {
            get
            {
                return counterLaps;
            }
            set
            {
                
                if (counterLaps == value)
                {
                    return;
                }
               


                counterLaps = value;

                if (maxLaps < counterLaps)
                {
                    Time.timeScale = 0f;
                    ViewModel id = ViewModelController.Instance.getViewModel(PanelUI.EndOfTheGamePanel);
                    id.showPanel();
                    return;
                }

                OnPropertyChanged(nameof(CounterLaps));
            }
        }



        [Binding]
        public int MaxLaps
        {
            get
            {
                return maxLaps;
            }
            set
            {
                if (maxLaps == value)
                {
                    return;
                }
                

                maxLaps = value;

                OnPropertyChanged(nameof(MaxLaps));
            }
        }
        [Binding]
        public string Msec
        {
            get
            {
                return msec;
            }
            set
            {
                if (msec == value)
                {
                    return;
                }


                msec = value;

                OnPropertyChanged(nameof(Msec));
            }
        }



        [Binding]
        public string Sec
        {
            get
            {
                return sec;
            }
            set
            {
                if (sec == value)
                {
                    return;
                }


                sec = value;

                OnPropertyChanged(nameof(Sec));
            }
        }

        [Binding]
        public string Min
        {
            get
            {
                return min;
            }
            set
            {
                if (min == value)
                {
                    return;
                }


                min = value;

                OnPropertyChanged(nameof(Min));
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;
        private void OnPropertyChanged(string propertyName)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }






    }
}