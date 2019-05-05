using UnityEngine;

public class Room : MonoBehaviour
{
    public Doorway[] doorways;
    public MeshCollider meshCollider;
    public Transform[] keyPlace;
    public GameObject[] chests;
    public Transform[] items;
    public Transform[] enemyPlace;
    public Transform[] miniBossPlace;
    public Transform[] bossPlace;
    public Bounds RoomBounds { get{ return meshCollider.bounds; } }
}
