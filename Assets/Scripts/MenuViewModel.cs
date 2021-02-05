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


        void Update()
        {
            //GamePaused();
        }
        [Binding]
        public void buttonResume()
        {

            ViewModel id = ViewModelController.Instance.getViewModel(PanelUI.MainPanel);            
            id.hidePanel();
            InputManager.Paused = false;
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
            InputManager.HiddenAllMenuPanel = false;
            EventSystem.current.SetSelectedGameObject(null);




        }
        [Binding]
        public void quitGameButton()
        {
            hidePanel();
            ViewModel id = ViewModelController.Instance.getViewModel(PanelUI.ConfirmQuitGamePanel);
            id.showPanel();
            InputManager.HiddenAllMenuPanel = false;
            EventSystem.current.SetSelectedGameObject(null);




        }
        [Binding]
        public void confirmNewGameBtnYes()
        {
            InputManager.Paused = false;
            EventSystem.current.SetSelectedGameObject(null);
            SceneManager.LoadScene(nameScene);
            Time.timeScale = 1f;    
            Cursor.visible = !Cursor.visible;
            InputManager.HiddenAllMenuPanel = true;
        }
        [Binding]
        public void confirmNewGameBtnNo()
        {
            hidePanel();
            ViewModel id = ViewModelController.Instance.getViewModel(PanelUI.MainPanel);
            id.showPanel();
            InputManager.HiddenAllMenuPanel = true;
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
            InputManager.HiddenAllMenuPanel = true;
            EventSystem.current.SetSelectedGameObject(null);
        }

        private void SetupCanvasGroup(int alpha, bool interactable, bool blocksRaycasts)
        {
            if (mainMenu != null)
            {
                mainMenu.alpha = 0;
                mainMenu.interactable = false;
                mainMenu.blocksRaycasts = false;
            }
        }

       


    }
}
