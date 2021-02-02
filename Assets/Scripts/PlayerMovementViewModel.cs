using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[RequireComponent(typeof(Rigidbody2D))]
public class PlayerMovementViewModel : MonoBehaviour
{
    // public float maxSpeed;
    // public float acceleration;
    //  public float steering;
    //  public float direction;
    //   Vector2 speed;

    [SerializeField]
    private CarData carData = null;
    private Rigidbody2D rb = null;
    private float drag =  0f;


    private void Start()
    {
        
        this.rb = GetComponent<Rigidbody2D>();
    }

    private void FixedUpdate()
    {
        PlayerMovement();

    }

    public void PlayerMovement()
    {
        if (Input.GetKey(KeyCode.Space))
        {
            rb.drag = carData.BrakingSpeed;
        }
        if (!Input.GetKey(KeyCode.Space))
        {
            rb.drag = drag;
            //Debug.Log(rb.drag);
            carData.Speed = transform.up * (Input.GetAxis("Vertical") * carData.Acceleration);
            rb.AddForce(carData.Speed);
            //Debug.Log(speed);
        }



        float direction = Vector2.Dot(rb.velocity, rb.GetRelativeVector(Vector2.up));
        // Debug.Log(direction);
        if (direction >= 0.0f)
        {
            rb.rotation += -Input.GetAxis("Horizontal") * carData.Steering * (rb.velocity.magnitude / carData.MaxSpeed);
            // Debug.Log(rb.velocity.magnitude);

        }
        else
        {
            rb.rotation -= -Input.GetAxis("Horizontal") * carData.Steering * (rb.velocity.magnitude / carData.MaxSpeed);
            //Debug.Log(rb.rotation);
        }



        float driftForce = Vector2.Dot(rb.velocity, rb.GetRelativeVector(Vector2.left)) * 2.0f;
        Vector2 relativeForce = Vector2.right * driftForce;
        rb.AddForce(rb.GetRelativeVector(relativeForce));


        if (rb.velocity.magnitude > carData.MaxSpeed)
        {
            rb.velocity = rb.velocity.normalized * carData.MaxSpeed;
        }




    }

    public float Drag
    {
        set
        {
            drag = value;
        }
    }
    
}
