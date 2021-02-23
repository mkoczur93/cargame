using Player;
using RacingMap;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IGameManager
{

    PlayerMovementController SelectedCar { get; }
    DefaultMapSettings SelectedDefaultMapSettings { get; set; }
    void SetSelectedCar(PlayerMovementController SelectedCar, Sprite SpriteCar);


}
