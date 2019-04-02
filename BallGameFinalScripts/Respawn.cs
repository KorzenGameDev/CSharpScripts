using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Respawn : MonoBehaviour
{
    public GameObject spherePrefab;
    public Camera cameraPrefab;
    public Light lightPrefab;

    public GameObject gameOverBasePrefab;
    public GameObject levelNamePrefab;

	void Start ()
    {
        GameObject sphere = GameObject.Instantiate(spherePrefab);
        sphere.name = "sphere";
        sphere.transform.position = transform.position + Vector3.up * 2f;

        Camera camera = GameObject.Instantiate(cameraPrefab);
        CameraControler cameraControler = camera.GetComponent<CameraControler>();
        cameraControler.sphere = sphere.transform;

        Light light = GameObject.Instantiate(lightPrefab);
        light.color = Color.white;
        light.intensity = 0.5f;
        RenderSettings.ambientMode = UnityEngine.Rendering.AmbientMode.Flat;
        RenderSettings.ambientLight = Color.white * 0.7f;


        GameObject.Instantiate(gameOverBasePrefab);
        GameObject.Instantiate(levelNamePrefab);
    }
	

	void Update () {
		
	}
}
