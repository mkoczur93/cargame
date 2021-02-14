namespace Car
{
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

    [CreateAssetMenu(fileName = "Data", menuName = "Data/CarPlayerData", order = 1)]
    public class CarPlayerData : ScriptableObject
    {
        [SerializeField]
        private List<Sprite> cars = null;



        public List<Sprite> Cars
        {
            get => cars;
        }

    }
}