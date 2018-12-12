using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyProjectile : MonoBehaviour
{
    public GameObject projectile;
    public GameObject spawnPoint;
    public int time = 3;
    public float fireRate = 10;

    private float timer;
	// Update is called once per frame
	void Update ()
    {
        
	}

    private void Start()
    {
        Shoot();

    }
    private void Shoot()
    {
        timer = 1 / fireRate;
        GameObject spawnProjectile = Instantiate(projectile, spawnPoint.transform.position, Quaternion.identity);
        spawnProjectile.transform.rotation = transform.rotation;
        spawnProjectile.GetComponent<Projectile>().GetComponent<Rigidbody2D>().AddForce(transform.right * timer);
    }

 
}
