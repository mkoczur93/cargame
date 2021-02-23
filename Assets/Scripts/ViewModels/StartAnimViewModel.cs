using DG.Tweening;
using MainProject;
using MainProject.UI;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using UnityEngine;
using UnityWeld.Binding;
using Zenject;

[Binding]
public class StartAnimViewModel : ViewModel, INotifyPropertyChanged
{

    private int counter = 3;
    private const int resetCounter = 3;
    private readonly WaitForSeconds waitOneSecond = new WaitForSeconds(1f);
    private readonly WaitForSeconds waitOneAndHalfSecond = new WaitForSeconds(1.5f);
    private const float scaleDurationCountingDown = 1.5f;
    private const float duration = 0;
    private bool toggle = false;
    [SerializeField]
    private Transform m_Transform = null;
    private bool coroutine_running = false;
    private Coroutine corutine = null;
    private Sequence mySequence = null;
    [Inject]
    private readonly IMapController m_MapController = null;
    


    [Binding]
    public int Counter
    {
        get => counter;
        set
        {
            if (value == 0)
            {
                counter = 3;

            }
            else
            {
                counter = value;
            }
            OnPropertyChanged(nameof(Counter));
        }
    }


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

   

    void OnEnable()
    {
        CheckStartAnimCoroutine();
        corutine = StartCoroutine(StartAnim());

    }

 
    public void CheckStartAnimCoroutine()
    {
        if (coroutine_running == true)
        {
            if (corutine != null)
            {
                StopCoroutine(corutine);
                if (Toggle == true)
                {
                    Toggle = false;
                }
                
            }
            coroutine_running = false;            
        }

    }
    IEnumerator StartAnim()
    {       
        if(mySequence != null)
        {
            DOTween.KillAll();            
        }

        mySequence = DOTween.Sequence();
        mySequence.Append(m_Transform.transform.DOScale(Vector3.one, duration));
        Counter = resetCounter;        
        coroutine_running = true;   
        yield return waitOneSecond;
        var index = 3;
        while (index > 0)
        {
            yield return waitOneSecond;
            mySequence.Append(m_Transform.transform.DOScale(Vector3.zero, scaleDurationCountingDown));
            yield return waitOneAndHalfSecond;
            index--;
            Counter = index;
            mySequence.Append(m_Transform.transform.DOScale(Vector3.one, duration));            
            

        }

        mySequence.Append(m_Transform.transform.DOScale(Vector3.zero, duration));
        Toggle = true;
        m_MapController.StartGame();
        yield return waitOneAndHalfSecond;
        Toggle = false;
        enabled = false;
        coroutine_running = false;



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
        StartCoroutine(StartAnim());
    }

   
}
