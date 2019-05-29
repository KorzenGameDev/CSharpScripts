using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Room : MonoBehaviour
{
    [Header("Core")]
    [Tooltip("List of door in room.")]
    public List<Doorway> doorways=new List<Doorway>();
    [Tooltip("Dimension of the room as collider.")]
    public MeshCollider meshCollider=null;
    public Bounds RoomBounds { get { return meshCollider.bounds; } }
    [Tooltip("Number of room.")]
    public int roomNumber = 0;
    [Tooltip("Description of room.")]
    [TextArea] public string description=null;

    [Header("Enemy")]
    [Tooltip("List available place for  common creatures in room.")]
    public List<Transform> placeForCommonCreatures=new List<Transform>();
    [Tooltip("List available place for mini boss creatures in room.")]
    public List<Transform> placeForMiniBossCreatures=new List<Transform>();
    [Tooltip("List available place for boss creatures in room.")]
    public List<Transform> placeForBossCreatures=new List<Transform>();
    [Tooltip("Transform of waypoints parent")]
    public Transform wayPointsParent = null;

    [Header("Equipment")]
    [Tooltip("List available place for item in room.")]
    public List<Transform> placeForItem=new List<Transform>();
    [Tooltip("Request item to spawn this  room. If this room is spawn on map item will be added to map.")]
    public List<GameObject> extraItems = new List<GameObject>();
    [Tooltip("List available place for extra item.")]
    public List<Transform> placeForExtraItem=new List<Transform>();
    [Tooltip("List place when is placed chest.")]
    public List<Transform> chests=new List<Transform>();
    
}
