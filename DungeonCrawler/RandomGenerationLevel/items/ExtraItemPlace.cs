using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExtraItemPlace : MonoBehaviour
{
    public static ExtraItemPlace instance;

    [Tooltip("List available place for spawn extra items.")]
    public List<Transform> availablePlaceForExtraItem = new List<Transform>();
    [Tooltip("List placed extra items on map.")]
    public List<GameObject> placedExtraItems = new List<GameObject>();
    [Tooltip("Holder for extra items on map.")]
    public Transform extraItemHolder=null;

    private void Awake()
    {
        if (instance == null)
            instance = this;
    }


    public void PlaceExtraItem(GameObject item)
    {
        Debug.Log("Extra Item Placed!");
       
        Transform placeForItem = availablePlaceForExtraItem[Random.Range(0,availablePlaceForExtraItem.Count)];
        GameObject placedItem = Instantiate(item) as GameObject;

        placedItem.transform.parent = extraItemHolder.transform;
        placedItem.transform.position = placeForItem.transform.position;
        placedItem.transform.rotation = placeForItem.transform.rotation;

        availablePlaceForExtraItem.Remove(placeForItem);
        placedExtraItems.Add(placedItem);
    }

    public void Restart()
    {
        availablePlaceForExtraItem.Clear();

        foreach (var item in placedExtraItems)
            Destroy(item.gameObject);

        placedExtraItems.Clear();
    }
}
