using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {

    public float speed = 50;
    Rigidbody2D body;
    public GameObject beam;
    
	// Use this for initialization
	void Start () {
        body = GetComponent<Rigidbody2D>();
        beam.SetActive(false);
	}
	
	// Update is called once per frame
	void Update () {
		if(Input.GetAxis("Horizontal") > 0)
        {
            body.AddForce(new Vector2(speed,0));
        }
        if (Input.GetAxis("Horizontal") < 0)
        {
            body.AddForce(new Vector2(-speed, 0));
        }
        if (Input.GetAxis("Vertical") > 0)
        {
            body.AddForce(new Vector2(0, speed));
        }
        if (Input.GetAxis("Vertical") < 0)
        {
            body.AddForce(new Vector2(0, -speed));
        }

        if (Input.GetMouseButton(0))
        {
            beam.SetActive(true);
            beam.transform.eulerAngles = new Vector3(0,0,CalculateBeamAngle());
            beam.GetComponent<SpriteRenderer>().size = new Vector2(CalculateBeamLength(), 1);
        } else
        {
            beam.SetActive(false);
        }
    }

    float CalculateBeamAngle()
    {
        float angle;
        Vector2 p1 = Camera.main.WorldToScreenPoint(beam.transform.position);
        Vector2 p2 = Input.mousePosition;
        //print("Object Pos " + objectPos + "Mouse Pos " + mousePos);

        //angle = Vector2.Angle(mousePos, objectPos);
       // print("angle" +angle);
        angle = Mathf.Atan2(p2.y - p1.y, p2.x - p1.x) * 180 / Mathf.PI;

        return angle;
    }

    float CalculateBeamLength()
    {
        Vector2 p1 = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        Vector2 p2 = beam.transform.position;
        //float length = Mathf.Sqrt(Mathf.Pow(Mathf.Abs(p1.y - p2.y), 2) + Mathf.Pow(Mathf.Abs(p1.y - p2.y), 2));
        float length = Vector2.Distance(p1, p2);
        return length;
    }
}
