namespace RacingMap
{

    using System.Collections;
    using System.Collections.Generic;
    using UnityEngine;    
    using System;
    using ObjectTagData;
    

    public class LapCheckpoint : MonoBehaviour
    {
    

        void OnTriggerEnter2D(Collider2D col)
        {
            if (col.CompareTag(ObjectTagData.Player))
            {
                //Debug.Log(this.GetInstanceID());
                
               LapsSystem.Instance.CheckTheCheckpoint(this.GetInstanceID());

            }
        }

    }
}