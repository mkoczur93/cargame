namespace RacingMap
{

    using System.Collections;
    using System.Collections.Generic;
    using UnityEngine;    
    using System;
    using ObjectTagData;
    using Zenject;

    public class LapCheckpoint : MonoBehaviour
    {

        [Inject]
        private readonly ILapsSystem m_LapsSystem = null;
        void OnTriggerExit2D(Collider2D col)
        {
            if (col.CompareTag(ObjectTagData.Player))            {

                
                m_LapsSystem.RegisterCheckpoint(this);

            }
        }

    }
}