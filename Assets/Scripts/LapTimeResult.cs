using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using UnityEngine;
using UnityWeld.Binding;

[Binding]
public class LapTimeResult : MonoBehaviour, INotifyPropertyChanged
{

    private string m_LapTime;    
   

    [Binding]
    public string LapTime    
    {
        get => m_LapTime;

        set
        {
        
            m_LapTime = value;

            OnPropertyChanged(nameof(LapTime));
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
