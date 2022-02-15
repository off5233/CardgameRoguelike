using System.Collections;
using System.Collections.Generic;
using UnityEngine;

abstract class  GameobjextDynamic
{
    const int ExpandMultipleFactor = 2;
    protected GameObject[] gameObjects;
    protected int count = 0;
    protected GameobjextDynamic()  {  gameObjects = new GameObject[4]; count = 0;  }
    public abstract void Add(GameObject gameobject);
    protected void Expand()
    {
        GameObject[] newItems = new GameObject[gameObjects.Length * ExpandMultipleFactor];
        for (int i = 0; i < gameObjects.Length; i++)
        {
            newItems[i] = gameObjects[i];
        }
        gameObjects = newItems;
    }
}
