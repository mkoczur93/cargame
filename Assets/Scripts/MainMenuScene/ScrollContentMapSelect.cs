namespace MainProject.UI
{
    using Car;
    using DG.Tweening;
    using System.Collections;
    using System.Collections.Generic;
    using UnityEngine;
    using UnityEngine.EventSystems;
    using UnityEngine.UI;
    using Zenject;

    public class ScrollContentMapSelect : MonoBehaviour, IScrollHandler
    {

        [Inject]
        private readonly ISelectionSystem m_Selection = null;



        public void OnScroll(PointerEventData eventData)
        {
            //Do zmiany potem :P 
            if (Input.GetAxis("Mouse ScrollWheel") < 0f)
            {
                m_Selection.SelectTheNextMap();
            }

            if (Input.GetAxis("Mouse ScrollWheel") > 0f)
            {
                m_Selection.SelectThePreviousMap();
            }



        }






    }

}