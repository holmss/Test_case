using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Saw : MonoBehaviour
{
    public float rotVelocity = 100;
    void Update()
    {
        transform.Rotate(0, rotVelocity * Time.deltaTime, 0);
    }
}
