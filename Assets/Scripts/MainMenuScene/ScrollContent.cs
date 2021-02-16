namespace MainProject.UI
{
    using Car;
    using DG.Tweening;
    using System.Collections;
    using System.Collections.Generic;
    using UnityEngine;
    using UnityEngine.EventSystems;
    using UnityEngine.UI;

    public class ScrollContent : MonoBehaviour, IScrollHandler
    {




        public void OnScroll(PointerEventData eventData)
        {
            if (Input.GetAxis("Mouse ScrollWheel") < 0f)
            {
                SelectionSystem.Instance.SelectTheNextCar();
            }

            if (Input.GetAxis("Mouse ScrollWheel") > 0f)
            {
                SelectionSystem.Instance.SelectThePreviousCar();
            }



        }






    }

}