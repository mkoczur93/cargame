using Car;
using RacingMap;
using System;
using UnityEngine;
using Zenject;

[CreateAssetMenu(fileName = "MainMenuScriptableObjectInstaller", menuName = "Installers/MainMenuScriptableObjectInstaller")]
public class MainMenuScriptableObjectInstaller : ScriptableObjectInstaller<MainMenuScriptableObjectInstaller>
{
    [SerializeField]
    private GameObjectSettings m_Data;

    public GameObjectSettings Data
    {
        get => m_Data;
    }
    [Serializable]
    public class GameObjectSettings
    {
        [SerializeField]
        private CarPlayerData m_CarsData = null;
        [SerializeField]
        private MapListData m_MapsData = null;

        public CarPlayerData CarsData
        {
            get => m_CarsData;
        }

        public MapListData MapsData
        {
            get => m_MapsData;
        }


    }
    public override void InstallBindings()
    {
        Container.BindInstance(Data.CarsData);
        Container.BindInstance(Data.MapsData);
    }
}