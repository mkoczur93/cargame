namespace Player
{
    using System.Collections;
    using System.Collections.Generic;
    using UnityEngine;
    using Car;
    using RacingMap;
    using MainProject;
    using Zenject;

    [RequireComponent(typeof(Rigidbody2D))]
    public class PlayerMovementController : MonoBehaviour
    {
      
        [SerializeField]
        private CarData carData = null;
        private Rigidbody2D rb = null;
        private Vector2 speed = Vector2.zero;
        private bool isMotion = false;
        private bool startGame = false;
        private const float driftForceFactor = 2f;
        [Inject]
        private readonly IMapController m_MapController = null;
        [Inject]
        private readonly IBrakeTrack m_BrakeTrack = null;
        private TrailRenderer m_PooledObject = null;
      

        private void Awake()
        {
            m_MapController.SubscribeOnStartGame(StartGame);
            m_MapController.SubscribeOnPausedGame(PausedGame);

        }
        private void Start()
        {
            speed = carData.Speed;
            this.rb = GetComponent<Rigidbody2D>();
            rb.drag = carData.BasicDrag;                        
            
            
        }
       

       
       private void FixedUpdate()
       {
           if (startGame == true)
         {
            PlayerMovement();
         }
           

     }
        private void  StartGame()
        {
            startGame = true;
            
        }
        private void PausedGame()
        {
            startGame = false;

        }
        private void EndGame()
        {
            startGame = !startGame;

        }
        private void OnDestroy()
        {
            m_MapController.UnSubscribeOnStartGame(StartGame);
            m_MapController.UnSubscribeOnPausedGame(PausedGame);

        }
        private void Update()
        {
            CheckCurrentSpeed();
            CheckBraking();
        }

        public void PlayerMovement()
        {
           


            if (Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.S))
            {

                //Debug.Log(rb.drag);               
                speed = transform.up * (Input.GetAxis("Vertical") * carData.Acceleration);
                rb.AddForce(speed);
                float driftForce = Vector2.Dot(rb.velocity, rb.GetRelativeVector(Vector2.left)) * driftForceFactor;
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

                float driftForce = Vector2.Dot(rb.velocity, rb.GetRelativeVector(Vector2.left)) * driftForceFactor;
                Vector2 relativeForce = Vector2.right * driftForce;
                rb.AddForce(rb.GetRelativeVector(relativeForce));
            }

            if (rb.velocity.magnitude > carData.MaxSpeed)
            {
                rb.velocity = rb.velocity.normalized * carData.MaxSpeed;
            }




        }

        public void CheckBraking()
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                m_PooledObject = m_BrakeTrack.GetPooledObject();
                m_PooledObject.transform.SetParent(this.transform);
                m_PooledObject.transform.localPosition = Vector3.zero;
                m_PooledObject.enabled = true;

            }
            if (Input.GetKey(KeyCode.Space))
            {
                rb.drag = carData.BrakingSpeed;

            }
            if (Input.GetKeyUp(KeyCode.Space))
            {
                if (rb.drag != carData.BasicDrag)
                {
                    rb.drag = carData.BasicDrag;
                    m_PooledObject.transform.SetParent(null);
                    m_BrakeTrack.StartCorutinePutItBackInPooledObjects(m_PooledObject);

                }
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