using Player;
using RacingMap;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IGameManager
{
    int Laps { get; }
    PlayerMovementController SelectedCar { get; }
    DefaultMapSettings SelectedDefaultMapSettings { get; set; }
    void SetSelectedCar(PlayerMovementController SelectedCar, Sprite SpriteCar);
    void SetLaps(int Laps);


}
