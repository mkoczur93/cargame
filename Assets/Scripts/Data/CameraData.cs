namespace Camera
{
    using System.Collections;
    using System.Collections.Generic;
    using UnityEngine;

    [CreateAssetMenu(fileName = "Data", menuName = "Data/CameraData", order = 1)]
    public class CameraData : ScriptableObject
    {


        [SerializeField]
        private float speed = 1f;


        public float Speed
        {

            get
            {
                return speed;
            }
        }


    }
}