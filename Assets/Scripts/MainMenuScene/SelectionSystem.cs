namespace Car
{

    using System.Collections;
    using System.Collections.Generic;
    using UnityEngine;
    using UnityEngine.UI;

    public class SelectionSystem : MonoBehaviour
    {
        [SerializeField]
        private CarPlayerData m_cars = null;
        private List<Sprite> m_playerCars = null;
        private static SelectionSystem instance = null;
        public static SelectionSystem Instance { get => instance; set => instance = value; }
        [SerializeField]
        private Image m_selectedCar = null;
        [SerializeField]
        private Image m_previousCar = null;
        [SerializeField]
        private Image m_nextCar = null;
        private int m_Counter = 1;

        private void Awake()
        {
            
            instance = this;

        }
        // Start is called before the first frame update
        void Start()
        {
            m_playerCars = m_cars.Cars;
            Debug.Log(m_playerCars.Count);
            m_previousCar = m_previousCar.GetComponent<Image>();
            m_previousCar.sprite = m_playerCars[m_Counter-1];
            m_selectedCar.GetComponent<Image>();
            m_selectedCar.sprite = m_playerCars[m_Counter];
            m_nextCar.GetComponent<Image>();
            m_nextCar.sprite = m_playerCars[m_Counter+1];
        }

        public void SelectTheNextCar()
        {
            m_Counter++;
            if(m_Counter > m_playerCars.Count-1)
            {
                m_Counter = 0;
            }
            if(m_Counter == 0)
            {
                m_previousCar.sprite = m_playerCars[m_playerCars.Count - 1];
                m_selectedCar.sprite = m_playerCars[m_Counter];
                m_nextCar.sprite = m_playerCars[m_Counter+1];
                return;
                
            }
            if (m_Counter == m_playerCars.Count - 1)
            {
                m_previousCar.sprite = m_playerCars[m_Counter - 1];
                m_selectedCar.sprite = m_playerCars[m_Counter];
                m_nextCar.sprite = m_playerCars[0];
                return;


            }

            

                m_previousCar.sprite = m_playerCars[m_Counter-1];
                m_selectedCar.sprite = m_playerCars[m_Counter];
                m_nextCar.sprite = m_playerCars[m_Counter + 1];
            
        }

        public void SelectThePreviousCar()
        {
            m_Counter--;
            if (m_Counter < 0)
            {
                m_Counter = m_playerCars.Count - 1;
            }
            if (m_Counter == 0)
            {
                m_previousCar.sprite = m_playerCars[m_playerCars.Count - 1];
                m_selectedCar.sprite = m_playerCars[m_Counter];
                m_nextCar.sprite = m_playerCars[m_Counter + 1];
                return;

            }
            if (m_Counter == m_playerCars.Count - 1)
            {
                m_previousCar.sprite = m_playerCars[m_Counter - 1];
                m_selectedCar.sprite = m_playerCars[m_Counter];
                m_nextCar.sprite = m_playerCars[0];
                return;


            }



            m_previousCar.sprite = m_playerCars[m_Counter - 1];
            m_selectedCar.sprite = m_playerCars[m_Counter];
            m_nextCar.sprite = m_playerCars[m_Counter + 1];

        }
        // Update is called once per frame
        void Update()
        {

        }
    }
}