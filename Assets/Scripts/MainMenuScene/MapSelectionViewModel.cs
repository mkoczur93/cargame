﻿namespace MainProject.UI
{

    using Car;
    using DG.Tweening;
    using Lean.Pool;
    using MainProject.Card;
    using MainProject.UI;
    using RacingMap;
    using System.Collections;
    using System.Collections.Generic;
    using System.ComponentModel;
    using UnityEngine;
    using UnityEngine.EventSystems;
    using UnityEngine.UI;
    using UnityWeld.Binding;
    [Binding]
    public class MapSelectionViewModel : ViewModel, IScrollHandler
    {
        // Start is called before the first frame update
        [SerializeField]
        private RectTransform m_ScrollContent = null;
        [SerializeField]
        private MapCardViewModel m_MapCard = null;
        private float m_CellSize = 0f;
        private float m_PositionCard = 0f;
        private Sequence m_MySequence = null;
        private List<CardMapPosition> m_Cards = new List<CardMapPosition>();
        private const float m_Duration = 1f;

        protected override void Start()
        {
            base.Start();
            SetupCanvasGroup(0, false, false);
            Cursor.visible = true;
            m_MySequence = DOTween.Sequence();
            Spawn();
            SelectionSystem.Instance.SubscribeOnMapDataChanged(SetPosition);


        }
        private void Spawn()
        {
            m_CellSize = m_ScrollContent.GetComponent<GridLayoutGroup>().cellSize.x;
            var maps = SelectionSystem.Instance.MapsData;
            
            foreach (var item in maps.Maps)

            {                
                var card = LeanPool.Spawn(m_MapCard, m_ScrollContent.transform);
                card.Init(item);
                CardMapPosition newCard = new CardMapPosition { Id = card.GetInstanceID(), Position = m_PositionCard, Card = card };
                m_Cards.Add(newCard);                
                m_PositionCard = m_PositionCard + m_CellSize;

            }
           


        }
        public void SetPosition(Map Map)
        {
            
            m_MySequence.Append(m_ScrollContent.DOLocalMoveX(-m_Cards[Map.Id].Position, m_Duration));
        }
        [Binding]
        public void ButtonConfirm()
        {

            EventSystem.current.SetSelectedGameObject(null);
            SelectionSystem.Instance.StartGame();


        }
        [Binding]
        public void ButtonPrevious()
        {
            EventSystem.current.SetSelectedGameObject(null);
            var card = SelectionSystem.Instance.SelectThePreviousMap();            
            

        }

        [Binding]
        public void ButtonNext()
        {
            EventSystem.current.SetSelectedGameObject(null);            
            var card = SelectionSystem.Instance.SelectTheNextMap();            
           
        }
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
        [Binding]
        public void ButtonBack()
        {
            hidePanel();
            ViewModelController.Instance.getViewModel(PanelUI.PlayerCarPanel).showPanel();
            EventSystem.current.SetSelectedGameObject(null);


        }

        private void OnDestroy()
        {
            SelectionSystem.Instance.UnSubscribeOnMapDataChanged(SetPosition);
        }

    }
}