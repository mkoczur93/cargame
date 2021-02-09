﻿namespace MainProject.UI
{
    using RacingMap;
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using UnityEngine;

    public class LapTimeSystem : MonoBehaviour
    {

        private TimeSpan timeSpan = new TimeSpan();
        private float currentTime = 0f;
        private List<string> lapTimes = null;
        // Start is called before the first frame update

        private static LapTimeSystem instance = null;
        public static LapTimeSystem Instance { get => instance; set => instance = value; }
        public float CurrentTime { get => currentTime; set => currentTime = value; }
       
        //public void AddLapTime()
       // {
        //    lapTimes.Add(min.ToString("00") + " : " + sec.ToString("00") + " : " + msec.ToString("00"));
      //  }
        public string getAllLapTimes()
        {
            string times = null;
            foreach (var item in lapTimes)
            {
                times = times + " " + item + "\n";
            }
            return times;
        }
        public List<string> GetAllLapTimes()
        {

            return lapTimes;
        }



        private void Awake()
        {
            instance = this;
            lapTimes = new List<string>();

        }


      

        public string LapTime()
        {

            currentTime += Time.deltaTime;
            timeSpan = TimeSpan.FromSeconds(currentTime);
            return String.Format(@"{0:mm\:ss\:ff}", timeSpan);
            


        }
    }
}