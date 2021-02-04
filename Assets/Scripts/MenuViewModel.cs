namespace MainProject.UI
{

    using System.Collections;
    using UnityEngine;
    using UnityWeld.Binding;
    using System.ComponentModel;
    using UnityEngine.SceneManagement;


    [Binding]
    public class MenuViewModel : ViewModel
    {

        [SerializeField]
        private CanvasGroup mainMenu = null;        
        private string nameScene = string.Empty;
        // Start is called before the first frame update
        void Start()
        {
            mainMenu = mainMenu.GetComponent<CanvasGroup>();
            SetupCanvasGroup(0, false, false);
            nameScene = SceneManager.GetActiveScene().name;

        }

        // Update is called once per frame
        void Update()
        {
            //GamePaused();
        }
        [Binding]
        public void buttonResume()
        {

            ViewModel id = ViewModelController.Instance.getViewModel(PanelUI.MainPanel);            
            id.hidePanel();
            PanelManager.Paused = false;


        }

        [Binding]
        public void newGameButton()
        {
            SceneManager.LoadScene(nameScene);

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
