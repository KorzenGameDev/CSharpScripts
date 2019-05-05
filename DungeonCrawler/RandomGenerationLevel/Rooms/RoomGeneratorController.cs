using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoomGeneratorController : MonoBehaviour
{
    static public RoomGeneratorController instance;

    EnemyType.Type type;
    [Header("List Room Lists")]
    public List<RoomListHolder> startRoomLists = new List<RoomListHolder>();
    public List<RoomListHolder> roomLists = new List<RoomListHolder>();
    public List<RoomListHolder> lockedRoomLists = new List<RoomListHolder>();
    public List<RoomListHolder> endRoomLists = new List<RoomListHolder>();

    [Header("Room lists")]
    public List<Room> startRoom = new List<Room>();
    public List<Room> normalRoom = new List<Room>();
    public List<Room> lockedRoom = new List<Room>();
    public List<Room> endRoom = new List<Room>();

    [Header("Accurent demension")]
    public bool accurentDemension = false;
    [Range(1, 10)] public int sectorsAmount = 3;
    [Range(1, 20)] public int normalRoomAmount = 5;
    [Range(0, 5)] public int lockedRoomAmount = 0;

    [Header("Random demension")]
    public bool randomDemension = false;
    public Vector2Int sectorsRandomRangeAmount = new Vector2Int(1,5);
    public Vector2Int normalRoomRandomRangeAmount = new Vector2Int(1,5);
    public Vector2Int lockedRoomRangeAmount = new Vector2Int(0,0);

    private void Awake()
    {
        if (instance == null)
            instance = this;
    }

    public void LoadRooms()
    {
        switch (type)
        {
            case EnemyType.Type.Undead:
                AddRoomToList(startRoomLists[0], roomLists[0], lockedRoomLists[0], endRoomLists[0]);
                break;
            case EnemyType.Type.Goblin:
                AddRoomToList(startRoomLists[1], roomLists[1], lockedRoomLists[1], endRoomLists[1]);
                break;
            case EnemyType.Type.UndeadGoblin:
                AddRoomToList(startRoomLists[0], roomLists[0], lockedRoomLists[0], endRoomLists[0]);
                AddRoomToList(startRoomLists[1], roomLists[1], lockedRoomLists[1], endRoomLists[1]);
                break;
            case EnemyType.Type.All:
                for (int i = 0; i < roomLists.Count; i++)
                {
                    AddRoomToList(startRoomLists[i], roomLists[i], lockedRoomLists[i], endRoomLists[i]);
                }
                break;

        }
    }

    void AddRoomToList(RoomListHolder start, RoomListHolder normal, RoomListHolder locked, RoomListHolder end)
    {
        foreach(Room room in start.room)
        {
            startRoom.Add(room);
        }
        foreach (Room room in normal.room)
        {
            normalRoom.Add(room);
        }
        foreach (Room room in locked.room)
        {
            lockedRoom.Add(room);
        }
        foreach (Room room in end.room)
        {
            endRoom.Add(room);
        }
    }




}
