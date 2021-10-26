using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinSpawner : MonoBehaviour
{
    public float CoinSpawnChance;

    public GameObject coins;

    void Start()
    {
        CoinSpawnChance = Random.Range(50, 100);
        coins.SetActive(Random.Range(0, 100) <= CoinSpawnChance);
    }
}
