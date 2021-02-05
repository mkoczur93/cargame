namespace MainProject.UI
{
    using System.Collections;
    using UnityEngine;
    using UnityWeld.Binding;
    using System.ComponentModel;
    using UnityEngine.SceneManagement;
    using System.Linq;

    public class InputManager : MonoBehaviour
    {


        void Update()
        {
            GamePaused();
        }
        public void GamePaused()
        {
            if (Input.GetKeyDown(KeyCode.Escape))
            {

                
                var isMainMenuOpened = ViewModelController.Instance.IsModelOpened(PanelUI.MainPanel);
                
                if (isMainMenuOpened == false && Time.timeScale == 0)
                {
                    return;
                }
                
                    setPause();
                
            }

        }
        private void setPause()
        {
            var currentTime = Time.timeScale;
            if (currentTime == 0)
            {
                Time.timeScale = 1f;
                ViewModel id = ViewModelController.Instance.getViewModel(PanelUI.MainPanel);
                id.hidePanel();
                

            }
            else
            {
                Time.timeScale = 0f;
                ViewModel id = ViewModelController.Instance.getViewModel(PanelUI.MainPanel);
                id.showPanel();
            }

        }
    }

}


