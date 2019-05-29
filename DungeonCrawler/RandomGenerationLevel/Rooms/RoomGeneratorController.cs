using System.Collections.Generic;
using UnityEngine;

public class RoomGeneratorController : MonoBehaviour
{
    static public RoomGeneratorController instance;

    EnemyType.Type type;
    [Header("List Room Lists")]
    [Tooltip("List whit list entry rooms.")]
    public List<RoomListHolder> entryRoomLists = new List<RoomListHolder>();
    [Tooltip("List whit list rooms.")]
    public List<RoomListHolder> commonRoomLists = new List<RoomListHolder>();
    [Tooltip("List whit list loked rooms.")]
    public List<RoomListHolder> lockedRoomLists = new List<RoomListHolder>();
    [Tooltip("List whit list quest rooms.")]
    public List<RoomListHolder> questRoomLists = new List<RoomListHolder>();
    [Tooltip("List whit list exit rooms.")]
    public List<RoomListHolder> exitRoomLists = new List<RoomListHolder>();

    [Header("Room lists")]
    [Tooltip("List whit entry rooms.")]
    public List<Room> entryRooms = new List<Room>();
    [Tooltip("List whit rooms.")]
    public List<Room> commonRooms = new List<Room>();
    [Tooltip("List whit locked rooms.")]
    public List<Room> lockedRooms = new List<Room>();
    [Tooltip("List whit quest rooms.")]
    public List<Room> questRooms = new List<Room>();
    [Tooltip("List whit exit rooms.")]
    public List<Room> exitRooms = new List<Room>();

    [Header("Accurent demension")]
    [Tooltip("If is true use accurent demension.")]
    public bool accurentDemension = false;
    [Tooltip("Determinate number of sectors to spawn.")]
    [Range(1, 10)] public int sectorsAmount = 3;
    [Tooltip("Determinate number of common room to spawn in sectors.")]
    [Range(1, 20)] public int commonRoomAmount = 5;
    [Tooltip("Determinate number of locked room to spawn in sectors.")]
    [Range(0, 5)] public int lockedRoomAmount = 0;

    [Header("Random demension")]
    [Tooltip("If is true use random demension.")]
    public bool randomDemension = false;
    [Tooltip("Determinate random number of sectors between x-y(min, max) to spawn.")]
    public Vector2Int sectorsRandomRangeAmount = new Vector2Int(1,5);
    [Tooltip("Determinate random number of common rooms between x-y(min, max) to spawn in sector.")]
    public Vector2Int commonRoomRandomRangeAmount = new Vector2Int(1,5);
    [Tooltip("Determinate random number of common rooms between x-y(min, max) to spawn in sector.")]
    public Vector2Int lockedRoomRangeAmount = new Vector2Int(0,0);

    private void Awake()
    {
        if (instance == null)
            instance = this;
    }

    public void LoadRooms()
    {
        int type = 0;
        switch (this.type)
        {
            case EnemyType.Type.Undead:
                type = 0;
                AddRoomToList(entryRoomLists[type], commonRoomLists[type], lockedRoomLists[type],questRoomLists[type], exitRoomLists[type]);
                break;
            case EnemyType.Type.Goblin:
                type = 1;
                AddRoomToList(entryRoomLists[type], commonRoomLists[type], lockedRoomLists[type],questRoomLists[type], exitRoomLists[type]);
                break;
            case EnemyType.Type.UndeadGoblin:
                type = 0;
                AddRoomToList(entryRoomLists[type], commonRoomLists[type], lockedRoomLists[type],questRoomLists[type], exitRoomLists[type]);
                type = 1;
                AddRoomToList(entryRoomLists[type], commonRoomLists[type], lockedRoomLists[type],questRoomLists[type], exitRoomLists[type]);
                break;
            case EnemyType.Type.All:
                for (int i = 0; i < commonRoomLists.Count; i++)
                {
                    AddRoomToList(entryRoomLists[i], commonRoomLists[i], lockedRoomLists[i], questRoomLists[i], exitRoomLists[i]);
                }
                break;
        }
    }

    void AddRoomToList(RoomListHolder entry, RoomListHolder common, RoomListHolder locked, RoomListHolder quest, RoomListHolder exit)
    {
        AddRoom(entryRooms, entry.room);
        AddRoom(commonRooms, common.room);
        AddRoom(lockedRooms, locked.room);
        AddRoom(questRooms, quest.room);
        AddRoom(exitRooms, exit.room);
    }

    void AddRoom(List<Room> list, List<Room> add)
    {
        if(add.Count>0)
            foreach (var item in add)
            {
                list.Add(item);
            }
    }
}
