using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boss : MonoBehaviour {
    public GameObject projectilePrefab;
    public float projectileTimer = 0;
    public float projectileInterval = 2f;
    public float speed = 2f;
    public float height = 2f;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {

        //move the boss up and down over time
        Vector3 pos = transform.position;
        float newY = Mathf.Sin(Time.time * speed);
        transform.position = new Vector3(pos.x, newY * height, pos.z) ;


        //Used for spawning Boss projectiless
        projectileTimer += Time.deltaTime;
        if(projectileTimer%60 >= projectileInterval)
        {
            Instantiate(projectilePrefab, transform.position, Quaternion.identity);
            projectileTimer = 0;
        }
    }
}
