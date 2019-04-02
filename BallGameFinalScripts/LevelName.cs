using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class LevelName : MonoBehaviour
{
    public TextMesh textMesh;
	
	void Start ()
    {
        string levelName = Application.loadedLevelName;
        textMesh.text = levelName;
	}
}
