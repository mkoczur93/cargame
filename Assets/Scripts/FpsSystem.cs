namespace MainProject.UI
{
    using System.Collections;
    using System.Collections.Generic;
    using UnityEngine;
    using System;

    public class FpsSystem : IFpsSystem
    {
        private int m_Fps = 0;
        private float m_Frame = 0f;
        private int m_Counter = 0;        
      
        

       
        public int Fps { get => m_Fps; }

       

              
        public int FpsCounter()
        {
            if (Time.timeScale == 1f)
            {
                m_Frame = m_Frame + 1f / Time.deltaTime;

                if (m_Frame > 0)
                {
                    m_Counter++;
                    if (m_Counter > 10)
                    {
                        m_Frame = m_Frame / m_Counter;

                        m_Fps = (int)m_Frame;
                        m_Frame = 0;
                        m_Counter = 0;
                        

                    }

                }

            }
            return m_Fps;
            
        }
    }
}