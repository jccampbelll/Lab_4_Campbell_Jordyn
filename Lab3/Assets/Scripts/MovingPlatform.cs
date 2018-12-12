using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingPlatform : MonoBehaviour
{
    public float platformSpeed;

    private Vector3 posA;
    private Vector3 posB;
    private Vector3 nextOne;



    [SerializeField]
    private Transform childTransform;

    [SerializeField]
    private Transform transformB;

	// Use this for initialization
	void Start ()
    {
        posA = childTransform.localPosition;
        posB = transformB.localPosition;
        nextOne = posB; ;  
	}
	
	// Update is called once per frame
	void Update ()
    {
        PlatformMove();
	}

    private void PlatformMove()
    {
        childTransform.localPosition = Vector3.MoveTowards(childTransform.localPosition, nextOne, platformSpeed * Time.deltaTime);

        if (Vector3.Distance(childTransform.localPosition,nextOne) <= 0.1)
        {
            Destination();
        }
    }

    private void Destination()
    {
        //If nextOne is different than position A it uses A if it is equal to A it uses B
        nextOne = nextOne != posA ? posA : posB;
    }
}
