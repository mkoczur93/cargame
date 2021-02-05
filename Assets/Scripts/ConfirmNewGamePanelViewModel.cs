namespace MainProject.UI
{

    using System.Collections;
    using UnityEngine;
    using UnityWeld.Binding;
    using System.ComponentModel;
    using UnityEngine.SceneManagement;
    using UnityEngine.EventSystems;

    [Binding]
    public class ConfirmNewGamePanelViewModel : ViewModel
    {

        
       // private CanvasGroup mainMenu = null;        
        private string nameScene = string.Empty;

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
            
            EventSystem.current.SetSelectedGameObject(null);
            SceneManager.LoadScene(nameScene);
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
