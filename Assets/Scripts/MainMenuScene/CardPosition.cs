namespace MainProject.Card
{
    using System.Collections;
    using System.Collections.Generic;
    using UnityEngine;

    public class CardPosition
    {
        private int m_id;
        private float m_position;

        public int Id
        {
            get => m_id;
            set => m_id = value;
        }
        public float Position
        {
            get => m_position;
            set => m_position = value;
        }
    }
}