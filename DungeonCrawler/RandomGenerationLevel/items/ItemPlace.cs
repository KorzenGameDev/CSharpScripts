using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemPlace : MonoBehaviour
{
    public static ItemPlace instance;

    [Tooltip("List available place for item.")]
    public List<Transform> availablePlaceForItem = new List<Transform>();
    [Tooltip("List of placed item on map.")]
    public List<GameObject> placedItems = new List<GameObject>();

    [Tooltip("Holder a item spawned on map.")]
    public Transform itemHolder = null;

    int basicIteration = 0; //procentage or number
    int[] advanceIteration = new int[3]; //Weapons ,potions, craftthing

    private void Awake()
    {
        if (instance == null)
            instance = this;
    }

    public void StartPlace()
    {
        ItemGeneratorController.instance.LoadLists();

        if (ItemGeneratorController.instance.advanceNumber || ItemGeneratorController.instance.advanceProcentage)
            ItemIteration.instance.LoadAdvanceIteration(ref advanceIteration, availablePlaceForItem.Count);
        else
            ItemIteration.instance.LoadBasicIteration(ref basicIteration, availablePlaceForItem.Count);


        while(true)
        {
            bool end = true;
            if (ItemGeneratorController.instance.advanceNumber || ItemGeneratorController.instance.advanceProcentage)
            {
                AdvancePlace(ref end);
            }
            else
            {
                BasicPlace(ref end);
            }

            if (end)
                break;
        }
    }

    void BasicPlace(ref bool end)
    {
        if (basicIteration > 0)
        {
            PlaceItem(ItemGeneratorController.instance.weapons[Random.Range(0, ItemGeneratorController.instance.weapons.Count)], availablePlaceForItem);
            basicIteration--;
            end = false;
        }
        if (basicIteration > 0)
        {
            PlaceItem(ItemGeneratorController.instance.potions[Random.Range(0, ItemGeneratorController.instance.potions.Count)], availablePlaceForItem);
            basicIteration--;
            end = false;
        }
        if (basicIteration > 0)
        {
            PlaceItem(ItemGeneratorController.instance.craftThingItems[Random.Range(0, ItemGeneratorController.instance.craftThingItems.Count)], availablePlaceForItem);
            basicIteration--;
            end = false;
        }
    }

    void AdvancePlace(ref bool end)
    {
        end = true;
        if(advanceIteration[0] > 0)
        {
            PlaceItem(ItemGeneratorController.instance.weapons[Random.Range(0, ItemGeneratorController.instance.weapons.Count)], availablePlaceForItem);
            advanceIteration[0]--;
            end = false;
        }
        else if(advanceIteration[1] > 0)
        {
            PlaceItem(ItemGeneratorController.instance.potions[Random.Range(0, ItemGeneratorController.instance.potions.Count)], availablePlaceForItem);
            advanceIteration[1]--;
            end = false;
        }
        else if(advanceIteration[2]>0)
        {
            PlaceItem(ItemGeneratorController.instance.craftThingItems[Random.Range(0, ItemGeneratorController.instance.craftThingItems.Count)], availablePlaceForItem);
            advanceIteration[2]--;
            end = false;
        }
    }

    void PlaceItem(GameObject item, List<Transform> list)
    {

        Debug.Log("Item Placed!");

        //Find place for item
        Transform placeForItem = list[Random.Range(0, list.Count)];

        //instantiate item
        GameObject placedItem = Instantiate(item) as GameObject;

        placedItem.transform.parent = itemHolder.transform;
        placedItem.transform.position = placeForItem.transform.position;
        placedItem.transform.rotation = placeForItem.transform.rotation;

        //add to list
        list.Remove(placeForItem);
        placedItems.Add(placedItem);
    }

    public void Restart()
    {
        availablePlaceForItem.Clear();

        foreach (GameObject item in placedItems)
            Destroy(item.gameObject);

        placedItems.Clear();

        basicIteration = 0;
        foreach  (int i in advanceIteration)
            advanceIteration[i] = 0;
    }
}
