namespace MainProject.UI
{
    using RacingMap;
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using UnityEngine;
    using Zenject;

    public class LapTimeSystem : ILapTimeSystem, IInitializable
    {

        private TimeSpan m_TimeSpan = new TimeSpan();
        private float m_CurrentTime = 0f;
        private List<string> m_LapTimes = null;
        public float CurrentTime { get => m_CurrentTime; }
        public void SetCurrentTime(float CurrentTime)
        {
            if (CurrentTime >= 0)
            {
                m_CurrentTime = CurrentTime;
            }
        }
        public void Initialize()
        {
            m_LapTimes = new List<string>();
        }
        public void AddLapTime()
        {
            m_LapTimes.Add((m_LapTimes.Count + 1).ToString() + ". " + String.Format(@"{0:mm\:ss\:ff}", m_TimeSpan));
        }


        public List<string> GetAllLapTimes()
        {
            return m_LapTimes;
        }

        public void ClearAllLapTimes()
        {
            if (m_LapTimes != null)
            {
                m_LapTimes.Clear();
            }
        }

        


        public string SetActualTime()
        {

            m_CurrentTime += Time.deltaTime;
            m_TimeSpan = TimeSpan.FromSeconds(m_CurrentTime);
            return String.Format(@"{0:mm\:ss\:ff}", m_TimeSpan);



        }


    }
}