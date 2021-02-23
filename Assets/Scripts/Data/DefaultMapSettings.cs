namespace RacingMap
{
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using UnityEngine;

   [Serializable]
    public class DefaultMapSettings
    {
        [SerializeField]
        private Vector3 startCarPosition = Vector3.zero;
        [SerializeField]
        private Vector3 startCarRotation = Vector3.zero;
        [SerializeField]
        private Vector3 startCameraPosition = Vector3.zero;
        [SerializeField]
        private Vector3 startCameraRotation = Vector3.zero;
        [SerializeField]
        private int initialLap = 0;        
        [SerializeField]
        private float startTime = 0f;

        public Vector3 StartCarPosition { get => startCarPosition; set => startCarPosition = value; }
        public Vector3 StartCarRotation { get => startCarRotation; set => StartCarRotation = value; }
        public Vector3 StartCameraPosition { get => startCameraPosition; set => startCameraPosition = value; }
        public Vector3 StartCameraRotation { get => startCameraRotation; set => startCameraRotation = value; }
        public int InitialLap { get => initialLap; set => initialLap = value; }
        public float StartTime { get => startTime; set => startTime = value; }

    }
}