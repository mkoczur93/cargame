namespace Car
{
    using System.Collections.Generic;
    using UnityEngine;
    using System;
    public class CarPlayerData
    {
        private readonly Settings m_settings;
        public CarPlayerData(Settings settings)
        {
            m_settings = settings;
        }
        [Serializable]
        public class Settings
        {
            [SerializeField]
            private List<PlayerCar> cars = null;
            public List<PlayerCar> Cars
            {
                get => cars;
            }
        }
    }
}