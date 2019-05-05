using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlaceRooms : MonoBehaviour
{
    static public PlaceRooms instance;

    public List<Doorway> availableDoorways = new List<Doorway>();
    public List<Room> placedRooms = new List<Room>();

    public EndRoom endRoom=null;
    public StartRoom startRoom=null;

    public Transform holderRooms=null;

    private void Awake()
    {
        if (instance == null)
            instance = this;
    }

    public void PlaceStartRoom()
    {
        //Instantiate room
        startRoom = Instantiate(RoomGeneratorController.instance.startRoom[Random.Range(0, RoomGeneratorController.instance.startRoom.Count)]) as StartRoom;
        startRoom.transform.parent = holderRooms.transform;

        //Get doorways from current room and add then randomly to the list of vailabel doorways
        PlaceRoomPositioning.instance.AddDoorwaysToList(startRoom, ref availableDoorways);

        //positioning room
        startRoom.transform.position = Vector3.zero;
        startRoom.transform.rotation = Quaternion.identity;  //TODO random rotation;

        if (PlaceRoomPositioning.instance.CheckRoomOverlap(startRoom))
        {
            LevelGenerator.instance.ResetSetup();
        }

        PlaceRoomPositioning.instance.AddAvailableRoomToList(startRoom);
    }

    public void PlaceNormalRoom()
    {
        //Istantiate room
        Room currentRoom = Instantiate(RoomGeneratorController.instance.normalRoom[Random.Range(0, RoomGeneratorController.instance.normalRoom.Count)]) as Room;
        currentRoom.transform.parent = holderRooms.transform;

        //create doorway lists to loop over
        List<Doorway> allAvailableDoorways = new List<Doorway>(availableDoorways);
        List<Doorway> currentRoomDorways = new List<Doorway>();
        PlaceRoomPositioning.instance.AddDoorwaysToList(currentRoom, ref currentRoomDorways);

        //Get doorways from current room and add then to the list of available doorways
        PlaceRoomPositioning.instance.AddDoorwaysToList(currentRoom, ref availableDoorways);

        bool roomPlaced = false;

        //Try all available doorways
        foreach (Doorway availableDoorway in allAvailableDoorways)
        {
            ////Try all available doorways in current room
            foreach (Doorway currentDoorway in currentRoomDorways)
            {
                //Positioning room;
                PlaceRoomPositioning.instance.PositionRoomAtDoorway(ref currentRoom, currentDoorway, availableDoorway);

                //check overlap;
                if (PlaceRoomPositioning.instance.CheckRoomOverlap(currentRoom))
                {
                    continue;
                }

                roomPlaced = true;

                //add room to list
                placedRooms.Add(currentRoom);
                //Add transform to good list
                PlaceRoomPositioning.instance.AddAvailableRoomToList(currentRoom);

                //remove occupied doorways
                //currentDoorway.gameObject.SetActive(false);
                availableDoorways.Remove(currentDoorway);

                availableDoorway.gameObject.SetActive(false);
                availableDoorways.Remove(availableDoorway);

                //Exit loop if room has ben placed
                break;
            }

            //Exit loop if room has ben placed
            if (roomPlaced)
            {
                break;
            }
        }
        //if we cant placed room reset level generate
        if (!roomPlaced)
        {
            Destroy(currentRoom.gameObject);
            LevelGenerator.instance.ResetSetup();
        }
    }

    public void PlaceLockedRoom()
    {
        //Istantiate room
        LockedRoom currentLockedRoom = Instantiate(RoomGeneratorController.instance.lockedRoom[Random.Range(0, RoomGeneratorController.instance.lockedRoom.Count)]) as LockedRoom;
        currentLockedRoom.transform.parent = holderRooms.transform;

        //create the key for door
        int iteration = currentLockedRoom.KeyNeedsToOpen.Length;
        for (int i = 0; i < iteration; i++)
        {
            PlaceKey.instance.PlacedKey(currentLockedRoom.KeyNeedsToOpen[i]);
        }

        //create doorway lists to loop over
        List<Doorway> allAvailableDoorways = new List<Doorway>(availableDoorways);
        List<Doorway> currentRoomDorways = new List<Doorway>();
        PlaceRoomPositioning.instance.AddDoorwaysToList(currentLockedRoom, ref currentRoomDorways);

        //Get doorways from current room and add then to the list of available doorways
        PlaceRoomPositioning.instance.AddDoorwaysToList(currentLockedRoom, ref availableDoorways);

        bool roomPlaced = false;

        //Try all available doorways
        foreach (Doorway availableDoorway in allAvailableDoorways)
        {
            ////Try all available doorways in current room
            foreach (Doorway currentDoorway in currentRoomDorways)
            {
                //Positioning room;
                Room room = (Room)currentLockedRoom;
                PlaceRoomPositioning.instance.PositionRoomAtDoorway(ref room, currentDoorway, availableDoorway);

                //check overlap;
                if (PlaceRoomPositioning.instance.CheckRoomOverlap(currentLockedRoom))
                {
                    continue;
                }

                roomPlaced = true;

                //add room to list
                placedRooms.Add(currentLockedRoom);

                //add place for stuff
                PlaceRoomPositioning.instance.AddAvailableRoomToList(currentLockedRoom);

                //remove occupied doorways
                currentDoorway.gameObject.SetActive(false);
                availableDoorways.Remove(currentDoorway);

                //availableDoorway.gameObject.SetActive(false);
                availableDoorways.Remove(availableDoorway);

                //Exit loop if room has ben placed
                break;
            }

            //Exit loop if room has ben placed
            if (roomPlaced)
            {
                break;
            }
        }
        //if we cant placed room reset level generate
        if (!roomPlaced)
        {
            Destroy(currentLockedRoom.gameObject);
            LevelGenerator.instance.ResetSetup();
        }
    }

    public void PlaceEndRoom()
    {
        //Istantiate room
        endRoom = Instantiate(RoomGeneratorController.instance.endRoom[Random.Range(0, RoomGeneratorController.instance.endRoom.Count)]) as EndRoom;
        endRoom.transform.parent = holderRooms.transform;

        //create doorway lists too loop over
        List<Doorway> allAvailableDoorways = new List<Doorway>(availableDoorways);
        Doorway doorway = endRoom.doorways[0];

        bool roomPlaced = false;

        //try all available doorways
        foreach (Doorway availableDoorway in allAvailableDoorways)
        {
            //Position Room
            Room room = (Room)endRoom;
            PlaceRoomPositioning.instance.PositionRoomAtDoorway(ref room, doorway, availableDoorway);

            //check room overlaps
            if (PlaceRoomPositioning.instance.CheckRoomOverlap(endRoom))
            {
                continue;
            }

            roomPlaced = true;

            //add place for stuff
            PlaceRoomPositioning.instance.AddAvailableRoomToList(endRoom);

            //Remove occupation doorways
            //doorway.gameObject.SetActive(false);
            availableDoorways.Remove(doorway);

            availableDoorway.gameObject.SetActive(false);
            availableDoorways.Remove(availableDoorway);

            //Exit loop if room has been placed
            break;
        }

        if (!roomPlaced)
        {
            Destroy(endRoom.gameObject);
            LevelGenerator.instance.ResetSetup();
        }
    }
}
