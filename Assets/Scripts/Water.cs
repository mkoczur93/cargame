namespace RacingMap
{

    using System.Collections;
    using System.Collections.Generic;
    using UnityEngine;
    using System;
    using ObjectTagData;
    using Car;

    public class Water : MonoBehaviour
    {
        [SerializeField]
        private CarData m_carData = null;
        private const float m_slowingDown = 0.8f;
        private const float m_streamWater = 1.5f;
        private const float m_slowingDownEnterRiver = 1.25f;

        //Do zmiany
        void OnTriggerEnter2D(Collider2D col)
        {
            if (col.CompareTag(ObjectTagData.Player))
            {
                if (col.TryGetComponent<Rigidbody2D>(out var player))
                {
                    player.drag = m_slowingDown;
                    player.velocity = player.velocity / m_slowingDownEnterRiver;

                }
               

            }
        }

        void OnTriggerStay2D(Collider2D col)
        {
            if (col.CompareTag(ObjectTagData.Player))
            {
                
              col.GetComponent<Rigidbody2D>().AddForce(new Vector2(0, m_streamWater));
                
               
            }
        }

        void OnTriggerExit2D(Collider2D col)
        {
            if (col.CompareTag(ObjectTagData.Player))
            {
                
                if (col.TryGetComponent<Rigidbody2D>(out var player))
                {
                    
                    player.drag = m_carData.BasicDrag;
                    Debug.Log(player.drag);

                }
             

            }
        }

    }
}