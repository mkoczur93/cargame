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
    

    public interface ISelectionSystem
    {
        PlayerCar SelectTheNextCar();
        PlayerCar SelectThePreviousCar();
        PlayerCar SelectCarOnClick(int id);
        Map SelectTheNextMap();
        Map SelectThePreviousMap();
        Map SelectMapOnClick(int id);
        void StartGame();
        void SubscribeOnDataChanged(Action<PlayerCar> action);
        void UnSubscribeOnDataChanged(Action<PlayerCar> action);
        void SubscribeOnMapDataChanged(Action<Map> action);
        void UnSubscribeOnMapDataChanged(Action<Map> action);
    }
    public class SelectionSystem : ISelectionSystem, IInitializable
    {

        private List<PlayerCar> m_CarsData = null;
        private List<Map> m_MapsData = null;
        //private static SelectionSystem instance = null;
        //  public static SelectionSystem Instance { get => instance; set => instance = value; }
        private int m_Counter = 0;
        private int m_MaxCounter = 0;
        private int m_MapCounter = 0;
        private int m_MapMaxCounter = 0;
        private Action<PlayerCar> m_onDataChanged = null;
        private Action<Map> m_onMapDataChanged = null;
        //[Inject]
        // CarPlayerData.Settings m_CarPlayerSetting;
        [Inject]
        MapListData.Settings m_MapSetting;
        readonly CarPlayerData.Settings m_CarPlayerSetting;


        public SelectionSystem(CarPlayerData.Settings carPlayerSetting)
        {
            m_CarPlayerSetting = carPlayerSetting;
            Debug.Log("start");

            m_MapsData = m_MapSetting.Maps;
            m_CarsData = m_CarPlayerSetting.Cars;


            m_MaxCounter = m_CarPlayerSetting.Cars.Count - 1;
            m_MapMaxCounter = m_MapSetting.Maps.Count - 1;


        }

        public void Initialize()
        {
            Debug.Log(m_CarPlayerSetting);
        }
        public List<PlayerCar> CarsData
        {
            get => m_CarsData;
        }
        public List<Map> MapsData
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
            if (m_Counter == m_MaxCounter)
            {
                return m_CarsData[m_Counter];
            }
            m_Counter++;
            m_onDataChanged?.Invoke(m_CarsData[m_Counter]);
            return m_CarsData[m_Counter];
        }
        public PlayerCar SelectThePreviousCar()
        {
            if (m_Counter == 0)
            {
                return m_CarsData[m_Counter];
            }
            m_Counter--;
            m_onDataChanged?.Invoke(m_CarsData[m_Counter]);
            return m_CarsData[m_Counter];
        }
        public PlayerCar SelectCarOnClick(int id)
        {
            m_Counter = id;
            m_onDataChanged?.Invoke(m_CarsData[m_Counter]);
            return m_CarsData[m_Counter];
        }

        public Map SelectTheNextMap()
        {
            if (m_MapCounter == m_MapMaxCounter)
            {
                return m_MapsData[m_MapCounter];
            }
            m_MapCounter++;
            m_onMapDataChanged?.Invoke(m_MapsData[m_MapCounter]);
            return m_MapsData[m_MapCounter];
        }
        public Map SelectThePreviousMap()
        {
            if (m_MapCounter == 0)
            {
                return m_MapsData[m_MapCounter];
            }
            m_MapCounter--;
            m_onMapDataChanged?.Invoke(m_MapsData[m_MapCounter]);
            return m_MapsData[m_MapCounter];
        }
        public Map SelectMapOnClick(int id)
        {
            m_MapCounter = id;
            m_onMapDataChanged?.Invoke(m_MapsData[m_MapCounter]);
            return m_MapsData[m_MapCounter];
        }
        public void StartGame()
        {

            GameManager.Instance.SelectedCar = m_CarsData[m_Counter].Car;
            //  GameManager.Instance.SelectedDefaultMapSettings = m_MapsData.Maps[m_MapCounter].MapSetings;
            // string load = m_MapsData.Maps[m_MapCounter].NameMap;
            DOTween.KillAll();
            //SceneManager.LoadScene(load);
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