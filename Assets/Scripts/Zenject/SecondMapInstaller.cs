using MainProject;
using MainProject.UI;
using RacingMap;
using UnityEngine;
using Zenject;

public class SecondMapInstaller : MonoInstaller
{
    public override void InstallBindings()
    {
        Container.Bind(typeof(IInitializable), typeof(IMapController)).To<MapController>().AsSingle();
        Container.Bind(typeof(IInitializable), typeof(ILapsSystem)).To<LapsSystem>().AsSingle();
        Container.Bind(typeof(IInitializable), typeof(ILapTimeSystem)).To<LapTimeSystem>().AsSingle();
        Container.Bind(typeof(IFpsSystem)).To<FpsSystem>().AsSingle();
        Container.Bind(typeof(IInitializable), typeof(IBrakeTrack)).To<BrakeTrack>().AsSingle();
        Container.Bind<AsyncProcessor>().FromNewComponentOnNewGameObject().AsSingle();
    }
}