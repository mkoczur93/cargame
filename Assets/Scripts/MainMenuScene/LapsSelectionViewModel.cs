namespace MainProject.UI
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
    using System;
    using UnityWeld.Binding;
    using Zenject;

    [Binding]
    public class LapsSelectionViewModel : ViewModel, INotifyPropertyChanged
    {

        private int m_LapsCounter = 1;    
        [Inject]
        private readonly IViewModelController m_ViewModelController = null;
        [Inject]
        private readonly ISelectionSystem m_Selection = null;
        [Inject]
        private readonly IGameManager m_GameManager = null;

        public event PropertyChangedEventHandler PropertyChanged;

        private void Start()
        {
            m_Selection.SubscribeOnCoutnerLapsDataChanged(SetupView);
        }

        public void SetupView(int CounterLaps)
        {
            LapsCounter = CounterLaps;

        }
        [Binding]
        public int LapsCounter
        {
            get => m_LapsCounter;
            set
            {
                m_LapsCounter = value;
                OnPropertyChanged(nameof(LapsCounter));
            }
        }
        protected override void Awake()
        {

            base.Awake();
            SetupCanvasGroup(0, false, false);
            Cursor.visible = true;





        }


        [Binding]
        public void ButtonConfirm()
        {

            EventSystem.current.SetSelectedGameObject(null);                       
            m_Selection.StartGame();


        }
        [Binding]
        public void ButtonPrevious()
        {
            EventSystem.current.SetSelectedGameObject(null);
            m_Selection.DecreaseCounterLap();

        }

        [Binding]
        public void ButtonNext()
        {
            EventSystem.current.SetSelectedGameObject(null);
            m_Selection.IncreaseCounterLap();
            
        }
        [Binding]
        public void ButtonBack()
        {
            hidePanel();
            m_ViewModelController.getViewModel(PanelUI.MapPanel).showPanel();
            EventSystem.current.SetSelectedGameObject(null);


        }


        private void OnPropertyChanged(string propertyName)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }
        private void OnDestroy()
        {
            m_Selection.UnSubscribeOnCoutnerLapsDataChanged(SetupView);
        }
    }
}