namespace MainProject.UI
{
    using UnityEngine;
    using System.ComponentModel;
    using UnityWeld.Binding;
    using System;
    using MainProject.UI;
    using RacingMap;
    using Zenject;

    [Binding]
    public class GameGUIViewModel : ViewModel, INotifyPropertyChanged
    {

        private int m_CounterFps = 0;
        private int m_CounterLaps = 1;       
        private int m_MaxLaps = 0;
        private string m_LapTime = string.Empty;
        private string m_StartLapTime = "00:00:00";        
        private bool m_StartGame = false;
        [Inject]
        private readonly IMapController m_MapController = null;
        [Inject]
        private readonly IViewModelController m_ViewModelController = null;
        [Inject]
        private readonly ILapsSystem m_LapsSystem = null;
        [Inject]
        private readonly ILapTimeSystem m_LapTimeSystem = null;
        [Inject]
        private readonly IFpsSystem m_FpsSystem = null;
        [Inject]
        private readonly IGameManager m_GameManager = null;




        // Start is called before the first frame update
        protected override void Awake()
        {
            
            base.Awake();
            LapTime = m_StartLapTime;            
            MaxLaps = m_GameManager.Laps;

        }
        private void Start()
        {
            m_LapsSystem.SubscribeOnStartGame(SetCounterLap);
            m_LapsSystem.SubscribeOnCheckPointReached(SetCounterLap);
            m_MapController.SubscribeOnStartGame(StartGame);
            m_MapController.SubscribeOnPausedGame(PausedGame);
        }
        private void StartGame()
        {
            m_StartGame = true;
            LapTime = m_StartLapTime;

        }
        private void PausedGame()
        {
            m_StartGame = false;
            LapTime = m_StartLapTime;

        }
        // Update is called once per frame

        private void Update()
        {
            
            if (m_MaxLaps >= m_CounterLaps)
            {
                
                if (m_StartGame == true)
                {
                    LapTime = m_LapTimeSystem.SetActualTime();
                }
               
                CounterFps = m_FpsSystem.FpsCounter();
            }
        }
        public void SetCounterLap() { CounterLaps = m_LapsSystem.CounterLaps; }


        private void OnDestroy()
        {
            m_LapsSystem.UnSubscribeOnCheckPointReached(SetCounterLap);
            m_LapsSystem.UnSubscribeOnStartGame(SetCounterLap);
            m_MapController.UnSubscribeOnStartGame(StartGame);
            m_MapController.UnSubscribeOnPausedGame(PausedGame);


        }


        [Binding]
        public int CounterFps
        {
            get
            {
                return m_CounterFps;
            }
            set
            {
                if (m_CounterFps == value)
                {
                    return;
                }



                m_CounterFps = value;

                OnPropertyChanged(nameof(CounterFps));
            }
        }

        [Binding]
        public int CounterLaps
        {
            get
            {
                return m_CounterLaps;
            }
            set
            {

                if (m_CounterLaps == value)
                {
                    return;
                }



                m_CounterLaps = value;


                if (m_MaxLaps < m_CounterLaps)
                {
                    
                    Time.timeScale = 0f;
                    ViewModel id = m_ViewModelController.getViewModel(PanelUI.EndOfTheGamePanel);
                    id.showPanel();
                    m_ViewModelController.getViewModel(PanelUI.LapResultsPanel).showPanel();
                    Cursor.visible = true;

                    return;
                }
                m_LapTimeSystem.SetCurrentTime(0);


                OnPropertyChanged(nameof(CounterLaps));
            }
        }



        [Binding]
        public int MaxLaps
        {
            get
            {
                return m_MaxLaps;
            }
            set
            {
                if (m_MaxLaps == value)
                {
                    return;
                }


                m_MaxLaps = value;

                OnPropertyChanged(nameof(MaxLaps));
            }
        }
        [Binding]
        public string LapTime
        {
            get
            {
                return m_LapTime;
            }
            set
            {
                if (m_LapTime == value)
                {
                    return;
                }


                m_LapTime = value;

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