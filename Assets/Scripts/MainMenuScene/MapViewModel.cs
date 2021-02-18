namespace MainProject.UI
{

    using System.Collections;
    using UnityEngine;
    using UnityWeld.Binding;
    using System.ComponentModel;
    using UnityEngine.SceneManagement;
    using UnityEngine.EventSystems;
    using Car;

    [Binding]
    public class MapViewModel : ViewModel
    {

        protected override void Start()
        {
            base.Start();
            SetupCanvasGroup(0, false, false);
            Cursor.visible = true;



        }

        [Binding]
        public void ButtonBack()
        {
            hidePanel();
            ViewModelController.Instance.getViewModel(PanelUI.PlayerCarPanel).showPanel();
            EventSystem.current.SetSelectedGameObject(null);


        }

      




    }
}
