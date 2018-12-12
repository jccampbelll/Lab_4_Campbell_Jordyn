using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoublejumpAbility : Ability
{
    

    public override void OnCollect()
    {
        base.OnCollect();
        {
            GetComponent<CharacterScript>().maxJumps = 2;
           
        }
    }

    public override void OnFinish()
    {
        base.OnFinish();
        GetComponent<CharacterScript>().maxJumps = 1;
        
    }

}
