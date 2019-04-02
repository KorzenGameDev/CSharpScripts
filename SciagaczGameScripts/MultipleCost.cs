using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MultipleCost : MonoBehaviour {

    private float multiple = 1.1f;

    public int NewCost(int cost)
    {
        if (cost > 0)
            cost = (int)(cost * multiple);
        else cost = 1;

        return cost;

    }
}
