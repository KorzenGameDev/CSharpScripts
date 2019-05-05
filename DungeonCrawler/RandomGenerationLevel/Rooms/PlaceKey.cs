using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlaceKey : MonoBehaviour
{
    public static PlaceKey instance;
    
    public List<Transform> availablesPlaceForKey = new List<Transform>();
    public List<GameObject> keyInUse = new List<GameObject>();

    private void Awake()
    {

        if (instance == null)
            instance = this;
    }

    public void PlacedKey(GameObject key)
    {
        //Find room for place key
        Transform placeForKey = availablesPlaceForKey[Random.Range(0, availablesPlaceForKey.Count)];

        key.transform.parent = this.transform;
        key.transform.position = placeForKey.transform.position;
        key.transform.rotation = placeForKey.transform.rotation;

        //add to list
        availablesPlaceForKey.Remove(placeForKey);
        keyInUse.Add(key);
    }
}
