using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CamMove : MonoBehaviour
{
    public Transform target;
    Vector3 distance, move;

    void Start()
    {
        distance = transform.position - target.position;
    }

    // Update is called once per frame
    void Update()
    {
        move = target.position + distance;

        move.y = 1.2f;
        move.x = distance.x;

        transform.position = move;
    }
}
