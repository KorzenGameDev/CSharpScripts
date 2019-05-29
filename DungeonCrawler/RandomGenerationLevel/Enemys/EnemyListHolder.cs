using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyListHolder : MonoBehaviour
{
    [Tooltip("Holder a list of common creatures.")]
    public List<GameObject> commonCreatures = new List<GameObject>();
    [Tooltip("Holder a list of mini boss creatures.")]
    public List<GameObject> miniBossCreatures = new List<GameObject>();
    [Tooltip("Holder a list of boss creatures.")]
    public List<GameObject> bossCreatures = new List<GameObject>();
}

