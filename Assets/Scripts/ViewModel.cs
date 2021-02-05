namespace MainProject.UI
{
    using System.Collections;
    using System.Collections.Generic;
    using UnityEngine;

    public class ViewModel : MonoBehaviour
    {
        [SerializeField]
        private PanelUI id = 0;
        CanvasGroup Canvas = null;
        public PanelUI Id
        {
            get => id;
        }

        protected virtual void Start()
        {
            //Debug.Log(this);
            ViewModelController.Instance.RegisterViewModel(this);
            Canvas = GetComponent<CanvasGroup>();
        }
        public void showPanel()
        {
            
            if (Canvas != null)
            {
                Canvas.alpha = 1;
                Canvas.interactable = true;
                Canvas.blocksRaycasts = true;
                

            }
        }

        public void hidePanel()
        {

            
            if (Canvas != null)
            {
                Canvas.alpha = 0f;
                Canvas.interactable = false;
                Canvas.blocksRaycasts = false;
                
                
            }
        }
    }
}