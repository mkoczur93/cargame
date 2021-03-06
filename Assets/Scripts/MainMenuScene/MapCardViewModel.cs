﻿namespace MainProject.UI
{
    using Car;
    using MainProject.UI;
    using RacingMap;
    using System.Collections;
    using System.Collections.Generic;
    using System.ComponentModel;
    using UnityEngine;
    using UnityEngine.SceneManagement;
    using UnityEngine.UI;
    using UnityWeld.Binding;
    using Zenject;

    [Binding]
    public class MapCardViewModel : MonoBehaviour, INotifyPropertyChanged
    {
        
        private int m_Id = 0;
        private Sprite m_MapSprite = null;

        private ColorBlock m_NormalColor;
        [SerializeField]
        private ColorBlock m_ColorBlock = ColorBlock.defaultColorBlock;
        [SerializeField]
        private ColorBlock m_ColorBlockSelectedCar = ColorBlock.defaultColorBlock;
        [Inject]
        ISelectionSystem m_Selection = null;

        private void Start()
        {
            m_Selection.SubscribeOnMapDataChanged(SetupView);
        }
        [Binding]
        public ColorBlock NormalColor
        {
            get => m_NormalColor;
            set
            {
                m_NormalColor = value;

                OnPropertyChanged(nameof(NormalColor));

            }

        }
    
        [Binding]
        public Sprite MapSprite
        {
            get => m_MapSprite;
            set
            {
                m_MapSprite = value;

                OnPropertyChanged(nameof(MapSprite));
            }

        }
        [Binding]
        public int Id
        {
            get => m_Id;
            set
            {
                m_Id = value;

                OnPropertyChanged(nameof(Id));

            }

        }

        [Binding]
        public void SetTheSelectedMapOnClick()
        {
            m_Selection.SelectMapOnClick(m_Id);
            
        }

        public event PropertyChangedEventHandler PropertyChanged;
        private void OnPropertyChanged(string propertyName)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }

        public void Init(Map item)
        {
            
            MapSprite = item.SpriteMap;
            Id = item.Id;           
            if (item == m_Selection.MapsData[0])
            {
                NormalColor = m_ColorBlockSelectedCar;
            }
            else
            {
                NormalColor = m_ColorBlock;
            }
        }

        private void SetupView(Map Map)
        {            
            if (Map.Id == this.Id)
            {

                NormalColor = m_ColorBlockSelectedCar;
            }
            else
            {
                NormalColor = m_ColorBlock;
            }

        }
        private void OnDestroy()
        {
            m_Selection.UnSubscribeOnMapDataChanged(SetupView);
        }


    }
}