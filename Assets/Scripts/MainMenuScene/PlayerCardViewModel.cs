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

        private Sprite m_CarSprite = null;

        private ColorBlock m_NormalColor;
        [SerializeField]
        private ColorBlock m_ColorBlock;
        [SerializeField]
        private ColorBlock m_ColorBlockSelectedCar;

        private void Start()
        {

            SelectionSystem.Instance.SubscribeOnChangeCard(ChangeNormalColor);
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
        public void SetTheSelectedCar()
        {
            SelectionSystem.Instance.SetTheSelectedCar(this.GetInstanceID());
        }


        public event PropertyChangedEventHandler PropertyChanged;
        private void OnPropertyChanged(string propertyName)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }

        public void ChangeNormalColor()
        {

            var id = SelectionSystem.Instance.SetTheSelectedCar1();
            if(id == this.GetInstanceID())
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
            SelectionSystem.Instance.UnSubscribeOnChangeCard(ChangeNormalColor);
        }


    }
}