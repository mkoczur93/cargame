namespace Car
{
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using UnityEngine;

    public class SpritePlayerCarData
    {

        private readonly Settings m_settings;
        public SpritePlayerCarData(Settings settings)
        {
            m_settings = settings;
        }
        [Serializable]
        public class Settings
        {
            [SerializeField]
            private List<SpritePlayerCar> m_SpriteCars = null;
            public List<SpritePlayerCar> SpriteCars
            {
                get => m_SpriteCars;
            }

        }
    }
}