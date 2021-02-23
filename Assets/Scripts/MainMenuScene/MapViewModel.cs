namespace MainProject.UI
{

    using System.Collections;
    using UnityEngine;
    using UnityWeld.Binding;
    using System.ComponentModel;
    using UnityEngine.SceneManagement;
    using UnityEngine.EventSystems;
    using Car;
    using Zenject;

    [Binding]
    public class MapViewModel : ViewModel
    {
        [Inject]
        private readonly IViewModelController m_ViewModelController = null;
        protected override void Awake()
        {
            base.Awake();
            SetupCanvasGroup(0, false, false);
            Cursor.visible = true;



        }

        [Binding]
        public void ButtonBack()
        {
            hidePanel();
            m_ViewModelController.getViewModel(PanelUI.PlayerCarPanel).showPanel();
            EventSystem.current.SetSelectedGameObject(null);


        }

      




    }
}
