﻿namespace MainProject.UI
{
    using UnityEngine;
    using System.ComponentModel;
    using UnityWeld.Binding;
    using System;
    using MainProject.UI;
    using RacingMap;
    using UnityEngine.SceneManagement;
    using UnityEngine.EventSystems;
    using System.Collections.Generic;
    using Zenject;

    [Binding]
    public class EndOfTheGameViewModel : ViewModel, INotifyPropertyChanged
    {
        private string nameScene = string.Empty;
        private string lapStatistics = string.Empty;

        [Inject]
        private readonly IMapController m_MapController = null;
        [Inject]
        private readonly IViewModelController m_ViewModelController = null;



        [Binding]
        public string LapStatistics
        {
            get
            {
                return lapStatistics;
            }
            set
            {
                if (lapStatistics == value)
                {
                    return;
                }



                lapStatistics = value;

                OnPropertyChanged(nameof(LapStatistics));
            }
        }
        protected override void Awake()
        {
            base.Awake();            
            SetupCanvasGroup(0, false, false);
            nameScene = SceneManager.GetActiveScene().name;
           


        }
      


        [Binding]
        public void NewGameBtn()
        {

            m_ViewModelController.getViewModel(PanelUI.LapResultsPanel).hidePanel();
            hidePanel();       
            EventSystem.current.SetSelectedGameObject(null);
            m_MapController.PausedGame();
            m_MapController.SetStartDefaultPosition();
            //SceneManager.LoadScene(nameScene);
            Time.timeScale = 1f;
            Cursor.visible = !Cursor.visible;

        }
        [Binding]
        public void BackToMainMenuBtn()
        {
            hidePanel();
            Debug.Log("BackToMainMenu");
            m_ViewModelController.getViewModel(PanelUI.LapResultsPanel).hidePanel();            
            
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