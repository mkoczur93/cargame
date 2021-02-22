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
    public class MainMenuScenePanelViewModel : ViewModel
    {
        [Inject]
        private readonly IViewModelController m_ViewModelController;

        // Start is called before the first frame update
        protected override void Awake()
        {
            base.Awake();            
            SetupCanvasGroup(1, true, true);
            Cursor.visible = true;



        }

        [Binding]
        public void ButtonPlay()
        {
    
            hidePanel();
            EventSystem.current.SetSelectedGameObject(null);
            m_ViewModelController.getViewModel(PanelUI.PlayerCarPanel).showPanel();



        }

        [Binding]
        public void ButtonExit()
        {
            Application.Quit();



        }
       
        



       


    }
}
