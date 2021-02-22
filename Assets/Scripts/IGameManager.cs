using Player;
using RacingMap;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IGameManager
{

    PlayerMovementController SelectedCar { get; set; }
    DefaultMapSettings SelectedDefaultMapSettings { get; set; }


}
