namespace MainProject.UI
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

    [Binding]
    public class EndOfTheGameViewModel : ViewModel, INotifyPropertyChanged
    {
        private string nameScene = string.Empty;
        private string lapStatistics = string.Empty;
        

        
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
        protected override void Start()
        {
            base.Start();            
            SetupCanvasGroup(0, false, false);
            nameScene = SceneManager.GetActiveScene().name;
            LapsSystem.Instance.SubscribeOnCheckPointReached(Statistics);


        }

        public void Statistics (){ LapStatistics = LapTimeSystem.Instance.getAllLapTimes()  ; }

        [Binding]
        public void NewGameBtn()
        {

            EventSystem.current.SetSelectedGameObject(null);
            SceneManager.LoadScene(nameScene);
            Time.timeScale = 1f;
            Cursor.visible = !Cursor.visible;

        }
        [Binding]
        public void BackToMainMenuBtn()
        {
            hidePanel();
            Debug.Log("BackToMainMenu");
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