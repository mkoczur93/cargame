namespace ObjectTagData
{
    using System.Collections;
    using System.Collections.Generic;
    using UnityEngine;

    [CreateAssetMenu(fileName = "Data", menuName = "Data/ObjectTagData", order = 1)]
    public class ObjectTagData : ScriptableObject
    {
        [SerializeField]
        private static string player = "Player";

        public static string Player
        {
            get
             {
                return player;
            }
                
        }
    }
}