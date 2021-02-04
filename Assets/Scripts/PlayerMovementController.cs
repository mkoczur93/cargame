﻿namespace Player
{
    using System.Collections;
    using System.Collections.Generic;
    using UnityEngine;
    using Car;


    [RequireComponent(typeof(Rigidbody2D))]
    public class PlayerMovementController : MonoBehaviour
    {
        // public float maxSpeed;
        // public float acceleration;
        //  public float steering;
        //  public float direction;
        //   Vector2 speed;

        [SerializeField]
        private CarData carData = null;
        private Rigidbody2D rb = null;
        private Vector2 speed = Vector2.zero;
        private bool isMotion = false;


        private void Start()
        {
            speed = carData.Speed;
            this.rb = GetComponent<Rigidbody2D>();
            rb.drag = carData.BasicDrag;
        }

        private void FixedUpdate()
        {
            PlayerMovement();

        }
        private void Update()
        {
            //Debug.Log(currentSpeed);
            CheckCurrentSpeed();

        }

        public void PlayerMovement()
        {
            if (Input.GetKey(KeyCode.Space))
            {
                rb.drag = carData.BrakingSpeed;
            }
            if (Input.GetKeyUp(KeyCode.Space))
            {
                if (rb.drag != carData.BasicDrag)
                {
                    rb.drag = carData.BasicDrag;
                }
            }


            if (Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.S))
            {

                //Debug.Log(rb.drag);               
                speed = transform.up * (Input.GetAxis("Vertical") * carData.Acceleration);
                rb.AddForce(speed);
                float driftForce = Vector2.Dot(rb.velocity, rb.GetRelativeVector(Vector2.left)) * 2.0f;
                Vector2 relativeForce = Vector2.right * driftForce;
                rb.AddForce(rb.GetRelativeVector(relativeForce));
            }




            if (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.D))
            {
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
            }

            if (rb.velocity.magnitude > carData.MaxSpeed)
            {
                rb.velocity = rb.velocity.normalized * carData.MaxSpeed;
            }




        }


        public void CheckCurrentSpeed()
        {
            if (rb.velocity != Vector2.zero)
                isMotion = true;
            else
                isMotion = false;
        }


        public bool IsMotion
        {
            get
            {
                return isMotion;
            }
        }

    }
}