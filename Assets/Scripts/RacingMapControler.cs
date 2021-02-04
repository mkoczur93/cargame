namespace RacingMap
{
    using System.Collections;
    using System.Collections.Generic;
    using UnityEngine;
    using Car;
    using Player;
    using System;



    public class RacingMapControler : MonoBehaviour

    {

        [SerializeField]
        private Car.CarData carData = null;
        [SerializeField]
        private const float slowingDown = 2f;        
        private string Player = ObjectTagData.ObjectTagData.Player;


        void OnTriggerEnter2D(Collider2D col)
        {
            if (col.CompareTag(Player))
            {
                if (col.TryGetComponent<Rigidbody2D>(out var player))

                {
                    //Debug.Log(player);
                    //Debug.Log(Player);                
                    player.drag = slowingDown;
                }


            }
        }
        void OnTriggerExit2D(Collider2D col)
        {
            if (col.CompareTag(Player))
            {
                if (col.TryGetComponent<Rigidbody2D>(out var player))
                {
                    //Debug.Log(player);
                    //Debug.Log(Player);
                    player.drag = carData.BasicDrag;
                }

            }
        }



    }
}
