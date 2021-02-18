namespace MainProject.Card
{
    using MainProject.UI;
    using System.Collections;
    using System.Collections.Generic;
    using UnityEngine;

    public class CardMapPosition
    {
        private int m_id;
        private float m_position;
        private MapCardViewModel m_card;

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
        public MapCardViewModel Card
        {
            get => m_card;
            set => m_card = value;

        }
    }
}