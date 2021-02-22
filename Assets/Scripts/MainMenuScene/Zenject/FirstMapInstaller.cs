using MainProject;
using UnityEngine;
using Zenject;

public class FirstMapInstaller : MonoInstaller
{
    public override void InstallBindings()
    {
        Container.Bind(typeof(IInitializable), typeof(IMapController)).To<MapController>().AsSingle();


    }
}