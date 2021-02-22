using MainProject;
using UnityEngine;
using Zenject;

public class SecondMapInstaller : MonoInstaller
{
    public override void InstallBindings()
    {
        Container.Bind(typeof(IInitializable), typeof(IMapController)).To<MapController>().AsSingle();
    }
}