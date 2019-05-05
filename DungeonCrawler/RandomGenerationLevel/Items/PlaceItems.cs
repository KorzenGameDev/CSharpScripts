using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlaceItems : MonoBehaviour
{
    public static PlaceItems instance;

    public List<Transform> availablePlaceForItem = new List<Transform>();
    //public List<GameObject> availableChestToDisable = new List<GameObject>();
    public List<GameObject> placedItems = new List<GameObject>();
    public List<bool> boolPlaceList = new List<bool>();

    public Transform itemHolder = null;

    int iteration = 0; //procentage or number
    int[] basicIteration = new int[3]; //Weapons ,potions, craftthing
    int[] advanceIteration = new int[7];//swords, axes, shields, bowls, live potions, mana potions, ores

    private void Awake()
    {
        if (instance == null)
            instance = this;
    }

    public void StartPlace()
    {
        ItemGeneratorController.instance.LoadLists();

        if (ItemGeneratorController.instance.advanceNumber || ItemGeneratorController.instance.advancedProcantage)
            ItemIteration.instance.LoadAdvenceIteration(ref basicIteration, ref advanceIteration, availablePlaceForItem.Count);
        else if (ItemGeneratorController.instance.basicNumber || ItemGeneratorController.instance.basicProcentage)
            ItemIteration.instance.LoadBasicIteration(ref basicIteration, availablePlaceForItem.Count);
        else
            ItemIteration.instance.LoadIteration(ref iteration, availablePlaceForItem.Count);


        while(true)
        {
            bool end = true;
            if (ItemGeneratorController.instance.advanceNumber || ItemGeneratorController.instance.advancedProcantage)
            {
                Advance(ref end);
            }
            else if (ItemGeneratorController.instance.basicNumber || ItemGeneratorController.instance.basicProcentage)
            {
                Basic(ref end);
            }
            else
            {
                Debug.Log("Iteration: " + iteration);

                if(iteration > 0)
                {
                    PlaceItem(ItemGeneratorController.instance.weapons[Random.Range(0, ItemGeneratorController.instance.weapons.Count)], availablePlaceForItem);
                    iteration--;
                    end = false;
                }
                if (iteration > 0)
                {
                    PlaceItem(ItemGeneratorController.instance.potions[Random.Range(0, ItemGeneratorController.instance.potions.Count)], availablePlaceForItem);
                    iteration--;
                    end = false;
                }
                if (iteration > 0)
                {
                    PlaceItem(ItemGeneratorController.instance.craftThingItems[Random.Range(0, ItemGeneratorController.instance.craftThingItems.Count)], availablePlaceForItem);
                    iteration--;
                    end = false;
                }
            }

            if (end)
                break;
        }
    }



    void Basic(ref bool end)
    {
        end = true;
        if(basicIteration[0] > 0)
        {
            PlaceItem(ItemGeneratorController.instance.weapons[Random.Range(0, ItemGeneratorController.instance.weapons.Count)], availablePlaceForItem);
            basicIteration[0]--;
            end = false;
        }
        else if(basicIteration[1] > 0)
        {
            PlaceItem(ItemGeneratorController.instance.potions[Random.Range(0, ItemGeneratorController.instance.potions.Count)], availablePlaceForItem);
            basicIteration[1]--;
            end = false;
        }
        else if(basicIteration[2]>0)
        {
            PlaceItem(ItemGeneratorController.instance.craftThingItems[Random.Range(0, ItemGeneratorController.instance.craftThingItems.Count)], availablePlaceForItem);
            basicIteration[2]--;
            end = false;
        }
    }

    void Advance(ref bool end)
    {
        end = true;
        int temp = 0;

        //SWORDS
        if(ItemGeneratorController.instance.listWeaponLists[0].permit && advanceIteration[0]>0)
        {
            PlaceItem(ItemGeneratorController.instance.weapons[Random.Range(temp, temp + ItemGeneratorController.instance.listWeaponLists[0].itemsList.Count)], availablePlaceForItem);
            temp += ItemGeneratorController.instance.listWeaponLists[0].itemsList.Count;
            advanceIteration[0]--;
            end = false;
        }
        else if(ItemGeneratorController.instance.listWeaponLists[0].permit)
        {
            temp += ItemGeneratorController.instance.listWeaponLists[0].itemsList.Count;
        }
        //END SWORDS

        //AXES
        if (ItemGeneratorController.instance.listWeaponLists[1].permit && advanceIteration[1] > 0)
        {
            PlaceItem(ItemGeneratorController.instance.weapons[Random.Range(temp, temp + ItemGeneratorController.instance.listWeaponLists[1].itemsList.Count)], availablePlaceForItem);
            temp += ItemGeneratorController.instance.listWeaponLists[1].itemsList.Count;
            advanceIteration[1]--;
            end = false;
        }
        else if (ItemGeneratorController.instance.listWeaponLists[1].permit)
        {
            temp += ItemGeneratorController.instance.listWeaponLists[1].itemsList.Count;
        }
        //END AXES

        //SHIELDS
        if (ItemGeneratorController.instance.listWeaponLists[2].permit && advanceIteration[2] > 0)
        {
            PlaceItem(ItemGeneratorController.instance.weapons[Random.Range(temp, temp + ItemGeneratorController.instance.listWeaponLists[2].itemsList.Count)], availablePlaceForItem);
            temp += ItemGeneratorController.instance.listWeaponLists[2].itemsList.Count;
            advanceIteration[2]--;
            end = false;
        }
        else if (ItemGeneratorController.instance.listWeaponLists[2].permit)
        {
            temp += ItemGeneratorController.instance.listWeaponLists[2].itemsList.Count;
        }
        //END SHIELDS

        //BOWLS
        if (ItemGeneratorController.instance.listWeaponLists[3].permit && advanceIteration[3] > 0)
        {
            PlaceItem(ItemGeneratorController.instance.weapons[Random.Range(temp, temp + ItemGeneratorController.instance.listWeaponLists[3].itemsList.Count)], availablePlaceForItem);
            temp += ItemGeneratorController.instance.listWeaponLists[3].itemsList.Count;
            advanceIteration[3]--;
            end = false;
        }
        else if (ItemGeneratorController.instance.listWeaponLists[3].permit)
        {
            temp += ItemGeneratorController.instance.listWeaponLists[3].itemsList.Count;
        }
        //END BOWLS

        //LIVE POTION
        temp = 0;
        if (ItemGeneratorController.instance.listPotionLists[4].permit && advanceIteration[4] > 0)
        {
            PlaceItem(ItemGeneratorController.instance.potions[Random.Range(temp, temp + ItemGeneratorController.instance.listPotionLists[4].itemsList.Count)], availablePlaceForItem);
            temp += ItemGeneratorController.instance.listPotionLists[4].itemsList.Count;
            advanceIteration[4]--;
            end = false;
        }
        else if (ItemGeneratorController.instance.listPotionLists[4].permit)
        {
            temp += ItemGeneratorController.instance.listPotionLists[4].itemsList.Count;
        }
        //END LIVE POTION

        //MANA POTION
        if (ItemGeneratorController.instance.listPotionLists[5].permit && advanceIteration[5] > 0)
        {
            PlaceItem(ItemGeneratorController.instance.potions[Random.Range(temp, temp + ItemGeneratorController.instance.listPotionLists[5].itemsList.Count)], availablePlaceForItem);
            temp += ItemGeneratorController.instance.listPotionLists[5].itemsList.Count;
            advanceIteration[5]--;
            end = false;
        }
        else if (ItemGeneratorController.instance.listPotionLists[5].permit)
        {
            temp += ItemGeneratorController.instance.listPotionLists[5].itemsList.Count;
        }
        //END MANA POTION

        //LIVE ORE
        temp = 0;
        if (ItemGeneratorController.instance.listCraftThingLists[6].permit && advanceIteration[6] > 0)
        {
            PlaceItem(ItemGeneratorController.instance.craftThingItems[Random.Range(temp, temp + ItemGeneratorController.instance.listCraftThingLists[6].itemsList.Count)], availablePlaceForItem);
            temp += ItemGeneratorController.instance.listCraftThingLists[6].itemsList.Count;
            advanceIteration[6]--;
            end = false;
        }
        else if (ItemGeneratorController.instance.listCraftThingLists[6].permit)
        {
            temp += ItemGeneratorController.instance.listCraftThingLists[6].itemsList.Count;
        }
        //END ORE
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

    public void ResetItem()
    {
        availablePlaceForItem.Clear();
        foreach (GameObject item in placedItems)
        {
            Destroy(item.gameObject);
        }

        placedItems.Clear();
        boolPlaceList.Clear();

        iteration = 0;
        foreach  (int i in basicIteration)
        {
            basicIteration[i] = 0;
        }
        foreach  (int i in advanceIteration)
        {
            advanceIteration[i] = 0;
        }
    }
}
