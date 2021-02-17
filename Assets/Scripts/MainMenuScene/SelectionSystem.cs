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

    public class SelectionSystem : MonoBehaviour
    {
        [SerializeField]
        private CarPlayerData m_CarsData = null;      
        private static SelectionSystem instance = null;
        public static SelectionSystem Instance { get => instance; set => instance = value; }
        private int m_Counter = 0;
        private int m_MaxCounter = 0;
        private Action<PlayerCar> m_onDataChanged = null;

        public CarPlayerData CarsData
        {
            get => m_CarsData;
        }
        
        private void Awake()
        {

            instance = this;

        }

        private void Start()
        {
            m_MaxCounter = m_CarsData.Cars.Count - 1;
        }

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
        public void StartGame()
        {
           
            GameManager.Instance.SelectedCar = m_CarsData.Cars[m_Counter].Car;
            SceneManager.LoadScene("SampleScene");
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

    }
}