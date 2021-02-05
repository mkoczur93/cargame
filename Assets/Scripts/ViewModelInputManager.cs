namespace MainProject.UI
{
    using System.Collections;
    using System.Collections.Generic;
    using UnityEngine;

    public class ViewModelInputManager : MonoBehaviour
    {
        
        // Start is called before the first frame update
        void Start()
        {
            //ViewModelController.Instance;
        }

        // Update is called once per frame
        void Update()
        {

        }
        public void gamePaused()
        {
            InputManagerController.Instance.Paused = true;
        }
        public void gameUnPaused()
        {
            InputManagerController.Instance.Paused = false;
        }

        public void HiddenAllMenuPanel()
        {
            InputManagerController.Instance.HiddenAllMenuPanel = true;
        }
        public void UnHiddenAllMenuPanel()
        {
            InputManagerController.Instance.HiddenAllMenuPanel = false;
        }


    }
}