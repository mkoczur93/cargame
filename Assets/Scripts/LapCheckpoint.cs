namespace RacingMap
{

    using System.Collections;
    using System.Collections.Generic;
    using UnityEngine;    
    using System;
    using ObjectTagData;
    

    public class LapCheckpoint : MonoBehaviour
    {
    

        void OnTriggerExit2D(Collider2D col)
        {
            if (col.CompareTag(ObjectTagData.Player))            {
                

                LapsSystem.Instance.RegisterCheckpoint(this);

            }
        }

    }
}