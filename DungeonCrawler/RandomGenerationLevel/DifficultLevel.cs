using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DifficultLevel : MonoBehaviour
{
    public static DifficultLevel instance;

    private void Awake()
    {
        if (instance == null)
            instance = this;
    }

    public DifficultType.DifficultLevel difficult;

    public void LoadDifficultLevel(ref float min, ref float max)
    {

        switch (difficult)
        {
            case DifficultType.DifficultLevel.VeryEasy:
                min = .15f;
                max = .35f;
                break;
            case DifficultType.DifficultLevel.Easy:
                min = .20f;
                max = .45f;
                break;
            case DifficultType.DifficultLevel.Medium:
                min = .25f;
                max = .5f;
                break;
            case DifficultType.DifficultLevel.Hard:
                min = .3f;
                max = .65f;
                break;
            case DifficultType.DifficultLevel.VeryHard:
                min = .4f;
                max = .8f;
                break;
            case DifficultType.DifficultLevel.Shitty:
                min = .5f;
                max = .95f;
                break;
            default:
                Debug.Log("Is default!!");
                min = .25f;
                max = .5f;
                break;

        }
    }
}
