namespace RacingMap
{

    using System.Collections;
    using System.Collections.Generic;
    using UnityEngine;
    using MainProject.UI;
    using System;
    using ObjectTagData;

    public class LapsSystem : MonoBehaviour
    {
        [SerializeField]
        LapCheckpoint[] baseCheckpoints = null;
        [SerializeField]
        private List<LapCheckpoint> lap_checkpoints = new List<LapCheckpoint>();
        private static LapsSystem instance = null;
        private Action OnCheckPointReached = null;


        public static LapsSystem Instance { get => instance; set => instance = value; }


        private void Awake()
        {
            instance = this;

        }

        void Start()
        {

            baseCheckpoints = GetComponentsInChildren<LapCheckpoint>();



        }



        public void RegisterCheckpoint(LapCheckpoint checkpoint)
        {
            if (lap_checkpoints.Contains(checkpoint))
            {
                lap_checkpoints.Remove(checkpoint);
            }
            lap_checkpoints.Add(checkpoint);
        }




        public void SubscribeOnCheckPointReached(Action action)
        {
            OnCheckPointReached += action;
        }
        public void UnSubscribeOnCheckPointReached(Action action)
        {
            OnCheckPointReached -= action;
        }



        void OnTriggerEnter2D(Collider2D col)
        {

            if (col.CompareTag(ObjectTagData.Player))
            {

                if (lap_checkpoints.Count == 0)
                    return;

                for (int i = 0; i < lap_checkpoints.Count; i++)
                {
                    if (lap_checkpoints[i] != baseCheckpoints[i])
                    {
                        return;
                    }
                }


                LapTimeSystem.Instance.AddLapTime();


                //GameGUIViewModel.Instance.CounterLaps += 1;
                OnCheckPointReached?.Invoke();







            }
        }
    }
}