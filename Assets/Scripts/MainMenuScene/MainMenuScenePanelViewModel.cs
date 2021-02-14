namespace MainProject.UI
{

    using System.Collections;
    using UnityEngine;
    using UnityWeld.Binding;
    using System.ComponentModel;
    using UnityEngine.SceneManagement;
    using UnityEngine.EventSystems;

    [Binding]
    public class MainMenuScenePanelViewModel : ViewModel
    {


        // Start is called before the first frame update
        protected override void Start()
        {
            base.Start();            
            SetupCanvasGroup(1, true, true);
            Cursor.visible = true;



        }

        [Binding]
        public void ButtonPlay()
        {
    
            hidePanel();
            EventSystem.current.SetSelectedGameObject(null);
            ViewModelController.Instance.getViewModel(PanelUI.PlayerCarSelectionPanel).showPanel();



        }

        [Binding]
        public void ButtonExit()
        {
            Application.Quit();



        }
       
        



       


    }
}
