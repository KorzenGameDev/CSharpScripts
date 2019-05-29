using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelCreator : MonoBehaviour
{
    public static LevelCreator instance;

    private void Awake()
    {
        if (instance == null)
            instance = this;
    }

    public void Loadlevel()
    {
        Debug.Log("I Load Level");
    }
}
