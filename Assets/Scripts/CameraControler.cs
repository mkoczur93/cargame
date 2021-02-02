using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraControler : MonoBehaviour
{
   // [SerializeField]
   // public GameObject player;     
   
    //private Vector3 offset;
   // [SerializeField]
   // private float speed = 1f;
    [SerializeField]
    private CameraData cam = null;
    [SerializeField]
    private GameObject player = null;

    void Start()
    {

        cam.Offset = transform.position - player.transform.position;
    }


    void Update()
    {

        MovingCamera();


    }

    public void MovingCamera()
    {
        float interpolation = cam.Speed * Time.deltaTime;


        Vector3 position = this.transform.position;
        position.y = Mathf.Lerp(this.transform.position.y, player.transform.position.y + cam.Offset.y, interpolation);
        position.x = Mathf.Lerp(this.transform.position.x, player.transform.position.x + cam.Offset.x, interpolation);
        position.z = -10f;
        this.transform.position = position;


    }
}
