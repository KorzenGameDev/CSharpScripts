using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelGenerator : MonoBehaviour
{
    static public LevelGenerator instance;

    private void Awake()
    {
        if (instance == null)
            instance = this;
    }


    private void Start()
    {
        RoomGeneratorController.instance.LoadRooms();
        StartCoroutine(Setup());
    }

    IEnumerator Setup()
    {
        RoomIteration.instance.LoadIteration();
        WaitForSeconds startup = new WaitForSeconds(0.1f);
        WaitForFixedUpdate interval = new WaitForFixedUpdate();

        yield return startup;

        //place startRoom
        if (!RoomPlace.instance.entryRoom)
            RoomPlace.instance.PlaceEntryRoom();
        yield return interval;

        for (int i = 0; i < RoomIteration.instance.sectorIteration; i++)
        {
            for (int j = 0; j < RoomIteration.instance.roomIteration; j++)
            {
                if(RoomGeneratorController.instance.commonRooms.Count > 0)
                    RoomPlace.instance.PlaceRoom(RoomGeneratorController.instance.commonRooms,null);
                yield return interval;
            }

            if (RoomGeneratorController.instance.lockedRooms.Count > 0)
            {
                for (int j = 0; j < RoomIteration.instance.lockedIteration; j++)
                {
                    RoomPlace.instance.PlaceRoom(RoomGeneratorController.instance.lockedRooms,null);
                    yield return interval;
                }
            }

            if(RoomGeneratorController.instance.questRooms.Count>0)
            {
                Room room = RoomGeneratorController.instance.questRooms[Random.Range(0, RoomGeneratorController.instance.questRooms.Count)];
                RoomPlace.instance.PlaceRoom(null, room);
                RoomGeneratorController.instance.questRooms.Remove(room);
            }

            yield return interval;
        }

        while(RoomGeneratorController.instance.questRooms.Count > 0)
        {
            Room room = RoomGeneratorController.instance.questRooms[Random.Range(0, RoomGeneratorController.instance.questRooms.Count)];
            RoomPlace.instance.PlaceRoom(null, room);
            RoomGeneratorController.instance.questRooms.Remove(room);
        }

        RoomPlace.instance.PlaceRoom(RoomGeneratorController.instance.exitRooms,null);
        yield return interval;

        ItemPlace.instance.StartPlace();
        EnemyPlace.instance.StartPlace();

        //TODO delete this error
        Debug.LogError("LevelGenerator finished");
    }

 
   
    public void Restart()
    {
        Debug.Log("Reset level Generator");
        StopAllCoroutines();

        //Rooms
        RoomPlace.instance.Restart();
        RoomIteration.instance.Restart();

        //Enemy
        EnemyPlace.instance.Restart();
        EnemyIteration.instance.Restart();

        //Items
        ExtraItemPlace.instance.Restart();
        ItemPlace.instance.Restart();

        ClearConsole();

        //reset couroutine
        StartCoroutine(Setup());
    }

    static void ClearConsole()
    {
        var logEntries = System.Type.GetType("UnityEditor.LogEntries, UnityEditor.dll");

        var clearMethod = logEntries.GetMethod("Clear", System.Reflection.BindingFlags.Static | System.Reflection.BindingFlags.Public);

        clearMethod.Invoke(null, null);
    }
}
