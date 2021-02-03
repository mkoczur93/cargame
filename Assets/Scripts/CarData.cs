using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace Car
{
    [CreateAssetMenu(fileName = "Data", menuName = "Data/CarData", order = 1)]
    public class CarData : ScriptableObject
    {
        [SerializeField]
        private float maxSpeed = 4f;
        [SerializeField]
        private float acceleration = 3f;
        [SerializeField]
        private float steering = 2f;
        [SerializeField]
        private float direction = 0f;
        [SerializeField]
        private Vector2 speed = Vector2.zero;
        [SerializeField]
        private float brakingSpeed = 2f;
        [SerializeField]
        private float basicDrag = 0.2f;



        public float MaxSpeed
        {

            get
            {
                return maxSpeed;

            }
        }

        public float Acceleration
        {

            get
            {
                return acceleration;
            }

        }


        public float Steering
        {

            get
            {
                return steering;
            }
        }

        public float Direction
        {
            get
            {
                return direction;
            }
        }

        public Vector2 Speed
        {
            get
            {
                return speed;
            }

        
        }


        public float BrakingSpeed
        {
            get
            {
                return brakingSpeed;
            }
        }
        public float BasicDrag
        {
            get
            {
                return basicDrag;
            }
        }

    }
}