namespace RacingMap
{

    using System.Collections;
    using System.Collections.Generic;
    using UnityEngine;    
    using System;
    

    public class CheckPointLaps : MonoBehaviour
    {
        private string Player = ObjectTagData.ObjectTagData.Player;
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