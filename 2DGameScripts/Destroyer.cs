using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Destroyer : MonoBehaviour
{
    // czas zycia obiektu
    public float lifeTime=2f;

	void Start () {
        //niszczenie obiektu
       Destroy(gameObject, lifeTime);
	}
}
