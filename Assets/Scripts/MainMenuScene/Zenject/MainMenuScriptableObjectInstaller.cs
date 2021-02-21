using Car;
using RacingMap;
using System;
using UnityEngine;
using Zenject;

[CreateAssetMenu(fileName = "MainMenuScriptableObjectInstaller", menuName = "Installers/MainMenuScriptableObjectInstallers")]
public class MainMenuScriptableObjectInstaller : ScriptableObjectInstaller<MainMenuScriptableObjectInstaller>
{
    [SerializeField] private CarPlayerData.Settings m_carPlayerSettings = null;
    [SerializeField] private MapListData.Settings m_MapSettings = null;
    public override void InstallBindings()
    {
        Container.BindInstance(m_carPlayerSettings);
        Container.BindInstance(m_MapSettings);
    }
}
