namespace MainProject.UI
{
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using UnityEngine;

    public class LapTimeSystem : MonoBehaviour
    {

        private float currentTime = 0f;
        private float msec = 0f;
        private float sec = 0f;
        private float min = 0f;
        private Action OnCheckPointReached = null;
        private List<string> lapTimes = null;
        // Start is called before the first frame update

        private static LapTimeSystem instance = null;
        public static LapTimeSystem Instance { get => instance; set => instance = value; }
        public float CurrentTime { get => currentTime; set => currentTime = value; }
        public float Min { get => min; }
        public float Sec { get => sec; }
        public float Msec { get => msec; }
        public void AddLapTime(){
            lapTimes.Add(min.ToString("00") + " : " + sec.ToString("00") + " : " +msec.ToString("00"));
        }
        public string getAllLapTimes()
        {
            string times = null;
            foreach(var item in lapTimes)
            {
                times = times + " " + item + "\n";
            }
            return times;
        }
        public List<string> GetLapsAllTimes()
        {
            var models = new List<string>();
            foreach (var laptime in lapTimes)
            {
                models.Add(laptime);

            }
            return models;
        }



        private void Awake()
        {
            instance = this;
            lapTimes = new List<string>();

        }


        // Update is called once per frame
        void Update()
        {
            currentTime = currentTime + Time.deltaTime;
            msec = (int)((currentTime - (int)currentTime) * 100);
            sec = (int)(currentTime % 60);
            min = (int)(currentTime / 60 % 60);
            
            OnCheckPointReached?.Invoke();
        }


        public void SubscribeOnCheckPointReached(Action action)
        {
            OnCheckPointReached += action;
        }
        public void UnSubscribeOnCheckPointReached(Action action)
        {
            OnCheckPointReached -= action;
        }
    }
}