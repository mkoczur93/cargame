namespace RacingMap
{

    using System.Collections;
    using System.Collections.Generic;
    using UnityEngine;    
    using System;
    

    public class LapCheckpoint : MonoBehaviour
    {
        private string Player = null;
        private int idTrigger = 0;        
        private bool triggerPassed = false;

        public int IdTrigger
        {
            get => idTrigger;
            set => idTrigger = value;
        }
        public bool TriggerPassed
        {
            get => triggerPassed;
            set => triggerPassed = value;
        }
        private void Start()
        {
            Player = ObjectTagData.ObjectTagData.Player;
        }
        public LapCheckpoint(int id, bool passed)
        {
            idTrigger = id;
            triggerPassed = passed;
        }
        void OnTriggerEnter2D(Collider2D col)
        {
            if (col.CompareTag(Player))
            {
                //Debug.Log(this.GetInstanceID());
                
               LapsSystem.Instance.CheckTheCheckpoint(this.GetInstanceID());

            }
        }

    }
}