namespace MainProject.UI
{
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using UnityEngine;

    public class ViewModel : MonoBehaviour
    {
        [SerializeField]
        private PanelUI id = 0;
        CanvasGroup Canvas = null;
        protected Action<PanelUI> onPanelShow = null;
        protected Action<PanelUI> onPanelHide = null;
        public CanvasGroup canvas
        {
            get => Canvas;
        }
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
                onPanelShow?.Invoke(Id);

            }
        }

        public void hidePanel()
        {

            
            if (Canvas != null)
            {
                Canvas.alpha = 0f;
                Canvas.interactable = false; 
                Canvas.blocksRaycasts = false;
                onPanelHide?.Invoke(Id);



            }
        }

        public void SetupCanvasGroup(int alpha, bool interactable, bool blocksRaycasts)
        {
            if (Canvas != null)
            {
                Canvas.alpha = alpha;
                Canvas.interactable = interactable;
                Canvas.blocksRaycasts = blocksRaycasts;
            }
        }

        public void SubscribeOnPanelShow(Action<PanelUI> action)
        {
            onPanelShow += action;
        }
        public void UnSubscribeOnPanelShow(Action<PanelUI> action)
        {
            onPanelShow -= action;
        }
        public void SubscribeOnPanelHide(Action<PanelUI> action)
        {
            onPanelHide += action;
        }
        public void UnSubscribeOnPanelHide(Action<PanelUI> action)
        {
            onPanelHide -= action;
        }


    }
}