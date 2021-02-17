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
        [SerializeField]
        private PlayerCardViewModel m_PlayerCard = null;        
        [SerializeField]
        private RectTransform m_ScrollContent = null;
        private static SelectionSystem instance = null;
        public static SelectionSystem Instance { get => instance; set => instance = value; }
        private int m_Counter = 0;
        private int m_Max_Counter = 0;
        private float m_PositionCard = 0f;
        private float m_CellSize = 0f;
        private List<CardPosition> m_CardPositions = new List<CardPosition>();
        private CardPosition m_Position = null;
        private List<PlayerCardViewModel> m_PlayerCardSpawn = new List<PlayerCardViewModel>();
        private Sequence m_MySequence = null;
        private const int m_Duration = 1;
        [SerializeField]
        private ColorBlock m_ColorBlock;
        [SerializeField]
        private ColorBlock m_ColorBlockSelectedCar;
        private Action m_OnChangeCard = null;
       



        private void Awake()
        {

            instance = this;

        }
        
        void Start()
        {
           
                
           
            m_CellSize = m_ScrollContent.GetComponent<GridLayoutGroup>().cellSize.x;
                
            
            var count = 0;
            foreach (var car in m_CarsData.Cars)
            {

                var card = LeanPool.Spawn(m_PlayerCard, m_ScrollContent.transform);
                card.CarSprite = car.SpriteCar;
                if (count == 0)
                {
                    count++;
                    card.NormalColor = m_ColorBlockSelectedCar;

                }
                else
                {
                    card.NormalColor = m_ColorBlock;
                }
                m_PlayerCardSpawn.Add(card);
                m_Position = new CardPosition();
                m_Position.Id = card.GetInstanceID();
                m_Position.Position = m_PositionCard;
                m_Position.Card = card;
                m_CardPositions.Add(m_Position);

                m_PositionCard = m_PositionCard + m_CellSize;


            }

            m_Max_Counter = m_CardPositions.Count - 1;
            m_MySequence = DOTween.Sequence();


        }
      
        public void SelectTheNextCar()
        {
            if (m_Counter == m_Max_Counter)
            {
                return;
            }
            else
            {

                m_PlayerCardSpawn[m_Counter].NormalColor = m_ColorBlock;
                m_Counter++;                
                m_MySequence.Append(m_ScrollContent.DOLocalMoveX(-m_CardPositions[m_Counter].Position, m_Duration));
                m_PlayerCardSpawn[m_Counter].NormalColor = m_ColorBlockSelectedCar;


            }
            

        }

        public void SelectThePreviousCar()
        {

            if (m_Counter == 0)
            {
                return;
            }
            else
            {
                m_PlayerCardSpawn[m_Counter].NormalColor = m_ColorBlock;
                m_Counter--;
                m_MySequence.Append(m_ScrollContent.DOLocalMoveX(-m_CardPositions[m_Counter].Position, m_Duration));
                m_PlayerCardSpawn[m_Counter].NormalColor = m_ColorBlockSelectedCar;
                
            }

        }

        public CardPosition SelectThePreviousCar1()
        {
            if (m_Counter == 0)
            {
                return m_CardPositions[m_Counter];
            }
            else
            {
                m_Counter--;
                m_OnChangeCard?.Invoke();
                return m_CardPositions[m_Counter];
            }


        }
        public CardPosition SelectTheNextCar1()
        {
            if (m_Counter == m_Max_Counter)
            {
                return m_CardPositions[m_Counter];
            }
            else
            {
                m_Counter++;
                m_OnChangeCard?.Invoke();
                return m_CardPositions[m_Counter];
            }


        }
        public void SetTheSelectedCar(int value)
        {
            int index = 0;
            foreach (var item in m_CardPositions)
            {
                if (item.Id == value)
                {
                    m_PlayerCardSpawn[m_Counter].NormalColor = m_ColorBlock;
                    m_Counter = index;
                    m_MySequence.Append(m_ScrollContent.DOLocalMoveX(-m_CardPositions[m_Counter].Position, m_Duration));
                    m_PlayerCardSpawn[m_Counter].NormalColor = m_ColorBlockSelectedCar;
                    EventSystem.current.SetSelectedGameObject(null);
                    return;
                }
                index++;
            }

        }
        public int SetTheSelectedCar1()
        {
            return m_CardPositions[m_Counter].Id;

        }
        public void StartGame()
        {
           
            GameManager.Instance.SelectedCar = m_CarsData.Cars[m_Counter].Car;
            SceneManager.LoadScene("SampleScene");
            // Potem zmienie :D
        }

        public void SubscribeOnChangeCard(Action action)
        {
            m_OnChangeCard += action;
        }
        public void UnSubscribeOnChangeCard(Action action)
        {
            m_OnChangeCard -= action;
        }

    }
}