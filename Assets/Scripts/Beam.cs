using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Beam : MonoBehaviour {
    float baseDPS = 5;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void LateUpdate () {
		 //if(GetComponent<Collider2D>())
         //if(GetComponent<Collider2D>().Con)
	}

    private void OnTriggerStay2D(Collider2D collision)
    {
        print(CalculateDamage());
    }

    float CalculateDamage()
    {
        return baseDPS / GetComponent<SpriteRenderer>().size.x;
    }
}
