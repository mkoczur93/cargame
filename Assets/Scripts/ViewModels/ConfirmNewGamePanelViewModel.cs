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
        IMapController m_MapController;

        // Start is called before the first frame update
        protected override void Start()
        {
            base.Start();
            //mainMenu = GetComponent<CanvasGroup>();
            SetupCanvasGroup(0, false, false);
            nameScene = SceneManager.GetActiveScene().name;
 

        }

        
        [Binding]
        public void confirmNewGameBtnYes()
        {
            StartAnimViewModel startAnimPanel = ViewModelController.Instance.getViewModel(PanelUI.StartAnimPanel).GetComponent<StartAnimViewModel>();
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
            ViewModel id = ViewModelController.Instance.getViewModel(PanelUI.MainPanel);
            id.showPanel();            
            EventSystem.current.SetSelectedGameObject(null);
        }

    

        

       


    }
}
