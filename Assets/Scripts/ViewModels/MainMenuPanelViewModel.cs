namespace MainProject.UI
{

    using System.Collections;
    using UnityEngine;
    using UnityWeld.Binding;
    using System.ComponentModel;
    using UnityEngine.SceneManagement;
    using UnityEngine.EventSystems;
    using Zenject;

    [Binding]
    public class MainMenuPanelViewModel : ViewModel
    {

        
        private CanvasGroup mainMenu = null;        
        private string nameScene = string.Empty;
        [Inject]
        private readonly IViewModelController m_ViewModelController = null;

        // Start is called before the first frame update
        protected override void Awake()
        {
            base.Awake();
            mainMenu = GetComponent<CanvasGroup>();
            SetupCanvasGroup(0, false, false);
            nameScene = SceneManager.GetActiveScene().name;
 

        }

        [Binding]
        public void buttonResume()
        {

            ViewModel id = m_ViewModelController.getViewModel(PanelUI.MainPanel);            
            id.hidePanel();

        
            EventSystem.current.SetSelectedGameObject(null);
            Time.timeScale = 1f;
            Cursor.visible = !Cursor.visible;



        }

        [Binding]
        public void newGameButton()
        {
            hidePanel();
            ViewModel id = m_ViewModelController.getViewModel(PanelUI.ConfirmNewGamePanel);
            id.showPanel();
            EventSystem.current.SetSelectedGameObject(null);




        }
        [Binding]
        public void quitGameButton()
        {
            hidePanel();
            ViewModel id = m_ViewModelController.getViewModel(PanelUI.ConfirmQuitGamePanel);
            id.showPanel();
            EventSystem.current.SetSelectedGameObject(null);




        }
        



       


    }
}
