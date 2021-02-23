using Car;
using RacingMap;
using System;
using System.Collections.Generic;

public interface ISelectionSystem
{
    List<PlayerCar> CarsData { get; }
    List<Map> MapsData { get; }
    List<SpritePlayerCar> SpritePlayerCarsData { get; }
    PlayerCar SelectTheNextCar();
    PlayerCar SelectThePreviousCar();
    PlayerCar SelectCarOnClick(int id);
    Map SelectTheNextMap();
    Map SelectThePreviousMap();
    Map SelectMapOnClick(int id);
    void StartGame();
    void SubscribeOnDataChanged(Action<PlayerCar> action);
    void UnSubscribeOnDataChanged(Action<PlayerCar> action);
    void SubscribeOnMapDataChanged(Action<Map> action);
    void UnSubscribeOnMapDataChanged(Action<Map> action);
    
}