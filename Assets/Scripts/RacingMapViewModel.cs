using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RacingMapViewModel : MonoBehaviour

{
    
    [SerializeField]
    private CarData carData;
    private PlayerMovementViewModel player;
    [SerializeField]
    private float slowingDown = 2f;

 
    void OnTriggerStay2D(Collider2D col)
    {
        if (col.tag == "Player") 
        {            
            player = col.GetComponent<PlayerMovementViewModel>();
            player.Drag = slowingDown;

       }
    }
    void OnTriggerExit2D(Collider2D col)
    {
        if (col.tag == "Player")
        {
            player = col.GetComponent<PlayerMovementViewModel>();
            player.Drag = 0f;
        }
    }



}
