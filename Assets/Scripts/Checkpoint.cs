namespace RacingMap
{

    using System.Collections;
    using System.Collections.Generic;
    using UnityEngine;    
    using System;
    

    public class Checkpoint
    {

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
        
        public Checkpoint(int id, bool passed)
        {
            idTrigger = id;
            triggerPassed = passed;
        }


    }
}