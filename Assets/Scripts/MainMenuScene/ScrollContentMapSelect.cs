namespace MainProject.UI
{
    using Car;
    using DG.Tweening;
    using System.Collections;
    using System.Collections.Generic;
    using UnityEngine;
    using UnityEngine.EventSystems;
    using UnityEngine.UI;

    public class ScrollContentMapSelect : MonoBehaviour, IScrollHandler
    {




        public void OnScroll(PointerEventData eventData)
        {
            //Do zmiany potem :P 
            if (Input.GetAxis("Mouse ScrollWheel") < 0f)
            {
                SelectionSystem.Instance.SelectTheNextMap();
            }

            if (Input.GetAxis("Mouse ScrollWheel") > 0f)
            {
                SelectionSystem.Instance.SelectThePreviousMap();
            }



        }






    }

}