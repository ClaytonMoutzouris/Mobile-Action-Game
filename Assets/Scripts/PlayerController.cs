using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {

    public float speed = 50;
    Rigidbody2D body;
    public GameObject beam;
    Vector3 previousGood = Vector3.zero;
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
            print("Clicked");
            DrawBeam_Mouse();
        }  else
        {
            beam.SetActive(false);
        }

        if(Input.GetAxis("RightStickH") > 0 || Input.GetAxis("RightStickH") < 0 || Input.GetAxis("RightStickV") > 0 || Input.GetAxis("RightStickV") < 0)
        {
            print("Using right stick");
            DrawBeam_Stick();
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

    Vector2 BeamDirection()
    {
        Vector2 direction = Input.mousePosition - Camera.main.WorldToScreenPoint(beam.transform.position);
        return direction;
    }

    void DrawBeam_Mouse()
    {
        Vector2 direction = BeamDirection();
        float angle = CalculateBeamAngle();
       RaycastHit2D[] hit = Physics2D.RaycastAll(beam.transform.position, direction, Mathf.Infinity);

        foreach (RaycastHit2D enemyhit in hit)
        {
            if (enemyhit.collider != null && enemyhit.collider.tag == "Enemy" || enemyhit.collider.tag == "Wall")
            {
                beam.SetActive(true);
                beam.transform.eulerAngles = new Vector3(0,0,angle);
                beam.GetComponent<SpriteRenderer>().size = new Vector2(Vector2.Distance(beam.transform.position, enemyhit.point), 1);
                break;
            }
        }
        
    }

    float CalculateBeamLength()
    {
        Vector2 p1 = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        Vector2 p2 = beam.transform.position;
        //float length = Mathf.Sqrt(Mathf.Pow(Mathf.Abs(p1.y - p2.y), 2) + Mathf.Pow(Mathf.Abs(p1.y - p2.y), 2));
        float length = Vector2.Distance(p1, p2);
        return length;
    }

    void DrawBeam_Stick()
    {
        //Vector2 direction = new Vector2(Input.GetAxis("RightStickH"), Input.GetAxis("RightStickV"));
        float x = Input.GetAxis("RightStickH");
        float y = Input.GetAxis("RightStickV");

        Vector3 dir = new Vector2(x, y);

        RaycastHit2D[] hit = Physics2D.RaycastAll(beam.transform.position, dir, Mathf.Infinity);

        float angle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg;
        Quaternion q = Quaternion.AngleAxis(angle, Vector3.forward);


        foreach (RaycastHit2D enemyhit in hit)
        {
            if (enemyhit.collider != null && enemyhit.collider.tag == "Enemy" || enemyhit.collider.tag == "Wall")
            {
                beam.SetActive(true);
                beam.transform.rotation = q;
                beam.GetComponent<SpriteRenderer>().size = new Vector2(Vector2.Distance(beam.transform.position, enemyhit.point), 1);
                break;
            }
        }
        

    }
}
