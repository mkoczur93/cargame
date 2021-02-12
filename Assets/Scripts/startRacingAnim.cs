using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using UnityEngine;
using UnityWeld.Binding;

[Binding]
public class StartRacingAnim : MonoBehaviour
{

    private int counter = 3;    
    private Vector3 scale = Vector3.zero;
    private bool startAnim = true;
    WaitForSeconds waitOneSecond = new WaitForSeconds(1f);
    WaitForSeconds waitOneAndHalfSecond = new WaitForSeconds(1.5f);
    private const float scaleDurationCountingDown = 1.5f;
    private const float duration = 0;
    private bool toggle = false;


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
    public bool StartAnim
    {
        get => startAnim;
        set => startAnim = value;
    }



  

    void OnEnable()
    {        
        StartCoroutine(Wait());



    }
    IEnumerator Wait()
    {
        Sequence mySequence = DOTween.Sequence();
        mySequence.Append(this.transform.DOScale(Vector3.one, duration));
        yield return waitOneSecond;
        var counter = 3;
        while (counter > 0)
        {
            yield return waitOneSecond;
            mySequence.Append(this.transform.DOScale(Vector3.zero, scaleDurationCountingDown));
            yield return waitOneAndHalfSecond;            
            counter--;
            mySequence.Append(this.transform.DOScale(Vector3.one, duration));
            Counter = counter;

        }

        mySequence.Append(this.transform.DOScale(Vector3.zero, duration));
        startAnim = false;        
        yield return waitOneAndHalfSecond;
        
        
        
    }

    public event PropertyChangedEventHandler PropertyChanged;
    private void OnPropertyChanged(string propertyName)
    {
        if (PropertyChanged != null)
        {
            PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
        }
    }

    public void StartCoroutineAnim()
    {
        StartCoroutine(Wait());
    }
}
