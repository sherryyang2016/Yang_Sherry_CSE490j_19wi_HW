using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SimpleCarousel : MonoBehaviour
{

    // public Vector3 rotationSpeed;
    private Transform myTrans;

    public void Awake()
    {
        myTrans = transform;
    }

    public void FixedUpdate()
    {
        myTrans.RotateAround(Vector3.zero, -Vector3.up, 3 * Time.deltaTime);
        //myTrans.Rotate(rotationSpeed * Time.deltaTime);
    }
}
