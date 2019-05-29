using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemGeneratorController : MonoBehaviour
{
    public static ItemGeneratorController instance;

    [Header("Item Lists List")]
    [Tooltip("List of list whit weapons.")]
    public List<ItemListHolder> listWeaponLists = new List<ItemListHolder>();
    [Tooltip("List of list whit potions.")]
    public List<ItemListHolder> listPotionLists = new List<ItemListHolder>();
    [Tooltip("List of list whit craft things.")]
    public List<ItemListHolder> listCraftThingLists = new List<ItemListHolder>();
    [Tooltip("List of list whit quest items.")]
    public List<ItemListHolder> listQuestItemsLists = new List<ItemListHolder>();


    [Header("Item Lists")]
    [Tooltip("List of weapons to spawn.")]
    public List<GameObject> weapons = new List<GameObject>();
    [Tooltip("List of potions to spawn.")]
    public List<GameObject> potions = new List<GameObject>();
    [Tooltip("List of craft things to spawn.")]
    public List<GameObject> craftThingItems = new List<GameObject>();
    [Tooltip("List of quest items to spawn.")]
    public List<GameObject> questItems = new List<GameObject>();

    [Header("Procentage")]
    [Tooltip("If is true iteration spawning item use basic procentage")]
    public bool basicProcentage = false;
    [Tooltip("Value determinate how many item can be spawn on map.")]
    [Range(10, 100)] public int procentageAllAmount = 10;

    [Tooltip("If is true iteration spawning item use advance procentage.Basic Procentage must be true")]
    public bool advanceProcentage = false;
    [Tooltip("Value determinate how many weapons can be spawn on map.")]
    [Range(0, 100)] public int procentageAllWeapon = 0;
    [Tooltip("Value determinate how many potions can be spawn on map.")]
    [Range(0, 100)] public int procentageAllPotions = 0;
    [Tooltip("Value determinate how many craft things can be spawn on map.")]
    [Range(0, 100)] public int procentageAllCraftThingItems = 0;

    [Header("Spawn Numbers")]
    [Tooltip("If is true iteration spawning item use numbers")]
    public bool basicNumber = false;
    [Tooltip("Value determinate how many item can be spawn on map. X determinate exacly value, if x=0 x-y determinate range value between y-z(min, max)")]
    public Vector3Int numberAllAmount = new Vector3Int();

    [Tooltip("If is true iteration spawning item use advance numbers. Basic Number must be true.")]
    public bool advanceNumber = false;
    [Tooltip("Value determinate how many weapons can be spawn on map. X determinate exacly value, if x=0 x-y determinate range value between y-z(min, max)")]
    public Vector3Int numberAllWeapon = new Vector3Int();
    [Tooltip("Value determinate how many potions can be spawn on map. X determinate exacly value, if x=0 x-y determinate range value between y-z(min, max)")]
    public Vector3Int numberAllPotions = new Vector3Int();
    [Tooltip("Value determinate how many craft things can be spawn on map. X determinate exacly value, if x=0 x-y determinate range value between y-z(min, max)")]
    public Vector3Int numberAllCraftThing = new Vector3Int();


    private void Awake()
    {
        if (instance == null)
            instance = this;

        basicProcentage = !basicNumber;
    }

    public void LoadLists()
    {
        foreach(ItemListHolder itemHolder in listWeaponLists)
        {
            AddToItemsList(weapons, itemHolder);
        }
        foreach (ItemListHolder itemHolder in listPotionLists)
        {
            AddToItemsList(potions, itemHolder);
        }
        foreach (ItemListHolder itemHolder in listCraftThingLists)
        {
            AddToItemsList(craftThingItems, itemHolder);
        }
        foreach (ItemListHolder itemHolder in listQuestItemsLists)
        {
            AddToItemsList(questItems, itemHolder);
        }
    }
    
    void AddToItemsList(List<GameObject> list,ItemListHolder itemHolder)
    {
        foreach(GameObject item in itemHolder.itemsList)
        {
            list.Add(item);
        }
    }
}
