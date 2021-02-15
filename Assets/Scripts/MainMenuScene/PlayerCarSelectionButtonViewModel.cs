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
    public class PlayerCarSelectionButtonViewModel : ViewModel
    {

       
        // Start is called before the first frame update
        protected override void Start()
        {
            base.Start();            
            SetupCanvasGroup(0, false, false);            
            Cursor.visible = true;



        }

   
        [Binding]
        public void ButtonConfirm()
        {

            EventSystem.current.SetSelectedGameObject(null);


        }
        [Binding]
        public void ButtonPrevious()
        {
            EventSystem.current.SetSelectedGameObject(null);
            SelectionSystem.Instance.SelectThePreviousCar();


        }

        [Binding]
        public void ButtonNext()
        {
            EventSystem.current.SetSelectedGameObject(null);
            SelectionSystem.Instance.SelectTheNextCar();

        }


       





    }
}
