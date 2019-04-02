using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuildMenager : MonoBehaviour {

    public static BuildMenager buildMenager;

    private void Awake()
    {
        if (buildMenager != null)
            return;

        buildMenager = this;
    }

    //pobieranie prefabow turretow
    public GameObject prefabTurret1;
    public GameObject prefabTurret2;
    public GameObject prefabTurret3;
    public GameObject prefabTurret4;
    public GameObject prefabTurret5;

    private GameObject turretToBuild;

    public GameObject GetTurretToBild()
    {
        return turretToBuild;
    }

    public void SetTurretToBuild(GameObject turret)
    {
        turretToBuild = turret;
    }

}
