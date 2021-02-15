namespace Car
{
    using DG.Tweening;
    using Lean.Pool;
    using MainProject.UI;
    using System.Collections;
    using System.Collections.Generic;
    using UnityEngine;
    using UnityEngine.UI;

    public class SelectionSystem : MonoBehaviour
    {
        [SerializeField]
        private CarPlayerData carsData = null;
        [SerializeField]
        private PlayerCardViewModel PlayerCard = null;
        [SerializeField]
        private GameObject m_panel = null;
        [SerializeField]
        private RectTransform ScrollContent = null;
        [SerializeField]
        private Transform arrowUp = null;
        [SerializeField]
        private Transform arrowDown = null;
        private static SelectionSystem instance = null;
        public static SelectionSystem Instance { get => instance; set => instance = value; }
        private int m_Counter = 0;
        private int m_Counter1 = 0;        
        private List<float> carPosition = new List<float>();
        private Sequence mySequence = null;
        

        private void Awake()
        {

            instance = this;

        }
        // Start is called before the first frame update
        void Start()
        {

           
            float value = arrowDown.localPosition.x;
            foreach (var car in carsData.Cars)
            {

                var card = LeanPool.Spawn(PlayerCard, m_panel.transform);
                card.CarSprite = car.SpriteCar;
                carPosition.Add(value);
                value = value + 164f;


            }



            //Debug.Log(positionCar.Length);
            mySequence = DOTween.Sequence();


        }

        public void SelectTheNextCar()
        {
            
            if (m_Counter < 2)
            {
                m_Counter++;
                mySequence.Append(arrowDown.DOLocalMoveX(carPosition[m_Counter], 1))
                    .Join(arrowUp.DOLocalMoveX(carPosition[m_Counter], 1));
                m_Counter1++;
                Debug.Log(m_Counter);
                return;
            }
            if (ScrollContent.localPosition.x <= -820)
            {
                return;
            }
            else
            {
                Debug.Log(m_Counter);
                //mySequence.Append(ScrollContent.DOLocalMoveX(ScrollContent.localPosition.x - 168, 1));

                mySequence.Append(ScrollContent.DOLocalMoveX(-carPosition[m_Counter1], 1));
                if (m_Counter1 < carPosition.Count - 1)
                {
                    m_Counter1++;
                }
            }

        }

        public void SelectThePreviousCar()
        {

            if (m_Counter == 0)
            {
                if (ScrollContent.localPosition.x >= -10)
                {
                    return;
                }
                    m_Counter = 0;
                //mySequence.Append(ScrollContent.DOLocalMoveX(ScrollContent.localPosition.x + 168, 1));
                mySequence.Append(ScrollContent.DOLocalMoveX(-carPosition[m_Counter1], 1));
                if (m_Counter1 != 0) {
                    m_Counter1--;
                }
                Debug.Log(m_Counter);
                return;


            }

            
            if (m_Counter < 3)
            {

                m_Counter--;
                mySequence.Append(arrowDown.DOLocalMoveX(carPosition[m_Counter], 1))
                    .Join(arrowUp.DOLocalMoveX(carPosition[m_Counter], 1));
                m_Counter1--;
                Debug.Log(m_Counter);
                return;

            }
            

        }
        // Update is called once per frame
        void Update()
        {

        }
    }
}