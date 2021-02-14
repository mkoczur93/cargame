using DG.Tweening;
using MainProject;
using MainProject.UI;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using UnityEngine;
using UnityWeld.Binding;

[Binding]
public class StartAnimViewModel : ViewModel, INotifyPropertyChanged
{

    private int counter = 3;
    private const int resetCounter = 3;
    WaitForSeconds waitOneSecond = new WaitForSeconds(1f);
    WaitForSeconds waitOneAndHalfSecond = new WaitForSeconds(1.5f);
    private const float scaleDurationCountingDown = 1.5f;
    private const float duration = 0;
    private bool toggle = false;
    [SerializeField]
    private Transform m_transform = null;
    private bool m_coroutine_running = false;
    private Coroutine m_corutine = null;
    private Sequence mySequence = null;



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
        m_corutine = StartCoroutine(StartAnim());

    }

    public void CheckStartAnimCoroutine()
    {
        if (m_coroutine_running == true)
        {
            if (m_corutine != null)
            {
                StopCoroutine(m_corutine);
                if (Toggle == true)
                {
                    Toggle = false;
                }
                Debug.Log("stop coroutine");
            }
            m_coroutine_running = false;            
        }

    }
    IEnumerator StartAnim()
    {       
        if(mySequence != null)
        {
            DOTween.KillAll();            
        }

        mySequence = DOTween.Sequence();
        mySequence.Append(m_transform.transform.DOScale(Vector3.one, duration));
        Counter = resetCounter;        
        m_coroutine_running = true;   
        yield return waitOneSecond;
        var index = 3;
        while (index > 0)
        {
            yield return waitOneSecond;
            mySequence.Append(m_transform.transform.DOScale(Vector3.zero, scaleDurationCountingDown));
            yield return waitOneAndHalfSecond;
            index--;
            Counter = index;
            mySequence.Append(m_transform.transform.DOScale(Vector3.one, duration));            
            

        }

        mySequence.Append(m_transform.transform.DOScale(Vector3.zero, duration));
        Toggle = true;        
        MapController.Instance.StartGame();
        yield return waitOneAndHalfSecond;
        Toggle = false;
        enabled = false;
        m_coroutine_running = false;



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
