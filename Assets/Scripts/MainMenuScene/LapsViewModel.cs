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
    public class LapsViewModel : ViewModel
    {
      
        protected override void Awake()
        {
            base.Awake();
            SetupCanvasGroup(0, false, false);
            Cursor.visible = true;



        }

      


    }
}
