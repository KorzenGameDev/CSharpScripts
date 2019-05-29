using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoomPlace : MonoBehaviour
{
    static public RoomPlace instance;

    [Tooltip("List availabe door to place a room.")]
    public List<Doorway> availableDoorways = new List<Doorway>();
    [Tooltip("List placed room on map.")]
    public List<Room> placedRooms = new List<Room>();

    [Tooltip("Placed entry room.")]
    public EntryRoom entryRoom=null;
    [Tooltip("Placed exit room")]
    public ExitRoom exitRoom = null;

    [Tooltip("Holders for placed room.")]
    public Transform holderRooms=null;

    private void Awake()
    {
        if (instance == null)
            instance = this;
    }

    public void PlaceEntryRoom()
    {
        entryRoom = Instantiate(RoomGeneratorController.instance.entryRooms[Random.Range(0, RoomGeneratorController.instance.entryRooms.Count)]) as EntryRoom;
        entryRoom.transform.parent = holderRooms.transform;
        
        RoomPlacePositioning.instance.AddDoorwaysToList(entryRoom, ref availableDoorways);
        
        entryRoom.transform.position = Vector3.zero;
        entryRoom.transform.rotation = Quaternion.identity;

        if (RoomPlacePositioning.instance.CheckRoomOverlap(entryRoom))
        {
            LevelGenerator.instance.Restart();
        }

        RoomPlacePositioning.instance.AddAvailableRoomToList(entryRoom);
        RoomSetup(entryRoom as Room);
    }

    public void PlaceRoom(List<Room> list, Room r)
    {
        Room room = null;
        if (r != null)
            room = r;
        else
            room = Instantiate(list[Random.Range(0, list.Count)]) as Room;

        room.transform.parent = holderRooms.transform;

        if(room.extraItems.Count > 0)
        {
            int iteration = room.extraItems.Count;
            for (int i = 0; i < iteration; i++)
            {
                ExtraItemPlace.instance.PlaceExtraItem(room.extraItems[i]);
            }
        }
        
        List<Doorway> allAvailableDoorways = new List<Doorway>(availableDoorways);
        List<Doorway> currentRoomDorways = new List<Doorway>();
        RoomPlacePositioning.instance.AddDoorwaysToList(room, ref currentRoomDorways);
        
        RoomPlacePositioning.instance.AddDoorwaysToList(room, ref availableDoorways);
        bool roomPlaced = false;
        
        foreach (Doorway availableDoorway in allAvailableDoorways)
        {
            foreach (Doorway currentDoorway in currentRoomDorways)
            {
                RoomPlacePositioning.instance.PositionRoomAtDoorway(ref room, currentDoorway, availableDoorway);

                if (RoomPlacePositioning.instance.CheckRoomOverlap(room))
                {
                    continue;
                }

                roomPlaced = true;
                RoomSetup(room);

                RoomPlacePositioning.instance.AddAvailableRoomToList(room);

                currentDoorway.gameObject.SetActive(false);
                availableDoorways.Remove(currentDoorway);

                //availableDoorway.gameObject.SetActive(false);
                availableDoorways.Remove(availableDoorway);
                break;
            }

            if (roomPlaced)
            {
                break;
            }
        }

        if (!roomPlaced)
        {
            Destroy(room.gameObject);
            LevelGenerator.instance.Restart();
        }
    }

    void RoomSetup(Room room)
    {
        placedRooms.Add(room);
        AddPlace(ref EnemyPlace.instance.availablesPlaceForCommonCreatures, ref room.placeForCommonCreatures);
        AddPlace(ref EnemyPlace.instance.availablesPlaceForMiniBossCreatures, ref room.placeForMiniBossCreatures);
        AddPlace(ref EnemyPlace.instance.availablesPlaceForBossCreatures, ref room.placeForBossCreatures);

        AddPlace(ref ItemPlace.instance.availablePlaceForItem, ref room.placeForItem);
        AddPlace(ref ExtraItemPlace.instance.availablePlaceForExtraItem, ref room.placeForExtraItem);

        AddPlace(ref ChestPlace.instance.placedChest, ref room.chests);
    }

    void AddPlace(ref List<Transform> list, ref List<Transform> add)
    {
        if (add.Count > 0)
            foreach (var a in add)
            {
                list.Add(a);
            }
    }

    public void Restart()
    {
        availableDoorways.Clear();
        foreach (Room room in placedRooms)
            Destroy(room.gameObject);

        placedRooms.Clear();
        entryRoom = null;
        exitRoom = null;
    }
}
