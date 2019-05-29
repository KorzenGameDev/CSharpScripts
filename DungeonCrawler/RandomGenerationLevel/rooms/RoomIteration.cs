using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoomIteration : MonoBehaviour
{
    public static RoomIteration instance;

    public int sectorIteration = 0;
    public int roomIteration = 0;
    public int lockedIteration = 0;

    private void Awake()
    {
        if (instance == null)
            instance = this;
    }

    public void LoadIteration()
    {
        if (RoomGeneratorController.instance.accurentDemension)
        {
            sectorIteration = RoomGeneratorController.instance.sectorsAmount;
            roomIteration = RoomGeneratorController.instance.commonRoomAmount;
            lockedIteration = RoomGeneratorController.instance.lockedRoomAmount;
        }

        else if (RoomGeneratorController.instance.randomDemension)
        {
            int min = 0;
            int max = 0;

            //sectors
            min = RoomGeneratorController.instance.sectorsRandomRangeAmount.x;
            max = RoomGeneratorController.instance.sectorsRandomRangeAmount.y;

            if (min >= max && max >= 0) min = max;

            sectorIteration = Random.Range(min, max);

            //normal rooms
            min = RoomGeneratorController.instance.commonRoomRandomRangeAmount.x;
            max = RoomGeneratorController.instance.commonRoomRandomRangeAmount.y;

            if (min >= max && max >= 0) min = max;

            roomIteration = Random.Range(min, max);

            //locked
            min = RoomGeneratorController.instance.lockedRoomRangeAmount.x;
            max = RoomGeneratorController.instance.lockedRoomRangeAmount.y;

            if (min >= max && max >= 0) min = max;

            lockedIteration = Random.Range(min, max);
        }

        else
        {
            Debug.Log("Jestes debilem level generation ma złe iteracje popraw");
        }
    }

    public void Restart()
    {
        sectorIteration = 0;
        roomIteration = 0;
        lockedIteration = 0;
    }
}
