namespace RacingMap
{
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using UnityEngine;
    
    [Serializable]
    public class Map
    {
        [SerializeField]
        private int id = 0;
        [SerializeField]
        private string nameMap = string.Empty;
        [SerializeField]
        private Sprite spriteMap = null;
        [SerializeField]
        private DefaultMapSettings mapSetings = null;

        public int Id
        {
            get => id;
        }
        public string NameMap
        {
            get => nameMap;
        }
        public Sprite SpriteMap
        {
            get => spriteMap;
        }
        public DefaultMapSettings MapSetings
        {
            get => mapSetings;
        }

    }
}
