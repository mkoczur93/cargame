namespace GameManager
{
    using Player;
    using System.Collections;
    using System.Collections.Generic;
    using UnityEngine;

    public class GameManager : MonoBehaviour
    {
        [SerializeField]
        private PlayerMovementController m_SelectedCar = null;
        private static GameManager instance = null;
        public static GameManager Instance { get => instance; set => instance = value; }

        public PlayerMovementController SelectedCar
        {
            get => m_SelectedCar;
            set => m_SelectedCar = value;
        }

       
        private void Awake()
        {
            instance = this;
            
            DontDestroyOnLoad(this);
            
            

        }
    }
}