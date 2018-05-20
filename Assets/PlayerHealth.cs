using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour {
    public GameObject heartPrefab;
    public static PlayerHealth instance;
    public List<GameObject> hearts;
	// Use this for initialization
	void Awake () {
        instance = this;
        hearts = new List<GameObject>();
	}

    public void Initialize(int startingHealth)
    {
        for(int i = 0; i<startingHealth; i++)
        {
            hearts.Add(Instantiate(heartPrefab, transform));
        }
    }
	
	// Update is called once per frame
	public void UpdateHealth (int health) {
		if(hearts.Count > health)
        {
            GameObject toDestroy = hearts[0];
            hearts.RemoveAt(0);
            Destroy(toDestroy);
            UpdateHealth(health);
        } else if(hearts.Count < health)
        {
            hearts.Add(Instantiate(heartPrefab, transform));
            UpdateHealth(health);
        }
    }
}
