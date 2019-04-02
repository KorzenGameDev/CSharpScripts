using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExtraLive : MonoBehaviour
{
    public Energy energy;
    
	// Use this for initialization
	void Start ()
    {
        energy = FindObjectOfType<Energy>();
	}
	
	// Update is called once per frame
	void Update ()
    {
		
	}

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.name == "Player" && energy.energy<5)
        {
            energy.energy += 1;
            Destroy(gameObject, 0.1f);
        }
            
    }
}
