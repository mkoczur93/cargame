﻿namespace MainProject.UI
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
        [SerializeField]
        private int maxLaps = 0;
        private string lapTime = string.Empty;
        private const int maxLapsLimit = 6;
        private bool startGame = false;




        private void Awake()
        {
            LapsSystem.Instance.SubscribeOnCheckPointReached(IncrementCounterLap);
            MapController.Instance.SubscribeOnStartGame(StartGame);
        }
        // Start is called before the first frame update
        protected override void Start()
        {
            
            base.Start();
            if (maxLaps > maxLapsLimit)
            {
                maxLaps = maxLapsLimit;
            }
            //SubscribeOnPanelHide(OnPanelHide);
            

        }
       
        private void StartGame()
        {
            startGame = !startGame;
            
        }
        // Update is called once per frame

        private void Update()
        {
            
            if (maxLaps >= counterLaps)
            {
                
                if (startGame == true)
                {
                    LapTime = LapTimeSystem.Instance.SetTime();
                }
                else
                {
                    LapTime = "00:00:00";
                }
                CounterFps = FpsSystem.Instance.FpsCounter();
            }
        }
        public void IncrementCounterLap() { CounterLaps = LapsSystem.Instance.CounterLaps; }


        private void OnDestroy()
        {
            LapsSystem.Instance.UnSubscribeOnCheckPointReached(IncrementCounterLap);
            MapController.Instance.UnSubscribeOnStartGame(StartGame);

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
                    ViewModelController.Instance.getViewModel(PanelUI.LapResultsPanel).showPanel();
                    Cursor.visible = true;

                    return;
                }
                LapTimeSystem.Instance.CurrentTime = 0;


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
        public string LapTime
        {
            get
            {
                return lapTime;
            }
            set
            {
                if (lapTime == value)
                {
                    return;
                }


                lapTime = value;

                OnPropertyChanged(nameof(LapTime));
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