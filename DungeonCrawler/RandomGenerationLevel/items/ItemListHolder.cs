using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemListHolder : MonoBehaviour
{
    [Tooltip("List of item which can be spawn on map.")]
    public List<GameObject> itemsList = new List<GameObject>();
}
