using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

public class Install : MonoInstaller
{
    [SerializeField]
    GameObject space;
    [SerializeField]
    GameObject spaceParent;
    
    public override void InstallBindings()
    {
        Container.BindFactory<Transform, Object,int, Space, AleFactory>().FromFactory<Factory>();
        var gen = new GridGenerator(space, spaceParent);
        Container.Bind<GridGenerator>().FromInstance(gen).AsSingle();
        Container.Bind<GridManager>().FromComponentInHierarchy().AsSingle();

    }
    private void LevelStatisticHandler()
    {
       // Container.Bind<>().FromComponentInNewPrefabResource("LevelStatisticHandlerPrefab").AsSingle().NonLazy();
    }
}