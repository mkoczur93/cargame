namespace RacingMap
{
    using System.Collections;
    using System.Collections.Generic;
    using UnityEngine;

    [CreateAssetMenu(fileName = "Data", menuName = "Data/MapListData", order = 1)]
    public class MapListData : ScriptableObject
    {
        [SerializeField]
        private List<Map> maps = null;



        public List<Map> Maps
        {
            get => maps;
        }

    }
}