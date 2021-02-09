namespace MainProject.UI
{
    using Lean.Pool;
    using RacingMap;
    using System.Collections;
    using System.Collections.Generic;
    using System.ComponentModel;
    using UnityEngine;
    using UnityWeld.Binding;

    [Binding]
    public class LapResultsViewModel : ViewModel
    {
        [SerializeField]
        GameObject lapResult = null;        
        private int counterLaps = 1;
        private List<string> lapStatistics = null;

        // Start is called before the first frame update

        private void Start()
        {
            LapsSystem.Instance.SubscribeOnCheckPointReached(Statistics);
        }
        public void Statistics() { SpawnLapTimes(); }
        
        

        public void SpawnLapTimes()
        {
           
                var result = LeanPool.Spawn(lapResult,this.transform);
               // Debug.Log(LapTimeSystem.Instance.LastLapTime());
             //   LapTimeResult.Instance.Init(LapTimeSystem.Instance.LastLapTimes());
                
            
        }

        public void SpawnLapTimes1()
        {
            var lapTimes = LapTimeSystem.Instance.GetAllLapTimes();
            foreach (var item in lapTimes)
            {
                var result = LeanPool.Spawn(lapResult, this.transform);
                //LapTimeResult.Instance.Init(item);

            }
        }

    }
}