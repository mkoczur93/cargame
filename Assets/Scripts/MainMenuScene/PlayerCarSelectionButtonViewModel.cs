namespace MainProject.UI
{

    using System.Collections;
    using UnityEngine;
    using UnityWeld.Binding;
    using System.ComponentModel;
    using UnityEngine.SceneManagement;
    using UnityEngine.EventSystems;
    using Car;
    using DG.Tweening;

    [Binding]
    public class PlayerCarSelectionButtonViewModel : ViewModel
    {

        private Sequence m_MySequence = null;
        [SerializeField]
        private RectTransform m_ScrollContent = null;
        private const float m_Duration = 1f;
        // Start is called before the first frame update
        protected override void Start()
        {
            base.Start();            
            SetupCanvasGroup(0, false, false);            
            Cursor.visible = true;
            m_MySequence = DOTween.Sequence();



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
            var card = SelectionSystem.Instance.SelectThePreviousCar1();
            m_MySequence.Append(m_ScrollContent.DOLocalMoveX(-card.Position, m_Duration));


            //SelectionSystem.Instance.SelectThePreviousCar();


        }

        [Binding]
        public void ButtonNext()
        {
            EventSystem.current.SetSelectedGameObject(null);
            var card = SelectionSystem.Instance.SelectTheNextCar1();
            m_MySequence.Append(m_ScrollContent.DOLocalMoveX(-card.Position, m_Duration));



            //SelectionSystem.Instance.SelectTheNextCar();

        }


       





    }
}
