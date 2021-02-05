namespace MainProject.UI
{
    using System.Collections;
    using UnityEngine;
    using UnityWeld.Binding;
    using System.ComponentModel;
    using UnityEngine.SceneManagement;


    public class InputManager : MonoBehaviour
    {
        private static bool paused = false;
        private static bool hiddenAllMenuPanel = true;
        public static bool Paused { get => paused; set => paused = value; }
        public static bool HiddenAllMenuPanel { get => hiddenAllMenuPanel; set => hiddenAllMenuPanel = value; }
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