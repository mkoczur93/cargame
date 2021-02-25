using Car;
using MainProject.GameManager;
using MainProject.UI;
using UnityEngine;
using Zenject;

public class ProjectInstaller : MonoInstaller<ProjectInstaller>
{
    
    public override void InstallBindings()
    {
        
        Container.Bind(typeof(IGameManager)).To<GameManager>().AsSingle();
        Container.Bind(typeof(IViewModelController)).To<ViewModelController>().AsSingle();
        Container.Bind(typeof(IInitializable)).To<LoadJSON>().AsSingle();
        
        


    }
}