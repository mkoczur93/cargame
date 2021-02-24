using Car;
using Player;
using RacingMap;
using System;
using UnityEngine;
using Zenject;

[CreateAssetMenu(fileName = "MainMenuScriptableObjectInstaller", menuName = "Installers/MainMenuScriptableObjectInstallers")]
public class MainMenuScriptableObjectInstaller : ScriptableObjectInstaller<MainMenuScriptableObjectInstaller>
{
    [SerializeField] private PlayerMovementController m_PlayerCar = null;
    [SerializeField] private SpritePlayerCarData.Settings m_SpritePlayerCars = null;
    [SerializeField] private CarPlayerData.Settings m_carPlayerSettings = null;
    [SerializeField] private MapListData.Settings m_MapSettings = null;
    [SerializeField] private TrailRenderer m_BrakeTrack = null;

    public override void InstallBindings()
    {
        Container.BindInstance(m_PlayerCar);
        Container.BindInstance(m_SpritePlayerCars);
        Container.BindInstance(m_carPlayerSettings);
        Container.BindInstance(m_MapSettings);
        Container.BindInstance(m_BrakeTrack);
        
        
    }
}
