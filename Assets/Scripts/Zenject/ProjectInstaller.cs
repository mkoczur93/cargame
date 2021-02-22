using Car;
using MainProject.GameManager;
using MainProject.UI;
using UnityEngine;
using Zenject;

public class ProjectInstaller : MonoInstaller<ProjectInstaller>
{
    public override void InstallBindings()
    {
        //Container.Bind(typeof(IInitializable), typeof(ISelectionSystem)).To<SelectionSystem>().AsSingle();
        Container.Bind(typeof(IGameManager)).To<GameManager>().AsSingle();
        Container.Bind(typeof(IViewModelController)).To<ViewModelController>().AsSingle();


    }
}