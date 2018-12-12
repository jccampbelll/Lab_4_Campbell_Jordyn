using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyScript : MonoBehaviour
{
    public float enemySpeed;
    public GameObject waypoint1;
    public GameObject waypoint2;

    public Animator animDeath;

    private float direction = 1;

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (transform.position.x - waypoint1.transform.position.x < 0.1f)
        {
            direction = 1;
            transform.localScale = new Vector3(-1, 1, 1);
        }
        else if (waypoint2.transform.position.x - transform.position.x < 0.1f)
        {
            direction = -1;
            transform.localScale = new Vector3(1, 1, 1);
        }
        transform.position += direction * Vector3.right * enemySpeed * Time.deltaTime;
    }

    public void EnemyDeath(GameObject Enemy)
    {
        enemySpeed = 0;
        animDeath.SetBool("enemyDeath", true);
        GetComponent<Rigidbody2D>().AddForce(Vector3.up * 3, ForceMode2D.Impulse);
        GetComponent<Collider2D>().enabled = false;
    }

}