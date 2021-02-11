using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using UnityEngine;
using UnityWeld.Binding;

[Binding]
public class StartRacingAnim : MonoBehaviour, INotifyPropertyChanged
{

    private string counter = string.Empty;
    [SerializeField]
    private int index = 0;
    private Vector3 scale = Vector3.zero;
    private bool startAnim = true;

    public bool StartAnim
    {
        get => startAnim;
        set => startAnim = value;
    }

    private static StartRacingAnim instance = null;
    public static StartRacingAnim Instance { get => instance; set => instance = value; }


    private void Awake()
    {
        instance = this;

    }

    [Binding]
    public string Counter { get => counter; set
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
        Counter = index.ToString();
        StartCoroutine(Wait());



    }
    IEnumerator Wait()
    {
        Sequence mySequence = DOTween.Sequence();
        mySequence.Append(this.transform.DOScale(new Vector3(1, 1, 1), 0));   
        yield return new WaitForSeconds(1f);
        var counter = 3;        
        while (counter > 0)
        {
            yield return new WaitForSeconds(1f);
            mySequence.Append(this.transform.DOScale(Vector3.zero, 1.5f));
            yield return new WaitForSeconds(1.5f);
            mySequence.Append(this.transform.DOScale(Vector3.one, 0));
            counter--;
            setText(counter);

        }
        mySequence.Append(this.transform.DOLocalMoveY(-150f, 0));
        startAnim = false;
        yield return new WaitForSeconds(2f);
        mySequence.Append(this.transform.DOScale(Vector3.zero, 0)).Append(this.transform.DOLocalMoveY(8f, 0));
        Counter = index.ToString();
        
    }

    public void setText(int value)
    {
        if (value == 0)
        {
            Counter = "Start";
            return;
        }
        Counter = value.ToString();
    }
    public void StartCoroutineAnim()
    {
        StartCoroutine(Wait());
    }
}
