using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using UnityEngine;
using UnityWeld.Binding;

[Binding]
public class startRacingAnim : MonoBehaviour, INotifyPropertyChanged
{
    [SerializeField]
    private int counter = 0;

    [Binding]
    public int Counter { get => counter; set
        {
           

            counter = value;

            OnPropertyChanged(nameof(Counter));
        }
    }

    public event PropertyChangedEventHandler PropertyChanged;
    private void OnPropertyChanged(string propertyName)
    {
        if (PropertyChanged != null)
        {
            PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
        }
    }


    void Start()
    {
        Sequence mySequence = DOTween.Sequence();
        for (int i = 3; i > 0; i--)
        {
            Counter = i;
            //mySequence.Append(this.transform.DOScale(new Vector3(0, 0, 0), 1)).Append(this.transform.DOScale(new Vector3(1, 1, 1), 0));
            Debug.Log(Counter);
            
            
        }

       
        
        
    }
}
