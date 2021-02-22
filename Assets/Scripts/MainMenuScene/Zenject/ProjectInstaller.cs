using Car;
using MainProject.GameManager;
using UnityEngine;
using Zenject;

public class ProjectInstaller : Installer<ProjectInstaller>
{
    public override void InstallBindings()
    {
        Container.Bind(typeof(IGameManager)).To<GameManager>().AsSingle();
        Container.Bind(typeof(IInitializable), typeof(ISelectionSystem)).To<SelectionSystem>().AsSingle();
        
    }
}