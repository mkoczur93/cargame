using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CounterFps : MonoBehaviour
{
    private float frame = 0f;
    int counter = 0;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        ShowCounterFps();
    }

    public void ShowCounterFps()
    {
        frame = frame + 1f / Time.deltaTime;
        counter++;
        if (counter > 10)
        {
            frame = frame / counter;
            //wyswietl
            frame = 0;
            counter = 0;

        }

    }
}
