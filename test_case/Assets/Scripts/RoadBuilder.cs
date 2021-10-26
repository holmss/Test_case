using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoadBuilder : MonoBehaviour
{
    public GameObject[] RoadPrefabs;
    public GameObject start, finish;
    List<GameObject> Road = new List<GameObject>();

    public float num = 3;
    float plotLen = 30;

    float posZ, posY = -4;

    void Start()
    {
        posZ = start.transform.position.z;

        Road.Add(start);

        for (int i = 0; i < num; ++i)
            RoadGen();

        posZ += plotLen;
        GameObject finishLine = (GameObject)Instantiate(finish, new Vector3(0, posY, posZ - 10), transform.rotation);
    }

    void RoadGen()
    {
        GameObject roadPlot = Instantiate(RoadPrefabs[Random.Range(0, RoadPrefabs.Length)], transform);

        posZ += plotLen;
        roadPlot.transform.position = new Vector3(0, posY, posZ);

        Road.Add(roadPlot);
    }
}
