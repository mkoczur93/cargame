using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Data", menuName = "Data/CameraData", order = 1)]
public class CameraData : ScriptableObject
{

    [SerializeField]
    private Vector3 offset;
    [SerializeField]
    private float speed = 1f;

   public Vector3 Offset
    {
        get
        {
            return offset;
        }
        set
        {
            offset = value;
        }


    }
    public float Speed
    {

        get
        {
            return speed;
        }
    }

    
}
