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
            onPanelShow +=onPanelShow1;
            Debug.LogWarning("LapResultsViewModel");

        }


        public void onPanelShow1(PanelUI id)
        {
            Debug.LogWarning(id);
            if (Id == id)
            {
                SpawnLapTimes();
            }

        }
        public void SpawnLapTimes()
        {
            var lapTimes = LapTimeSystem.Instance.GetAllLapTimes();            
            foreach (var item in lapTimes)            {
                var result = LeanPool.Spawn(lapResult, this.transform);
                this.GetComponent<TMPro.TextMeshProUGUI>().text = item;


            }
        }

    }
}