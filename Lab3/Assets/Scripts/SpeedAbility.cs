using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpeedAbility : Ability
{
    public override void OnCollect()
    {
        base.OnCollect();
        GetComponent<CharacterScript>().playerSpeed = 5;
       
    }

    public override void OnFinish()
    {
        base.OnFinish();
        GetComponent<CharacterScript>().playerSpeed = 3;
    }

  
}
