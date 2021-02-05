namespace MainProject.UI
{
    using System.Collections;
    using System.Collections.Generic;
    using UnityEngine;

    public class InputManagerController : MonoBehaviour
    {
        private static InputManagerController instance = null;
        private bool paused = false;
        private bool hiddenAllMenuPanel = true;

       
        public static InputManagerController Instance
        {
            get => instance;
        }

        public bool Paused
        {
            get => paused;
            set => paused = value;
            
        }
        
        public bool HiddenAllMenuPanel
        {
            get => hiddenAllMenuPanel;
            set => hiddenAllMenuPanel = value;
        }
        // Start is called before the first frame update
        private void Awake()
        {
            instance = this;
            Debug.Log(instance);
        }

        


    }
}