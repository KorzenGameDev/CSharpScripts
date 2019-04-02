using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DisplayCrosshair : MonoBehaviour {

    public Texture2D crosshair;

	// Use this for initialization
	void Start () {
        Cursor.visible = false;
	}
    
    private void OnGUI()
    {
        float minX = Screen.width - (Screen.width - Input.mousePosition.x) - (crosshair.width / 2);
        float minY = (Screen.height - Input.mousePosition.y) - (crosshair.height / 2);

        GUI.DrawTexture(new Rect(minX, minY, crosshair.width / 1.2f, crosshair.height / 1.2f), crosshair);
	}
}
