namespace MainProject
{
    using Lean.Pool;
    using MainProject.UI;
    using Player;
    using GameManager;
    using RacingMap;
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using UnityEngine;
    using Zenject;
    using System.ComponentModel;
    using Car;

    public class MapController : IMapController, IInitializable
    {
        [Inject]
        private readonly  DiContainer Container = null;        
        private DefaultMapSettings m_Settings = null;        
        private ViewModel startAnimPanel = null;
        private Action startGame = null;
        private Action pausedGame = null;
        private PlayerMovementController m_SelectedCar;
        [Inject]
        private readonly IGameManager m_GameManager = null;
        [Inject]
        private readonly IViewModelController m_ViewModelController = null;
        [Inject]
        private readonly ILapsSystem m_LapsSystem = null;
        [Inject]
        private readonly ILapTimeSystem m_LapTimeSystem = null;

        public DefaultMapSettings Settings
        {
            get => m_Settings;
        }
        public PlayerMovementController SelectedCar
        {
            get => m_SelectedCar;
        }
        public void Initialize()
        {   
            m_SelectedCar = m_GameManager.SelectedCar;            
            startAnimPanel = m_ViewModelController.getViewModel(PanelUI.StartAnimPanel);            
            m_Settings = m_GameManager.SelectedDefaultMapSettings;            
            var car = Container.InstantiatePrefabForComponent<PlayerMovementController>(m_GameManager.SelectedCar);
            m_SelectedCar = car;
            SetStartDefaultPosition();
        }
     
 
        // Start is called before the first frame update
   
        public void SetStartDefaultPosition()
        {

            if (m_SelectedCar != null)
            {

                if (m_SelectedCar.TryGetComponent<Rigidbody2D>(out var player))
                {

                    player.velocity = Vector2.zero;
                    player.transform.eulerAngles = m_Settings.StartCarRotation;
                    player.transform.position = m_Settings.StartCarPosition;

                }

            }
    
            m_LapTimeSystem.ClearAllLapTimes();
            m_LapTimeSystem.SetCurrentTime(m_Settings.StartTime);
            m_LapsSystem.SetInitialLap();
            m_LapsSystem.StartGame();
            m_LapsSystem.ClearLapCheckpoints();
            startAnimPanel.enabled = true;






        }
        public void StartGame()
        {
            startGame?.Invoke();
        }

        public void PausedGame()
        {
            pausedGame?.Invoke();
        }



        public void SubscribeOnStartGame(Action action)
        {
            startGame += action;
        }
        public void UnSubscribeOnStartGame(Action action)
        {
            startGame -= action;
        }
        public void SubscribeOnPausedGame(Action action)
        {
            pausedGame += action;
        }
        public void UnSubscribeOnPausedGame(Action action)
        {
            pausedGame -= action;
        }

     
    }
}
