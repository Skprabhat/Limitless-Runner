using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CloudSpwanner : MonoBehaviour
{

    public GameObject Clouds;
    float SpawnMin = 2f;
    float SpawnMax = 4f;

    void Start()
    {
        Spawn();
    }
    void Spawn()
    {
        Instantiate(Clouds, transform.position, Quaternion.identity);
        Invoke("Spawn", Random.Range(SpawnMin, SpawnMax));
    }
}
