using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour {
    static GameObject current;
    public Image health;
	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	public void SetHealth (float healthPercent) {
        health.transform.localScale = new Vector3(healthPercent, 1, 1);
	}
}
