namespace MainProject.UI
{

    using System.Collections;
    using UnityEngine;
    using UnityWeld.Binding;
    using System.ComponentModel;
    using UnityEngine.SceneManagement;
    using UnityEngine.EventSystems;

    [Binding]
    public class ConfirmQuitGamePanelViewModel : ViewModel
    {

        
       // private CanvasGroup mainMenu = null;        
        

        // Start is called before the first frame update
        protected override void Start()
        {
            base.Start();
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
            ViewModel id = ViewModelController.Instance.getViewModel(PanelUI.MainPanel);
            id.showPanel();            
            EventSystem.current.SetSelectedGameObject(null);
        }

       

       


    }
}
