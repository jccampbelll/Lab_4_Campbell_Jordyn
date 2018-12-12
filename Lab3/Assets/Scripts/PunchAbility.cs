using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PunchAbility : Ability
{

    public override void OnCollect()
    {
        base.OnCollect();

    }

    public override void OnUpdate()
    {
        base.OnUpdate();
        if (Input.GetButtonDown("Fire2"))
        {
            GetComponent<CharacterScript>().animPunch.SetBool("punch", true);
        }
        if (Input.GetButtonUp("Fire2"))
        {
            GetComponent<CharacterScript>().animPunch.SetBool("punch", false);
        }
    }

    public override void OnFinish()
    {
        base.OnFinish();
    }

    public void OnCollisionEnter2D(Collision2D collision)
    {
        if (Input.GetButtonDown("Fire2"))
        {
            GameObject Enemy = collision.rigidbody.gameObject;
            collision.gameObject.GetComponent<EnemyScript>().EnemyDeath(Enemy);
        }
    }


}
