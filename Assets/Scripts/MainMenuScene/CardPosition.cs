namespace MainProject.Card
{
    using MainProject.UI;
    using System.Collections;
    using System.Collections.Generic;
    using UnityEngine;

    public class CardPosition
    {
        private int m_id;
        private float m_position;
        private PlayerCardViewModel m_card;

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
        public PlayerCardViewModel Card
        {
            get => m_card;
            set => m_card = value;

        }
    }
}