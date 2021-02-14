namespace MainProject.UI
{

    using System.Collections;
    using UnityEngine;
    using UnityWeld.Binding;
    using System.ComponentModel;
    using UnityEngine.SceneManagement;
    using UnityEngine.EventSystems;

    [Binding]
    public class PlayerCarSelectionViewModel : ViewModel
    {

       
        // Start is called before the first frame update
        protected override void Start()
        {
            base.Start();            
            //SetupCanvasGroup(0, false, false);
            Debug.Log(GetComponent<CanvasGroup>().alpha);
            Cursor.visible = true;



        }

        [Binding]
        public void ButtonBack()
        {
            hidePanel();
            ViewModelController.Instance.getViewModel(PanelUI.MainMenuScenePanel).showPanel();



        }
        [Binding]
        public void ButtonConfirm()
        {
           



        }
        [Binding]
        public void ButtonPrevious()
        {
    
           


        }

        [Binding]
        public void ButtonNext()
        {
            


        }


       





    }
}
