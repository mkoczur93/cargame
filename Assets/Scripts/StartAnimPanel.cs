using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using UnityEngine;
using UnityWeld.Binding;

[Binding]
public class StartAnimPanel : MonoBehaviour, INotifyPropertyChanged
{

    private int counter = 3;
    private bool toggle = false;

    [Binding]
    public bool Toggle
    {
        get => toggle;
        set
        {

            toggle = value;

            OnPropertyChanged(nameof(Toggle));
        }
    }

 


    [Binding]
    public int Counter
    {
        get => counter; set
        {
            if (value == 0)
            {
                counter = 3;
            }

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


  
}
