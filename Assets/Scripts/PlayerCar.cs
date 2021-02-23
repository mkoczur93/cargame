namespace Car
{
    using Player;
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using UnityEngine;
    [Serializable]
    public class PlayerCar
    {
        [SerializeField]
        private int id = 0;
        [SerializeField]
        private string nameCar = string.Empty;     

        public int Id
        {
            get => id;
            set
            {
                id = value;
            }
        }
        public string NameCar
        {
            get => nameCar;
            set
            {
                nameCar = value;
            }
        }
  

    }
}