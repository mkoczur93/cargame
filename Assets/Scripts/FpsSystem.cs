namespace MainProject.UI
{
    using System.Collections;
    using System.Collections.Generic;
    using UnityEngine;
    using System;

    public class FpsSystem : MonoBehaviour
    {
        private int fps = 0;
        private float frame = 0f;
        int counter = 0;
        private Action OnCheckPointReached = null;
        private static FpsSystem instance = null;

        public static FpsSystem Instance { get => instance; set => instance = value; }
        public int Fps { get => fps; }

        private void Awake()
        {
            instance = this;

        }

        void Update()
        {
            FpsCounter();
            
        }

        public void SubscribeOnCheckPointReached(Action action)
        {
            OnCheckPointReached += action;
        }
        public void UnSubscribeOnCheckPointReached(Action action)
        {
            OnCheckPointReached -= action;
        }

        public void FpsCounter()
        {
            if (Time.timeScale == 1f)
            {
                frame = frame + 1f / Time.deltaTime;

                if (frame > 0)
                {
                    counter++;
                    if (counter > 10)
                    {
                        frame = frame / counter;

                        fps = (int)frame;
                        frame = 0;
                        counter = 0;
                        OnCheckPointReached?.Invoke();
                        //counterFps.CounterFps = fps;



                    }

                }
            }
        }
    }
}