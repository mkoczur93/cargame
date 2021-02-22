namespace MainProject.UI
{

    using Car;
    using DG.Tweening;
    using Lean.Pool;
    using MainProject.Card;
    using MainProject.UI;
    using System.Collections;
    using System.Collections.Generic;
    using System.ComponentModel;
    using UnityEngine;
    using UnityEngine.EventSystems;
    using UnityEngine.UI;
    using UnityWeld.Binding;
    using Zenject;

    [Binding]
    public class PlayerCarSelectionViewModel : ViewModel, IScrollHandler
    {
        // Start is called before the first frame update
        [SerializeField]
        private RectTransform m_ScrollContent = null;
        [SerializeField]
        private PlayerCardViewModel m_PlayerCard = null;
        private float m_CellSize = 0f;
        private float m_PositionCard = 0f;
        private Sequence m_MySequence = null;
        private List<CardPosition> m_Cards = new List<CardPosition>();
        private const float m_Duration = 1f;
        [Inject]
        ISelectionSystem m_Selection;

        protected override void Start()
        {
            base.Start();
            SetupCanvasGroup(0, false, false);
            Cursor.visible = true;
            m_MySequence = DOTween.Sequence();
            Spawn();
            m_Selection.SubscribeOnDataChanged(SetPosition);


        }
        private void Spawn()
        {
            m_CellSize = m_ScrollContent.GetComponent<GridLayoutGroup>().cellSize.x;
            var cars = m_Selection.CarsData;
            
            foreach (var item in cars)

            {                
                var card = LeanPool.Spawn(m_PlayerCard, m_ScrollContent.transform);
                card.Init(item);
                CardPosition newCard = new CardPosition { Id = card.GetInstanceID(), Position = m_PositionCard, Card = card };
                m_Cards.Add(newCard);                
                m_PositionCard = m_PositionCard + m_CellSize;

            }
           


        }
        public void SetPosition(PlayerCar playerCar)
        {
            
            m_MySequence.Append(m_ScrollContent.DOLocalMoveX(-m_Cards[playerCar.Id].Position, m_Duration));
        }
        [Binding]
        public void ButtonConfirm()
        {

            hidePanel();
            ViewModelController.Instance.getViewModel(PanelUI.MapPanel).showPanel();
            EventSystem.current.SetSelectedGameObject(null);



        }
        [Binding]
        public void ButtonPrevious()
        {
            EventSystem.current.SetSelectedGameObject(null);
            var card = m_Selection.SelectThePreviousCar();            
            //m_MySequence.Append(m_ScrollContent.DOLocalMoveX(-m_Cards[card.Id].Position, m_Duration));
            

            //SelectionSystem.Instance.SelectThePreviousCar();


        }

        [Binding]
        public void ButtonNext()
        {
            EventSystem.current.SetSelectedGameObject(null);            
            var card = m_Selection.SelectTheNextCar();            
            //m_MySequence.Append(m_ScrollContent.DOLocalMoveX(-m_Cards[card.Id].Position, m_Duration));

        }
        public void OnScroll(PointerEventData eventData)
        {
            //Do zmiany potem :P 
            if (Input.GetAxis("Mouse ScrollWheel") < 0f)
            {
                m_Selection.SelectTheNextCar();
            }

            if (Input.GetAxis("Mouse ScrollWheel") > 0f)
            {
                m_Selection.SelectThePreviousCar();
            }



        }
        [Binding]
        public void ButtonBack()
        {
            hidePanel();
            ViewModelController.Instance.getViewModel(PanelUI.MainMenuScenePanel).showPanel();
            EventSystem.current.SetSelectedGameObject(null);


        }
        
        private void OnDestroy()
        {
            m_Selection.UnSubscribeOnDataChanged(SetPosition);
        }

    }
}