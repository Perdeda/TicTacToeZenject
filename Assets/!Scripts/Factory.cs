using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

public class Factory : IFactory<Transform, Object, int, Space>
{
    DiContainer container;
    public Factory(DiContainer cont)
    {
        container = cont;
    }

    public Space Create(Transform prnt, Object pref, int i)
    {
        return container.InstantiatePrefabForComponent<Space>(pref,prnt).SetUp(i);
    }
}
public class AleFactory : PlaceholderFactory<Transform, Object, int, Space>
{
    public override Space Create(Transform t,Object o,int i)
    {
        return base.Create(t,o,i);
    }
}
