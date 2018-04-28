using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boss : MonoBehaviour {
    public GameObject projectilePrefab;
    public float projectileTimer = 0;
    public float projectileInterval = 2f;
    public float speed = 2f;
    public float height = 2f;
    public float health = 500;
    float maxHealth;
    bool berserk = false;
    public HealthBar healthBar;
    public bool IsDead = false;
	// Use this for initialization
	void Start () {
        maxHealth = health;
	}
	
	// Update is called once per frame
	void Update () {
        if (!IsDead)
        {
            if (health <= maxHealth / 2 && !berserk)
            {
                speed *= 1.25f;
                projectileInterval /= 2.5f;
                GetComponent<SpriteRenderer>().color = Color.red;
                berserk = true;
            }

            //move the boss up and down over time
            Vector3 pos = transform.position;
            float newY = Mathf.Sin(Time.time * speed);
            transform.position = new Vector3(pos.x, newY * height, pos.z);


            //Used for spawning Boss projectiless
            projectileTimer += Time.deltaTime;
            if (projectileTimer % 60 >= projectileInterval)
            {
                Instantiate(projectilePrefab, transform.position, Quaternion.identity);
                projectileTimer = 0;
            }
        } else
        {
            
        }
    }

    public void TakeDamage(float damage)
    {
        health -= damage;
        if(health<= 0)
        {
            health = 0;
            if(!IsDead)
            OnDeath();
        }
        healthBar.SetHealth(health / maxHealth);
        
    }


    public void OnDeath()
    {
        GetComponent<Animator>().SetBool("IsDead", true);
        IsDead = true;
        GetComponent<Rigidbody2D>().bodyType = RigidbodyType2D.Dynamic;
        GetComponent<Rigidbody2D>().AddForce(Vector2.up * 8, ForceMode2D.Impulse);
        Destroy(gameObject, 3);
    }
}
