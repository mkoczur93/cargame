namespace MainProject.UI
{

    using System.Collections;
    using UnityEngine;
    using UnityWeld.Binding;
    using System.ComponentModel;
    using UnityEngine.SceneManagement;
    using UnityEngine.EventSystems;

    [Binding]
    public class MenuViewModel : ViewModel
    {

        [SerializeField]
        private CanvasGroup mainMenu = null;        
        private string nameScene = string.Empty;

        // Start is called before the first frame update
        protected override void Start()
        {
            base.Start();
            mainMenu = mainMenu.GetComponent<CanvasGroup>();
            SetupCanvasGroup(0, false, false);
            nameScene = SceneManager.GetActiveScene().name;
 

        }

        [Binding]
        public void buttonResume()
        {

            ViewModel id = ViewModelController.Instance.getViewModel(PanelUI.MainPanel);            
            id.hidePanel();

            InputManagerController.Instance.Paused = false;
            InputManagerController.Instance.HiddenAllMenuPanel = true;             
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
            InputManagerController.Instance.HiddenAllMenuPanel = false;
            EventSystem.current.SetSelectedGameObject(null);




        }
        [Binding]
        public void quitGameButton()
        {
            hidePanel();
            ViewModel id = ViewModelController.Instance.getViewModel(PanelUI.ConfirmQuitGamePanel);
            id.showPanel();
            InputManagerController.Instance.HiddenAllMenuPanel = false;
            EventSystem.current.SetSelectedGameObject(null);




        }
        [Binding]
        public void confirmNewGameBtnYes()
        {
            InputManagerController.Instance.Paused = false;
            EventSystem.current.SetSelectedGameObject(null);
            SceneManager.LoadScene(nameScene);
            Time.timeScale = 1f;    
            Cursor.visible = !Cursor.visible;
            InputManagerController.Instance.HiddenAllMenuPanel = true;
        }
        [Binding]
        public void confirmNewGameBtnNo()
        {
            hidePanel();
            ViewModel id = ViewModelController.Instance.getViewModel(PanelUI.MainPanel);
            id.showPanel();
            InputManagerController.Instance.HiddenAllMenuPanel = true;
            EventSystem.current.SetSelectedGameObject(null);
        }

        [Binding]
        public void confirmQuitGameBtnYes()
        {
            Application.Quit();
            Debug.Log("Quit");
        }
        [Binding]
        public void confirmQuitGameBtnNo()
        {
            hidePanel();
            ViewModel id = ViewModelController.Instance.getViewModel(PanelUI.MainPanel);
            id.showPanel();
            InputManagerController.Instance.HiddenAllMenuPanel = true;
            EventSystem.current.SetSelectedGameObject(null);
        }

        private void SetupCanvasGroup(int alpha, bool interactable, bool blocksRaycasts)
        {
            if (mainMenu != null)
            {
                mainMenu.alpha = alpha;
                mainMenu.interactable = interactable;
                mainMenu.blocksRaycasts = blocksRaycasts;
            }
        }

       


    }
}
