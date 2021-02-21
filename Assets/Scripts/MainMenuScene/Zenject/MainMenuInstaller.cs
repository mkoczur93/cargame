using Car;
using RacingMap;
using MainProject.UI;
using UnityEngine;
using Zenject;


public class MainMenuInstaller : MonoInstaller
{
    
    public override void InstallBindings()
    {

        Container.Bind<ISelectionSystem>().To<SelectionSystem>().AsSingle();
        Container.Bind<SelectionSystem>().AsSingle().NonLazy();
        Container.Bind<IInitializable>().To<SelectionSystem>().AsSingle();






    }
}