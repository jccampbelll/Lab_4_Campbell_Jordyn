using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SizeAbility : Ability
{
    public override void OnCollect()
    {
        base.OnCollect();
        transform.localScale = new Vector3(2, 2, 2);
    }

    public override void OnFinish()
    {
        base.OnFinish();
        transform.localScale = new Vector3(1, 1, 1);
    }


}
