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
        [SerializeField]
        private List<string> lapTimes = null;
        // Start is called before the first frame update

        private static LapTimeSystem instance = null;
        public static LapTimeSystem Instance { get => instance; set => instance = value; }
        public float CurrentTime { get => currentTime; set => currentTime = value; }

         public void AddLapTime()
         {
            lapTimes.Add((lapTimes.Count +1).ToString() + ". " + String.Format(@"{0:mm\:ss\:ff}", timeSpan));
          }
      
     
        public List<string> GetAllLapTimes()
        {
            return lapTimes;
        }

        public void ClearAllLapTimes()
        {
            lapTimes.Clear();
        }

        private void Awake()
        {
            instance = this;
            lapTimes = new List<string>();

        }


      

        public string SetActualTime()
        {

            currentTime += Time.deltaTime;
            timeSpan = TimeSpan.FromSeconds(currentTime);
            return String.Format(@"{0:mm\:ss\:ff}", timeSpan);
            


        }
    }
}