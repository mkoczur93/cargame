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

        public PlayerMovementController SelectedCar
        {
            get => m_SelectedCar;
            set => m_SelectedCar = value;
        }

        public DefaultMapSettings SelectedDefaultMapSettings
        {
            get => m_SelectedDefaultMapSettings;
            set => m_SelectedDefaultMapSettings = value;
        }

     
    }
}