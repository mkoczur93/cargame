namespace Camera
{
    using System.Collections;
    using System.Collections.Generic;
    using UnityEngine;
    using Camera;
    using Player;
    using MainProject;
    using Zenject;
    using RacingMap;

    public class CameraController : MonoBehaviour
    {

        [SerializeField]
        private CameraData cam = null;
        [SerializeField]
        private PlayerMovementController player = null;
        private PlayerMovementController playerController = null;
        private const float cameraPositionZ = -10f;
        private Vector3 offset = Vector3.zero;
        private DefaultMapSettings m_Settings = null;
        [Inject]
        IGameManager m_GameManager = null;
        [Inject]
        IMapController m_MapController = null;

        void Start()
        {
            m_Settings = m_GameManager.SelectedDefaultMapSettings;
            this.transform.position = m_Settings.StartCameraPosition;
            this.transform.eulerAngles = m_Settings.StartCameraRotation;            
            player = m_MapController.SelectedCar;            
            playerController = player.GetComponent<PlayerMovementController>();
            offset = transform.position - player.transform.position;
            m_MapController.SubscribeOnPausedGame(SetDefaultPosition);
        }


        void Update()
        {

            MovingCamera();
            

        }
        public void SetDefaultPosition()
        {
            this.transform.position = m_Settings.StartCameraPosition;
            this.transform.eulerAngles = m_Settings.StartCameraRotation;
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

        private void OnDestroy()
        {
            m_MapController.UnSubscribeOnPausedGame(SetDefaultPosition);
        }
    }
}