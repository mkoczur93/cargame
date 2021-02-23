namespace RacingMap
{

    using System.Collections;
    using System.Collections.Generic;
    using UnityEngine;
    using MainProject.UI;
    using System;
    using ObjectTagData;
    using Zenject;

    public class LapsSystem : ILapsSystem,IInitializable
    {
        
        LapCheckpoint[] m_BaseCheckpoints = null;        
        private List<LapCheckpoint> m_Lap_checkpoints = new List<LapCheckpoint>();
        private Action OnCheckPointReached = null;
        private Action startGame = null;
        private DefaultMapSettings m_Settings = null;
        private int m_CounterLaps = 1;
        private const int m_StartLap = 1;
        public LapCheckpoint[] BaseCheckpoints
        {
            get => m_BaseCheckpoints;            
        }
        public int CounterLaps { get => m_CounterLaps; set => m_CounterLaps = value; }
        [Inject]
        private readonly IGameManager m_GameManager = null;
        [Inject]
        private readonly ILapTimeSystem m_LapTimeSystem = null;



        public void Initialize()
        {
            m_Settings = m_GameManager.SelectedDefaultMapSettings;
        }

        public void SetBaseCheckpoint(LapCheckpoint[] lapCheckpoints)
        {
            m_BaseCheckpoints = lapCheckpoints;
        }
        public void RegisterCheckpoint(LapCheckpoint checkpoint)
        {
            
            if (m_Lap_checkpoints.Contains(checkpoint))
            {
                
                m_Lap_checkpoints.Remove(checkpoint);
            }
            
            m_Lap_checkpoints.Add(checkpoint);
        }




        public void SubscribeOnCheckPointReached(Action action)
        {
            OnCheckPointReached += action;
        }
        public void UnSubscribeOnCheckPointReached(Action action)
        {
            OnCheckPointReached -= action;
        }

        public void StartGame()
        {
            startGame?.Invoke();
        }


        public void SubscribeOnStartGame(Action action)
        {
            startGame += action;
        }
        public void UnSubscribeOnStartGame(Action action)
        {
            startGame -= action;
        }

        public void SetInitialLap()
        {
            m_CounterLaps = m_StartLap;

        }

        public void ClearLapCheckpoints()
        {
            m_Lap_checkpoints.Clear();
        }

        public void CheckLap()
        {
            if (m_Lap_checkpoints.Count == 0)
                return;

            for (int i = 0; i < m_Lap_checkpoints.Count; i++)
            {
                if (m_Lap_checkpoints[i] != m_BaseCheckpoints[i])
                {
                    return;
                }
            }


            m_LapTimeSystem.AddLapTime();

            m_CounterLaps++;

            OnCheckPointReached?.Invoke();
        }

      
    }
}