namespace Car
{
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using UnityEngine;
    [Serializable]
    public class SpritePlayerCar
    {
        [SerializeField]
        private int m_IdSprite = 0;
        [SerializeField]
        private Sprite m_SpriteCar = null;
        
        public int IdSprite
        {
            get => m_IdSprite;
        }
        public Sprite SpriteCar
        {
            get => m_SpriteCar;
        }
    }
}