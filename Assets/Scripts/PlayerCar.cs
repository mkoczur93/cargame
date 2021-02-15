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
        [SerializeField]
        private Sprite spriteCar = null;
        [SerializeField]
        private PlayerMovementController car = null;

        public int Id
        {
            get => id;
        }
        public string NameCar
        {
            get => nameCar;
        }
        public Sprite SpriteCar
        {
            get => spriteCar;
        }
        public PlayerMovementController Car
        {
            get => car;
        }

    }
}