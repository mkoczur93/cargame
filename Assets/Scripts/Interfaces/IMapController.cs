using Player;
using RacingMap;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public interface IMapController
{
    DefaultMapSettings Settings { get; }
    PlayerMovementController SelectedCar { get; }
    void SetStartDefaultPosition();
    void StartGame();
    void PausedGame();
    void SubscribeOnStartGame(Action action);
    void UnSubscribeOnStartGame(Action action);
    void SubscribeOnPausedGame(Action action);
    void UnSubscribeOnPausedGame(Action action);

}