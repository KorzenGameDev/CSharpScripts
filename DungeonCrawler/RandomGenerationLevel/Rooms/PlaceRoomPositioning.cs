using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlaceRoomPositioning : MonoBehaviour
{
    static public PlaceRoomPositioning instance;

    LayerMask roomLayerMask;

    private void Awake()
    {
        if (instance == null)
            instance = this;

        roomLayerMask = LayerMask.GetMask("Room");
    }

    public void PositionRoomAtDoorway(ref Room room, Doorway roomDoorway, Doorway targetDoorway)
    {
        //reset room position and rotation;
        room.transform.position = Vector3.zero;
        room.transform.rotation = Quaternion.identity;

        //Rotate room to match previous doorway orientation
        Vector3 targetDoorwayEuler = targetDoorway.transform.eulerAngles;
        Vector3 roomDoorwayEuler = roomDoorway.transform.eulerAngles;
        float deltaAngle = Mathf.DeltaAngle(roomDoorwayEuler.y, targetDoorwayEuler.y);
        Quaternion currentRoomTargetRotation = Quaternion.AngleAxis(deltaAngle, Vector3.up); //TODO check this becouse can be error
        room.transform.rotation = currentRoomTargetRotation * Quaternion.Euler(0, 180f, 0);

        //position room
        Vector3 roomPositionOffset = roomDoorway.transform.position - room.transform.position;
        room.transform.position = targetDoorway.transform.position - roomPositionOffset;
    }

    public bool CheckRoomOverlap(Room room)
    {
        Bounds bounds = room.RoomBounds;
        bounds.Expand(-0.1f);

        Collider[] colliders = Physics.OverlapBox(bounds.center, bounds.size / 2f, room.transform.rotation, roomLayerMask);
        if (colliders.Length > 0)
        {
            foreach (Collider c in colliders)
            {
                if (c.transform.parent.gameObject.Equals(room.gameObject))
                { continue; }
                else
                {
                    Debug.Log("Detect collision");
                    return true;
                }
            }
        }
        return false;
    }

    public void AddDoorwaysToList(Room room, ref List<Doorway> list)
    {
        foreach (Doorway doorway in room.doorways)
        {
            int r = Random.Range(0, list.Count);
            list.Insert(r, doorway);
        }
    }
    public void AddAvailableRoomToList(Room room)
    {
        //add key place to list
        if (room.keyPlace.Length > 0)
        {
            foreach (Transform keyPosition in room.keyPlace)
            {
                PlaceKey.instance.availablesPlaceForKey.Add(keyPosition);
            }
        }
        //add item place to list
        if (room.items.Length > 0)
        {
            foreach (Transform item in room.items)
            {
                PlaceItems.instance.availablePlaceForItem.Add(item);
            }
        }
        if (room.enemyPlace.Length > 0)
        {
            foreach (Transform enemyPosition in room.enemyPlace)
            {
                EnemyPlace.instance.availablesPlaceForCommonCreatures.Add(enemyPosition);
            }
        }
        if (room.miniBossPlace.Length > 0)
        {
            foreach (Transform miniBossPosition in room.miniBossPlace)
            {
                EnemyPlace.instance.availablesPlaceForMiniBossCreatures.Add(miniBossPosition);
            }
        }
        if (room.bossPlace.Length > 0)
        {
            foreach (Transform bossPosition in room.bossPlace)
            {
                EnemyPlace.instance.availablesPlaceForBossCreatures.Add(bossPosition);
            }
        }
    }
}
