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
    public class ConfirmNewGamePanelViewModel : ViewModel
    {

        
       // private CanvasGroup mainMenu = null;        
        private string nameScene = string.Empty;
        [Inject]
        private readonly IMapController m_MapController = null;
        [Inject]
        private readonly IViewModelController m_ViewModelController = null;

        // Start is called before the first frame update
        protected override void Awake()
        {
            base.Awake();
            //mainMenu = GetComponent<CanvasGroup>();
            SetupCanvasGroup(0, false, false);
            nameScene = SceneManager.GetActiveScene().name;
 

        }

        
        [Binding]
        public void confirmNewGameBtnYes()
        {
            StartAnimViewModel startAnimPanel = m_ViewModelController.getViewModel(PanelUI.StartAnimPanel).GetComponent<StartAnimViewModel>();
            startAnimPanel.enabled = false;
            hidePanel();
            EventSystem.current.SetSelectedGameObject(null);
            m_MapController.PausedGame();
            m_MapController.SetStartDefaultPosition();            
            Time.timeScale = 1f;
            Cursor.visible = !Cursor.visible;

        }
        [Binding]
        public void confirmNewGameBtnNo()
        {
            hidePanel();
            ViewModel id = m_ViewModelController.getViewModel(PanelUI.MainPanel);
            id.showPanel();            
            EventSystem.current.SetSelectedGameObject(null);
        }

    

        

       


    }
}
