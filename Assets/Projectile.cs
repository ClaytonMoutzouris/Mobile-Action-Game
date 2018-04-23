using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour {
    public float speed = 5;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        Vector3 pos = transform.position;
        float newX = Time.deltaTime * speed;
        transform.position = new Vector3(pos.x-newX, pos.y, pos.z);

        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        print("Collider " + collision.tag);
        if (collision.tag == "Player")
            Destroy(gameObject);

    }
}
