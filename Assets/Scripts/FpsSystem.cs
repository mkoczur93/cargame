﻿namespace MainProject.UI
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

        void Update()
        {
            FpsCounter();
            
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
                        GameGUIViewModel.Instance.CounterFps = fps;

                        //counterFps.CounterFps = fps;



                    }

                }
            }
        }
    }
}