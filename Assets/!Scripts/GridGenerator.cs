using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

public class GridGenerator
{
    GameObject spacePref;
    GameObject grid;
    AleFactory factory;
    public GridGenerator(GameObject spp, GameObject grd)
    {
        spacePref = spp;
        grid = grd;    
    }
    public void GenField(AleFactory fact)
    {
        factory = fact;
        for (int i = 0; i < 9; i++)
        {
            factory.Create(grid.transform,spacePref,i);
        }
    }
}
