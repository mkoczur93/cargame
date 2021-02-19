using Car;
using MainProject.UI;
using UnityEngine;
using Zenject;

public class MainMenuInstaller : MonoInstaller
{
    
    public override void InstallBindings()
    {

        Container.Bind<SelectionSystem>().AsSingle().NonLazy();        
        Container.Bind<PlayerCardViewModel>().AsSingle();
        Container.Bind<MapCardViewModel>().AsSingle();
        Container.Bind<PlayerCarSelectionViewModel>().AsSingle();
        Container.Bind<MapSelectionViewModel>().AsSingle();
        

    }
}