namespace MainProject.UI
{
    using System.Collections;
    using UnityEngine;
    using UnityWeld.Binding;
    using System.ComponentModel;
    using UnityEngine.SceneManagement;


    public class InputManager : ViewModelInputManager
    {

        private bool hiddenAllMenuPanel;
        private bool paused;

        

        void Start()
        {
            hiddenAllMenuPanel = InputManagerController.Instance.HiddenAllMenuPanel;
            paused = InputManagerController.Instance.Paused;
        }
        void Update()
        {
            GamePaused();
        }
        public void GamePaused()
        {
            if (Input.GetKeyDown(KeyCode.Escape))
            {
                if (hiddenAllMenuPanel)
                {
                    if (paused == false)
                    {
                        Time.timeScale = 0f;
                        paused = true;
                        ViewModel id = ViewModelController.Instance.getViewModel(PanelUI.MainPanel);
                        id.showPanel();

                    }
                    else
                    {
                        Time.timeScale = 1f;
                        paused = false;
                        ViewModel id = ViewModelController.Instance.getViewModel(PanelUI.MainPanel);
                        id.hidePanel();
                    }
                }

            }
        }

    }
}