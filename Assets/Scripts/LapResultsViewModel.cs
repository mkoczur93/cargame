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

        protected override void Start()
        {
            base.Start();
            SubscribeOnPanelShow(OnPanelShow);
            UnSubscribeOnPanelShow(DespawnLapTimes);



        }


        public void OnPanelShow(PanelUI id)
        {
            
            if (Id == id)
            {
                SpawnLapTimes();
            }

        }
        public void SpawnLapTimes()
        {
            var lapTimes = LapTimeSystem.Instance.GetAllLapTimes();
            foreach (var item in lapTimes)
            {
                var result = LeanPool.Spawn(lapResult, this.transform);
                LapTimeResult.Instance.LapTime = item;
                

            }

          


        }

        public void DespawnLapTimes(PanelUI id)
        {
            
            if (Id == id)
            {
                var lapTimes = GetComponentsInChildren<LapTimeResult>();
                foreach (var item in lapTimes)
                {
                    LeanPool.Despawn(item);

                }
            }
        }

    }
}