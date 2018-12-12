using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileAbility : Ability
{

    public GameObject projectile;
    public Transform spawnpoint;


    public override void OnCollect()
    {
        base.OnCollect();
    }

    public override void OnUpdate()
    {
        base.OnUpdate();
        if (Input.GetButtonDown("Fire1"))
        {
            GameObject spawnProjectile = Instantiate(projectile, spawnpoint.transform.position, Quaternion.identity);
            spawnProjectile.transform.rotation = transform.rotation;
            spawnProjectile.GetComponent<Projectile>().GiveInitialVelocity();
        }
    }

 

}
