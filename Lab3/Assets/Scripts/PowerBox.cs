using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerBox : MonoBehaviour
{
   

    public GameObject projectileAbility;
    public GameObject doubleJump;
    public GameObject sizeAbility;
    public GameObject speedIncrease;
    public GameObject punch;
    public GameObject spawnPoint;

    // Use this for initialization


    // Update is called once per frame
    void Update()
    {

    }
    
    public int SpawnPowerup()
    {
        
        int randInt = Random.Range(0, 4);
        if (randInt == 1)
        {
            Instantiate(speedIncrease, spawnPoint.transform.position , Quaternion.identity);
            speedIncrease.transform.rotation = transform.rotation;
        }
        if (randInt == 2)
        {
            Instantiate(sizeAbility, spawnPoint.transform.position, Quaternion.identity);
            sizeAbility.transform.rotation = transform.rotation;
        }
        if (randInt == 3)
        {
            Instantiate(punch, spawnPoint.transform.position, Quaternion.identity);
            punch.transform.rotation = transform.rotation;
        }
        if (randInt == 4)
        {
            Instantiate(doubleJump, spawnPoint.transform.position, Quaternion.identity);
            doubleJump.transform.rotation = transform.rotation;
        }
        if (randInt == 0)
        {
            Instantiate(projectileAbility, spawnPoint.transform.position, Quaternion.identity);
            projectileAbility.transform.rotation = transform.rotation;
        }
        return randInt;
    }

}