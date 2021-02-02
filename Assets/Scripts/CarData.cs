using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(fileName = "Data", menuName = "Data/CarData", order = 1)]
public class CarData :ScriptableObject
{
    [SerializeField]
    private float maxSpeed = 4f;
    [SerializeField]
    private float acceleration = 3f;
    [SerializeField]
    private float steering = 2f;
    [SerializeField]
    private float direction = 0f;
    [SerializeField]
    private Vector2 speed = new Vector2(0f,0f);
    [SerializeField]
    private float brakingSpeed = 2f;



    public float MaxSpeed
    {

        get
        {
            return maxSpeed;

        }
    }

    public float Acceleration
    {

        get
        {
            return acceleration;
        }

        set
        {
            acceleration = value;
        }
    }


    public float Steering
    {

        get
        {
            return steering;
        }
    }

    public float Direction
    {
        get
        {
            return direction;
        }
    }

    public Vector2 Speed
    {
        get
        {
            return speed;
        }

        set
        {
            speed = value;
        }
    }


    public float BrakingSpeed
    {
        get
        {
            return brakingSpeed;
        }
    }


}
