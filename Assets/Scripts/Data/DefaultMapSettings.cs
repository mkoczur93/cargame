namespace RacingMap
{
    using System.Collections;
    using System.Collections.Generic;
    using UnityEngine;

    [CreateAssetMenu(fileName = "Data", menuName = "Data/DefaultMapSettings", order = 1)]
    public class DefaultMapSettings : ScriptableObject
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
        private int maxLaps = 0;
        [SerializeField]
        private float startTime = 0f;

        public Vector3 StartCarPosition { get => startCarPosition; }
        public Vector3 StartCarRotation { get => startCarRotation; }
        public Vector3 StartCameraPosition { get => startCameraPosition; }
        public Vector3 StartCameraRotation { get => startCameraRotation; }
        public int InitialLap { get => initialLap; }
        public int MaxLaps  {get => maxLaps;}
        public float StartTime { get => startTime; }
        
    }
}