namespace MainProject.UI
{
    using UnityEngine;
    using System.ComponentModel;
    using UnityWeld.Binding;
    using System;
    using MainProject.UI;

    [Binding]
    public class GameGUIViewModel : MonoBehaviour, INotifyPropertyChanged
    {

        private string fps = string.Empty;
        private float frame = 0f;
        int counter = 0;
        // Start is called before the first frame update
        void Start()
        {

        }

        // Update is called once per frame
        void Update()
        {

            if (UI.PanelManager.Paused != true)
            {
                frame = frame + 1f / Time.deltaTime;
                counter++;
                if (counter > 10)
                {
                    frame = frame / counter;
                    Fps = "FPS:" + Mathf.RoundToInt(frame).ToString();
                    frame = 0;
                    counter = 0;

                }
            }
        }


        [Binding]
        public string Fps
        {
            get
            {
                return fps;
            }
            set
            {
                if (fps == value)
                {
                    return;
                }


                fps = value;

                OnPropertyChanged(nameof(Fps));
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
        public void SetFPS()
        {

        }


    }
}