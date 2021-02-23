namespace RacingMap
{

    using System.Collections;
    using System.Collections.Generic;
    using UnityEngine;    
    using System;
    

    public class Checkpoint
    {

        private int m_IdTrigger = 0;        
        private bool m_TriggerPassed = false;

        public int IdTrigger
        {
            get => m_IdTrigger;
            set => m_IdTrigger = value;
        }
        public bool TriggerPassed
        {
            get => m_TriggerPassed;
            set => m_TriggerPassed = value;
        }
        
        public Checkpoint(int id, bool passed)
        {
            m_IdTrigger = id;
            m_TriggerPassed = passed;
        }


    }
}