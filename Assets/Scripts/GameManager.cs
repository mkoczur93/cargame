namespace MainProject.GameManager
{
    using Player;
    using RacingMap;
    using System.Collections;
    using System.Collections.Generic;
    using UnityEngine;

    public class GameManager : IGameManager
    {
        [SerializeField]
        private PlayerMovementController m_SelectedCar = null;
        [SerializeField]
        private DefaultMapSettings m_SelectedDefaultMapSettings = null;
        private int m_Laps = 0;

       public int Laps
        {
            get => m_Laps;
        }
        public PlayerMovementController SelectedCar
        {
            get => m_SelectedCar;            
        }

        public DefaultMapSettings SelectedDefaultMapSettings
        {
            get => m_SelectedDefaultMapSettings;
            set
            {
                m_SelectedDefaultMapSettings = value;
            }
        }
        public void SetSelectedCar(PlayerMovementController SelectedCar, Sprite SpriteCar)
        {
            m_SelectedCar = SelectedCar;
            m_SelectedCar.GetComponent<SpriteRenderer>().sprite = SpriteCar;
        }
        public void SetLaps(int Laps)
        {
            m_Laps = Laps;
        }
    }
}