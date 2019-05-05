using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelGenerator : MonoBehaviour
{
    static public LevelGenerator instance;

    int sectorIteration = 0;
    int roomIteration = 0;
    int lockedIteration = 0;

    private void Awake()
    {
        if (instance == null)
            instance = this;
    }


    private void Start()
    {
        StartCoroutine(Setup());
        LoadIteration();
        RoomGeneratorController.instance.LoadRooms();
    }

    IEnumerator Setup()
    {
        WaitForSeconds startup = new WaitForSeconds(0.1f);
        WaitForFixedUpdate interval = new WaitForFixedUpdate();

        yield return startup;

        //place startRoom
        if (!PlaceRooms.instance.startRoom)
            PlaceRooms.instance.PlaceStartRoom();
        yield return interval;

        for (int i = 0; i < sectorIteration; i++)
        {
            for (int j = 0; j < roomIteration; j++)
            {
                //placed othe room
                if(RoomGeneratorController.instance.normalRoom.Count>0)
                    PlaceRooms.instance.PlaceNormalRoom();
                yield return interval;
            }

            if (RoomGeneratorController.instance.lockedRoom.Count > 0)
            {
                //Iteration
                for (int j = 0; j < lockedIteration; j++)
                {
                    Debug.Log("placed locked room");
                    PlaceRooms.instance.PlaceLockedRoom();
                    yield return interval;
                }
            }

            yield return interval;
        }


        //placed endRoom
        PlaceRooms.instance.PlaceEndRoom();
        yield return interval;

        //Equipment in chest
        PlaceItems.instance.StartPlace();

        //placedEnemy
        EnemyPlace.instance.StartPlace();

        //TODO delete this error
        Debug.LogError("LevelGenerator finished");
    }

 
   
    public void ResetSetup()
    {
        Debug.Log("Reset level Generator");
        StopAllCoroutines();

        //destroty room
        if (PlaceRooms.instance.startRoom)
        {
            Destroy(PlaceRooms.instance.startRoom.gameObject);
        }
        if (PlaceRooms.instance.endRoom)
        {
            Destroy(PlaceRooms.instance.endRoom.gameObject);
        }
        foreach (Room room in PlaceRooms.instance.placedRooms)
        {
            Destroy(room.gameObject);
        }

        
        foreach (GameObject k in PlaceKey.instance.keyInUse)
        {
            Destroy(k);
        }

        //clear list
        PlaceRooms.instance.placedRooms.Clear();
        PlaceRooms.instance.availableDoorways.Clear();

        PlaceKey.instance.availablesPlaceForKey.Clear();
        PlaceKey.instance.keyInUse.Clear();

        PlaceItems.instance.ResetItem();

        EnemyPlace.instance.availablesPlaceForBossCreatures.Clear();
        EnemyPlace.instance.availablesPlaceForCommonCreatures.Clear();
        EnemyPlace.instance.availablesPlaceForMiniBossCreatures.Clear();
        EnemyPlace.instance.placedCreatures.Clear();

        ClearConsole();

        //reset couroutine
        StartCoroutine(Setup());
    }

    void LoadIteration()
    {
        if(RoomGeneratorController.instance.accurentDemension)
        {
            sectorIteration = RoomGeneratorController.instance.sectorsAmount;
            roomIteration = RoomGeneratorController.instance.normalRoomAmount;
            lockedIteration = RoomGeneratorController.instance.lockedRoomAmount;
        }

        else if(RoomGeneratorController.instance.randomDemension)
        {
            int min = 0;
            int max = 0;

            //sectors
            min = RoomGeneratorController.instance.sectorsRandomRangeAmount.x;
            max = RoomGeneratorController.instance.sectorsRandomRangeAmount.y;

            if (min >= max && max >=0) min = max;

            sectorIteration = Random.Range(min, max);

            //normal rooms
            min = RoomGeneratorController.instance.normalRoomRandomRangeAmount.x;
            max = RoomGeneratorController.instance.normalRoomRandomRangeAmount.y;

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

    static void ClearConsole()
    {
        var logEntries = System.Type.GetType("UnityEditor.LogEntries, UnityEditor.dll");

        var clearMethod = logEntries.GetMethod("Clear", System.Reflection.BindingFlags.Static | System.Reflection.BindingFlags.Public);

        clearMethod.Invoke(null, null);
    }
}
