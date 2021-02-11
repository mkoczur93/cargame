namespace MainProject
{
    using Lean.Pool;
    using MainProject.UI;
    using RacingMap;
    using System.Collections;
    using System.Collections.Generic;
    using UnityEngine;

    public class MapController : MonoBehaviour
    {
        [SerializeField]
        private List<GameObject> cars = null;
        [SerializeField]
        private DefaultMapSettings settings = null;
        private GameObject selectedCar = null;
        [SerializeField]
        private GameObject camera = null;

        private static MapController instance = null;
        public static MapController Instance { get => instance; set => instance = value; }
        
        
        public GameObject SelectedCar
        {
            get => selectedCar;
        }
        private void Awake()
        {
            instance = this;
            selectedCar = LeanPool.Spawn(cars[0]);
            if(camera != null)
            camera = LeanPool.Spawn(camera);
            
            

        }
        // Start is called before the first frame update
        void Start()
        {
            SetStartDefaultPosition();
        }
        public void SetStartDefaultPosition()
        {
            if (selectedCar.TryGetComponent<Rigidbody2D>(out var player))
            {
                player.velocity = Vector2.zero;
                player.transform.eulerAngles = settings.StartCarRotation;
                player.transform.position = settings.StartCarPosition;                
                //player.transform.position = Vector3.zero;
            }
            if (camera != null)
                
            {
                camera.transform.position = settings.StartCameraPosition;
                camera.transform.eulerAngles = settings.StartCameraRotation;

            }
            LapTimeSystem.Instance.ClearAllLapTimes();
            LapTimeSystem.Instance.CurrentTime = settings.StartTime;
            StartRacingAnim.Instance.StartAnim = true;
            LapsSystem.Instance.SetInitialLap();
            LapsSystem.Instance.ClearLapCheckpoints();
            StartRacingAnim.Instance.StartCoroutineAnim();
           
            
        }
     
    }
}
