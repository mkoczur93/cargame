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
    public class ConfirmQuitGamePanelViewModel : ViewModel
    {

        [Inject]
        private readonly IViewModelController m_ViewModelController = null;
           


        // Start is called before the first frame update
        protected override void Awake()
        {
            base.Awake();
            //mainMenu = GetComponent<CanvasGroup>();
            SetupCanvasGroup(0, false, false);
            
 

        }

        

        [Binding]
        public void confirmQuitGameBtnYes()
        {
            Application.Quit();
            EventSystem.current.SetSelectedGameObject(null);
            
        }
        [Binding]
        public void confirmQuitGameBtnNo()
        {
            hidePanel();
            ViewModel id = m_ViewModelController.getViewModel(PanelUI.MainPanel);
            id.showPanel();            
            EventSystem.current.SetSelectedGameObject(null);
        }

       

       


    }
}
