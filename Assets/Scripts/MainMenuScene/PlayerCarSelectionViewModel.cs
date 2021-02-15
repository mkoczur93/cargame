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
    public class PlayerCarSelectionViewModel : ViewModel
    {

    
        // Start is called before the first frame update
        protected override void Start()
        {
            base.Start();            
            SetupCanvasGroup(1, true, true);            
            Cursor.visible = true;



        }

       




    }
}
