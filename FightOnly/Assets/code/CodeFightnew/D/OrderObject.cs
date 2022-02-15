using System.Collections;
using System.Collections.Generic;
using UnityEngine;

 class OrderObject : GameobjextDynamic
{
    public OrderObject() : base() { }

    public override void Add(GameObject item)
    {
        if (count == gameObjects.Length) { Expand(); }
        int addLocation = 0;
        int Type  = item.GetComponent<MainCards>().typecardint;
        while ((addLocation < count) && (gameObjects[addLocation].GetComponent<MainCards>().typecardint < Type))
        {
            addLocation++;
        }
        ShiftUp(addLocation);
        gameObjects[addLocation] = item;
        count++;
    }

    void ShiftUp(int index)
    { for (int i = count; i > index; i--)  {  gameObjects[i] = gameObjects[i - 1]; }  }


    public  GameObject indexObj (int a){ return gameObjects[a]; }

}
