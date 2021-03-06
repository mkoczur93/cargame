﻿namespace MainProject.UI
{
    using Lean.Pool;
    using RacingMap;
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using System.ComponentModel;
    using UnityEngine;
    using UnityWeld.Binding;
    using Zenject;

    [Binding]
    public class LapResultsViewModel : ViewModel
    {
        [SerializeField]
        private LapTimeResult lapResult = null;
        private List<LapTimeResult> timeLaps = new List<LapTimeResult>();
        [Inject]
        ILapTimeSystem m_LapTimeSystem = null;



        protected override void Awake()
        {
            base.Awake();
            SubscribeOnPanelShow(OnPanelShow);
            SubscribeOnPanelHide(OnPanelHide);



        }
        
        public void OnDestroy()
        {
            UnSubscribeOnPanelShow(OnPanelShow);
            UnSubscribeOnPanelHide(OnPanelHide);
        }
        private void OnPanelShow(PanelUI id)
        {

            if (Id == id)
            {
                SpawnLapTimes();
            }

        }

        private void OnPanelHide(PanelUI id)
        {

            if (Id == id)
            {
                DespawnLapTimes();
                
            }

        }
        public void SpawnLapTimes()
        {
           
            var lapTimes = m_LapTimeSystem.GetAllLapTimes();     
            
            foreach (var item in lapTimes)
            {
                var lap =  LeanPool.Spawn(lapResult, this.transform);
                lap.LapTime = item;
                timeLaps.Add(lap);

            }




        }

        public void DespawnLapTimes()
        {

            
            
            foreach (var item in timeLaps)
            {
                LeanPool.Despawn(item);               

            }
            timeLaps.Clear();



        }
       
    }
}
