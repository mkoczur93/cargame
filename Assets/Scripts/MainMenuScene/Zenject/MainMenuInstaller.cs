using Car;
using RacingMap;
using MainProject.UI;
using UnityEngine;
using Zenject;
using MainProject.GameManager;

public class MainMenuInstaller : MonoInstaller
{
    
    public override void InstallBindings()
    {
      Container.Bind(typeof(IInitializable), typeof(ISelectionSystem)).To<SelectionSystem>().AsSingle();        
       // Container.Bind(typeof(IGameManager)).To<GameManager>().AsSingle();







    }
}