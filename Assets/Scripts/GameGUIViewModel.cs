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

        
       

        void Awake()
        {
            

        }
        // Start is called before the first frame update
        protected override void Start()
        {
            LapsSystem.Instance.SubscribeOnCheckPointReached(IncrementCounterLap);
            FpsSystem.Instance.SubscribeOnCheckPointReached(IncrementCounterFps);
            base.Start();
        }

        // Update is called once per frame


        public void IncrementCounterLap() { CounterLaps++; }
        public void IncrementCounterFps() { CounterFps = FpsSystem.Instance.Fps; }

        private void OnDestroy()
        {
            LapsSystem.Instance.UnSubscribeOnCheckPointReached(IncrementCounterLap);
            LapsSystem.Instance.UnSubscribeOnCheckPointReached(IncrementCounterFps);
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

                OnPropertyChanged(nameof(CounterLaps));
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