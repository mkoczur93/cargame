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
    public class PlayerCarViewModel : ViewModel
    {


        // Start is called before the first frame update
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
            ViewModelController.Instance.getViewModel(PanelUI.MainMenuScenePanel).showPanel();
            EventSystem.current.SetSelectedGameObject(null);


        }






    }
}
