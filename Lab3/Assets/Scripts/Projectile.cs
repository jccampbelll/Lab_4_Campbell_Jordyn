using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    public float initalVelocity = 3f;
  

	// Use this for initialization
	void Start ()
    {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.layer == 9)
        {
            if (collision.gameObject.GetComponent<EnemyScript>())
            {
                GameObject Enemy = collision.rigidbody.gameObject;
                collision.gameObject.GetComponent<EnemyScript>().EnemyDeath(Enemy);
            }
        }
        if (collision.gameObject.layer == 8)
        {
            GameObject Character = collision.rigidbody.gameObject;
            collision.gameObject.GetComponent<CharacterScript>().Death();
        }
        if (collision.gameObject.layer == 10)
        {
            Destroy(gameObject);
        }

    }

    public void GiveInitialVelocity()
    {
        GetComponent<Rigidbody2D>().AddForce(transform.right *= initalVelocity, ForceMode2D.Impulse);
       
    }

   
}
