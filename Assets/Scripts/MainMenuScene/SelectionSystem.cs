namespace Car
{
    using DG.Tweening;
    using Lean.Pool;
    using GameManager;
    using MainProject.Card;
    using MainProject.UI;
    using System.Collections;
    using System.Collections.Generic;
    using UnityEngine;
    using UnityEngine.EventSystems;
    using UnityEngine.UI;
    using UnityEngine.SceneManagement;
    using System;
    using RacingMap;
    using Zenject;
    using static MainMenuScriptableObjectInstaller;

    public class SelectionSystem
    {
        
        private CarPlayerData m_CarsData = null;
        private MapListData m_MapsData = null;                
        //private static SelectionSystem instance = null;
        //  public static SelectionSystem Instance { get => instance; set => instance = value; }
        private int m_Counter = 0;
        private int m_MaxCounter = 0;
        private int m_MapCounter = 0;
        private int m_MapMaxCounter = 0;
        private Action<PlayerCar> m_onDataChanged = null;
        private Action<Map> m_onMapDataChanged = null;
        public SelectionSystem(GameObjectSettings m_Data)
        {
            m_MapsData = m_Data.MapsData;
            Debug.LogWarning(m_MapsData.Maps.Count);
            m_CarsData = m_Data.CarsData;
            m_MaxCounter = m_CarsData.Cars.Count - 1;
            m_MapMaxCounter = m_MapsData.Maps.Count - 1;

        }
        public CarPlayerData CarsData
        {
            get => m_CarsData;
        }
        public MapListData MapsData
        {
            get => m_MapsData;
        }

       // private void Awake()
      //  {

         //  instance = this;

       // }

       // private void Start()
     //   {
       //     m_MaxCounter = m_CarsData.Cars.Count - 1;
       //     m_MapMaxCounter = m_MapsData.Maps.Count - 1;
//
       // }

        public PlayerCar SelectTheNextCar()
        {
            if(m_Counter == m_MaxCounter)
            {
                return m_CarsData.Cars[m_Counter]; 
            }
            m_Counter++;
            m_onDataChanged?.Invoke(m_CarsData.Cars[m_Counter]);            
            return m_CarsData.Cars[m_Counter];
        }
        public PlayerCar SelectThePreviousCar()
        {
            if (m_Counter == 0)
            {
                return m_CarsData.Cars[m_Counter];
            }
            m_Counter--;
            m_onDataChanged?.Invoke(m_CarsData.Cars[m_Counter]);
            return m_CarsData.Cars[m_Counter];
        }
       public PlayerCar SelectCarOnClick(int id)
        {
            m_Counter = id;
            m_onDataChanged?.Invoke(m_CarsData.Cars[m_Counter]);
            return m_CarsData.Cars[m_Counter];
        }

        public Map SelectTheNextMap()
        {
            if (m_MapCounter == m_MapMaxCounter)
            {
                return m_MapsData.Maps[m_MapCounter];
            }
            m_MapCounter++;
            m_onMapDataChanged?.Invoke(m_MapsData.Maps[m_MapCounter]);
            return m_MapsData.Maps[m_MapCounter];
        }
        public Map SelectThePreviousMap()
        {
            if (m_MapCounter == 0)
            {
                return m_MapsData.Maps[m_MapCounter];
            }
            m_MapCounter--;
            m_onMapDataChanged?.Invoke(m_MapsData.Maps[m_MapCounter]);
            return m_MapsData.Maps[m_MapCounter];
        }
        public Map SelectMapOnClick(int id)
        {
            m_MapCounter = id;
            m_onMapDataChanged?.Invoke(m_MapsData.Maps[m_MapCounter]);
            return m_MapsData.Maps[m_MapCounter];
        }
        public void StartGame()
        {
           
            GameManager.Instance.SelectedCar = m_CarsData.Cars[m_Counter].Car;
            GameManager.Instance.SelectedDefaultMapSettings = m_MapsData.Maps[m_MapCounter].MapSetings;
            string load = m_MapsData.Maps[m_MapCounter].NameMap;
            DOTween.KillAll();
            SceneManager.LoadScene(load);
            // Potem zmienie :D
        }

        
        public void SubscribeOnDataChanged(Action<PlayerCar> action)
        {
            m_onDataChanged += action;
        }
        public void UnSubscribeOnDataChanged(Action<PlayerCar> action)
        {
            m_onDataChanged -= action;
        }


        public void SubscribeOnMapDataChanged(Action<Map> action)
        {
            m_onMapDataChanged += action;
        }
        public void UnSubscribeOnMapDataChanged(Action<Map> action)
        {
            m_onMapDataChanged -= action;
        }

    }
}