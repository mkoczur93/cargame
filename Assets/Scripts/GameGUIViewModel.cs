namespace MainProject.UI
{
    using UnityEngine;
    using System.ComponentModel;
    using UnityWeld.Binding;
    using System;
    using MainProject.UI;


    [Binding]
    public class GameGUIViewModel : ViewModel, INotifyPropertyChanged
    {

        private int counterFps = 0;
        private static GameGUIViewModel instance = null;
        public static GameGUIViewModel Instance
        {
            get => instance;
        }

        void Awake()
        {
            instance = this;

        }
        // Start is called before the first frame update
        protected override void Start()
        {
            base.Start();
        }

        // Update is called once per frame





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