namespace MainProject.UI
{
    using System.Collections;
    using UnityEngine;
    using UnityWeld.Binding;
    using System.ComponentModel;
    using UnityEngine.SceneManagement;
    using System.Linq;
    using Zenject;

    public class InputManager : MonoBehaviour
    {

        [Inject]
        private readonly IViewModelController m_ViewModelController = null;
        void Update()
        {
            GamePaused();
        }
        public void GamePaused()
        {
            if (Input.GetKeyDown(KeyCode.Escape))
            {

                
                var isMainMenuOpened = m_ViewModelController.IsModelOpened(PanelUI.MainPanel);
                
                if (isMainMenuOpened == false && Time.timeScale == 0)
                {
                    return;
                }
                
                    SetPause();
                
            }

        }
        private void SetPause()
        {
            var currentTime = Time.timeScale;
            if (currentTime == 0)
            {
                Time.timeScale = 1f;
                ViewModel id = m_ViewModelController.getViewModel(PanelUI.MainPanel);
                id.hidePanel();
                

            }
            else
            {
                Time.timeScale = 0f;
                ViewModel id = m_ViewModelController.getViewModel(PanelUI.MainPanel);
                id.showPanel();
            }

        }
    }

}


