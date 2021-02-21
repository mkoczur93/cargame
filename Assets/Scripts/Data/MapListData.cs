namespace RacingMap
{
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using UnityEngine;

    public class MapListData
    {
        private readonly Settings m_settings;
        public MapListData(Settings settings)
        {
            m_settings = settings;
        }
        [Serializable]
        public class Settings
        {
            [SerializeField]
            private List<Map> maps = null;
            public List<Map> Maps
            {
                get => maps;
            }

        }


     

    }
}