namespace Camera
{
    using System.Collections;
    using System.Collections.Generic;
    using UnityEngine;
    using Camera;
    using Player;
    using MainProject;

    public class CameraController : MonoBehaviour
    {

        [SerializeField]
        private CameraData cam = null;
        [SerializeField]
        private PlayerMovementController player = null;
        private PlayerMovementController playerController = null;
        private const float cameraPositionZ = -10f;
        private Vector3 offset = Vector3.zero;

        void Start()
        {
            player = MapController.Instance.SelectedCar;
            playerController = player.GetComponent<PlayerMovementController>();
            offset = transform.position - player.transform.position;
        }


        void Update()
        {

            MovingCamera();


        }

        public void MovingCamera()
        {
            
            if (playerController != null && playerController.IsMotion == true)
            {

                float interpolation = cam.Speed * Time.deltaTime;
                Vector3 position = this.transform.position;
                position.y = Mathf.Lerp(this.transform.position.y, player.transform.position.y + offset.y, interpolation);
                position.x = Mathf.Lerp(this.transform.position.x, player.transform.position.x + offset.x, interpolation);
                position.z = cameraPositionZ;
                this.transform.position = position;
            }


        }
    }
}