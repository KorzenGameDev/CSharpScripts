using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemGeneratorController : MonoBehaviour
{
    public static ItemGeneratorController instance;

    [Header("Item Lists List")]
    public List<ItemsListHolder> listWeaponLists = new List<ItemsListHolder>();
    //  1.swords
    //  2.axes
    //  3.shields
    //  4.bowls
    public List<ItemsListHolder> listPotionLists = new List<ItemsListHolder>();
    //  1.live potions
    //  2.mana potions
    public List<ItemsListHolder> listCraftThingLists = new List<ItemsListHolder>();
    //  1.ores
    public List<ItemsListHolder> listQuestItemsLists = new List<ItemsListHolder>();


    [Header("Item Lists")]
    public List<GameObject> weapons = new List<GameObject>();
    public List<GameObject> potions = new List<GameObject>();
    public List<GameObject> craftThingItems = new List<GameObject>();
    public List<GameObject> questItems = new List<GameObject>();

    [Header("Procentage")]
    public bool procentage = false;
    [Range(10, 100)] public int procentageAllAmount = 10;

    public bool basicProcentage = false;
    [Range(0, 100)] public int procentageAllWeapon = 0;
    [Range(0, 100)] public int procentageAllPotions = 0;
    [Range(0, 100)] public int procentageAllCraftThingItems = 0;

    public bool advancedProcantage = false;
    //weapons
    [Range(0, 100)] public int procentageSwords = 0;
    [Range(0, 100)] public int procentageAxes = 0;
    [Range(0, 100)] public int procentageShields = 0;
    [Range(0, 100)] public int procentageBowls = 0;
    //potions
    [Range(0, 100)] public int procentageLivePotions = 0;
    [Range(0, 100)] public int procentageManaPotions = 0;
    //craft thing items
    [Range(0, 100)] public int procentageOres = 0;
    //quest items allways must be on map

    [Header("Spawn Numbers")]
    public bool number = false;
    public Vector3Int numberAllAmount = new Vector3Int();

    public bool basicNumber = false;
    public Vector3Int numberAllWeapon = new Vector3Int();
    public Vector3Int numberAllPotions = new Vector3Int();
    public Vector3Int numberAllCraftThing = new Vector3Int();

    public bool advanceNumber = false;
    //weapons
    public Vector3Int numberSwords = new Vector3Int();
    public Vector3Int numberAxes = new Vector3Int();
    public Vector3Int numberShields = new Vector3Int();
    public Vector3Int numberBowls = new Vector3Int();
    //potions
    public Vector3Int numberLivePotions = new Vector3Int();
    public Vector3Int numberManaPotions = new Vector3Int();
    //craft thing items
    public Vector3Int numberOres = new Vector3Int();
    //quest items allways must be on map


    private void Awake()
    {
        if (instance == null)
            instance = this;

        procentage = !number;
    }

    public void LoadLists()
    {
        foreach(ItemsListHolder itemHolder in listWeaponLists)
        {
            AddToItemsList(weapons, itemHolder);
        }
        foreach (ItemsListHolder itemHolder in listPotionLists)
        {
            AddToItemsList(potions, itemHolder);
        }
        foreach (ItemsListHolder itemHolder in listCraftThingLists)
        {
            AddToItemsList(craftThingItems, itemHolder);
        }
        foreach (ItemsListHolder itemHolder in listQuestItemsLists)
        {
            AddToItemsList(questItems, itemHolder);
        }
    }
    
    void AddToItemsList(List<GameObject> list,ItemsListHolder itemHolder)
    {
        PlaceItems.instance.boolPlaceList.Add(itemHolder.permit);
        if(itemHolder.permit)
        {
            foreach(GameObject item in itemHolder.itemsList)
            {
                list.Add(item);
            }
        }
    }
}
