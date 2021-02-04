namespace MainProject.UI
{
    using System.Collections;
    using UnityEngine;
    using UnityWeld.Binding;
    using System.ComponentModel;
    using UnityEngine.SceneManagement;


    public class PanelManager : ViewModel
    {
        private static bool paused = false;
        public static bool Paused { get=>paused; set => paused = value; }
        // Start is called before the first frame update
       

        // Update is called once per frame
        void Update()
        {
            GamePaused();

        }
        public void GamePaused()
        {
            if (Input.GetKeyDown(KeyCode.Escape))
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