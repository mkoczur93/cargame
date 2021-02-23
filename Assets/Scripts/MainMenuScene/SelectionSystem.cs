namespace Car
{
    using DG.Tweening;
    using Lean.Pool;    
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
    using Player;

    public class SelectionSystem : ISelectionSystem, IInitializable
    {

        private List<PlayerCar> m_CarsData = null;
        private List<Map> m_MapsData = null;
        private List<SpritePlayerCar> m_SpritePlayerCars = null;
        private int m_Counter = 0;
        private int m_MaxCounter = 0;
        private int m_MapCounter = 0;
        private int m_MapMaxCounter = 0;
        private Action<PlayerCar> m_onDataChanged = null;
        private Action<Map> m_onMapDataChanged = null;        
        [Inject]
        private readonly MapListData.Settings m_MapSetting = null;
        [Inject]
        private readonly CarPlayerData.Settings m_CarPlayerSetting = null;
        [Inject]
        private readonly SpritePlayerCarData.Settings m_SpriteCars = null;
        [Inject]
        private readonly PlayerMovementController m_PlayerCar = null;
        [Inject]
        private IGameManager m_GameManager = null;




        public void Initialize()
        {
            m_SpritePlayerCars = m_SpriteCars.SpriteCars;
            m_MapsData = m_MapSetting.Maps;            
            m_CarsData = m_CarPlayerSetting.Cars;
            m_MaxCounter = m_CarPlayerSetting.Cars.Count - 1;
            m_MapMaxCounter = m_MapSetting.Maps.Count - 1;
        }
        public List<PlayerCar> CarsData
        {
            get => m_CarsData;
        }
        public List<Map> MapsData
        {
            get => m_MapsData;
        }
        public List<SpritePlayerCar> SpritePlayerCarsData
        {
            get => m_SpritePlayerCars;
        }

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
            m_GameManager.SetSelectedCar(m_PlayerCar, m_SpriteCars.SpriteCars[m_Counter].SpriteCar);          
            m_GameManager.SelectedDefaultMapSettings = m_MapsData[m_MapCounter].MapSettings;            
            SceneManager.LoadScene(m_MapsData[m_MapCounter].NameMap);            
            DOTween.KillAll();
            
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