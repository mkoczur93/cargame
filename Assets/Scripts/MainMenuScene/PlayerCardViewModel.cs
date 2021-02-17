namespace MainProject.UI
{
    using Car;
    using MainProject.UI;
    using System.Collections;
    using System.Collections.Generic;
    using System.ComponentModel;
    using UnityEngine;
    using UnityEngine.UI;
    using UnityWeld.Binding;

    [Binding]
    public class PlayerCardViewModel : MonoBehaviour, INotifyPropertyChanged
    {
        private string m_NameCar = string.Empty;
        private int m_Id = 0;
        private Sprite m_CarSprite = null;

        private ColorBlock m_NormalColor;
        [SerializeField]
        private ColorBlock m_ColorBlock;
        [SerializeField]
        private ColorBlock m_ColorBlockSelectedCar;

        private void Start()
        {
            SelectionSystem.Instance.SubscribeOnDataChanged(SetupView);
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
        public string NameCar
        {
            get => m_NameCar;
            set
            {
                m_NameCar = value;

                OnPropertyChanged(nameof(NameCar));

            }

        }
        [Binding]
        public Sprite CarSprite
        {
            get => m_CarSprite;
            set
            {
                m_CarSprite = value;

                OnPropertyChanged(nameof(CarSprite));
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
        public void SetTheSelectedCarOnClick()
        {
            SelectionSystem.Instance.SelectCarOnClick(m_Id);
        }


        public event PropertyChangedEventHandler PropertyChanged;
        private void OnPropertyChanged(string propertyName)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }

        public void Init(PlayerCar item)
        {
            CarSprite = item.SpriteCar;
            Id = item.Id;
            if (item == SelectionSystem.Instance.CarsData.Cars[0])
            {
                NormalColor = m_ColorBlockSelectedCar;
            }
            else
            {
                NormalColor = m_ColorBlock;
            }
        }

        private void SetupView(PlayerCar playerCar)
        {            
            if (playerCar.Id == this.Id)
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
            SelectionSystem.Instance.UnSubscribeOnDataChanged(SetupView);
        }


    }
}