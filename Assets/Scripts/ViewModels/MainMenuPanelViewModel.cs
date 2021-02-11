namespace MainProject.UI
{

    using System.Collections;
    using UnityEngine;
    using UnityWeld.Binding;
    using System.ComponentModel;
    using UnityEngine.SceneManagement;
    using UnityEngine.EventSystems;

    [Binding]
    public class MainMenuPanelViewModel : ViewModel
    {

        
        private CanvasGroup mainMenu = null;        
        private string nameScene = string.Empty;

        // Start is called before the first frame update
        protected override void Start()
        {
            base.Start();
            mainMenu = GetComponent<CanvasGroup>();
            SetupCanvasGroup(0, false, false);
            nameScene = SceneManager.GetActiveScene().name;
 

        }

        [Binding]
        public void buttonResume()
        {

            ViewModel id = ViewModelController.Instance.getViewModel(PanelUI.MainPanel);            
            id.hidePanel();

        
            EventSystem.current.SetSelectedGameObject(null);
            Time.timeScale = 1f;
            Cursor.visible = !Cursor.visible;



        }

        [Binding]
        public void newGameButton()
        {
            hidePanel();
            ViewModel id = ViewModelController.Instance.getViewModel(PanelUI.ConfirmNewGamePanel);
            id.showPanel();
            EventSystem.current.SetSelectedGameObject(null);




        }
        [Binding]
        public void quitGameButton()
        {
            hidePanel();
            ViewModel id = ViewModelController.Instance.getViewModel(PanelUI.ConfirmQuitGamePanel);
            id.showPanel();
            EventSystem.current.SetSelectedGameObject(null);




        }
        



       


    }
}
