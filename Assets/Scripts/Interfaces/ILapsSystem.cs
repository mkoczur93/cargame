using RacingMap;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface ILapsSystem
{
    int CounterLaps { get ; set ; }
    void SetBaseCheckpoint(LapCheckpoint[] lapCheckpoints);
    void RegisterCheckpoint(LapCheckpoint checkpoint);
    void SubscribeOnCheckPointReached(Action action);
    void UnSubscribeOnCheckPointReached(Action action);
    void StartGame();
    void SubscribeOnStartGame(Action action);
    void UnSubscribeOnStartGame(Action action);
    void SetInitialLap();    
    void CheckLap();
    void ClearLapCheckpoints();
}
