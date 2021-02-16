using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using UnityEngine;
using UnityWeld.Binding;

[Binding]
public class LapTimeResult : MonoBehaviour, INotifyPropertyChanged
{

    private string lapTime;    
    //private static LapTimeResult instance = null;
   // public static LapTimeResult Instance { get => instance; set => instance = value; }


    private void Awake()
    {
      //  instance = this;

    }
    [Binding]
    public string LapTime    
    {
        get => lapTime;

        set
        {
        
            lapTime = value;

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
    // Start is called before the first frame update
  
}
