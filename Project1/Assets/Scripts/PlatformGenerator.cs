using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformGenerator : MonoBehaviour
{

    public List<GameObject> Platforms = new List<GameObject>();
    public GameObject[] PlatformPreFab;
    public int CubeCount = 100;
   // private GameObject previousPlatform;
    public Transform GenerationPoint;
    float[] Width;
    float DistanceBetweenSpawn;
    float MinDistane = 0.0f, MaxDistance = 0.6f;
    int PlatformSelector;
    //float PreviousPlatformSize;
    // Start is called before the first frame update
    void Start()
    {
        Width = new float[PlatformPreFab.Length];
        for (int i = 0; i < PlatformPreFab.Length; i++)
        {
            Width[i] = PlatformPreFab[i].gameObject.GetComponent<BoxCollider2D>().size.x;
        }

        instance();
    }

    public void instance()
    {
        for (int i = 0; i < CubeCount; i++)
        {
            var GameObj = Instantiate(PlatformPreFab[Random.Range(0, PlatformPreFab.Length)], gameObject.transform.position, Quaternion.identity);
            GameObj.SetActive(false);
            Platforms.Add(GameObj);
        }
    }
    private void Update()
    {
        DistanceBetweenSpawn = Random.Range(MinDistane, MaxDistance);
        PlatformSelector = Random.Range(0, PlatformPreFab.Length);
        if (transform.position.x < GenerationPoint.position.x)
        {
            spawn();
        }
    }
    public void spawn()
    {
        //previousPlatform = Platforms[8];
       // PreviousPlatformSize = previousPlatform.GetComponent<BoxCollider2D>().size.x/2;
        if (PlatformSelector == 0)
        {
            transform.position = new Vector3(transform.position.x + Width[(PlatformSelector)]+ Width[0]/2/*(Platforms[8].GetComponent<BoxCollider2D>().size.x) / 3 */+ DistanceBetweenSpawn, transform.position.y, transform.position.z);
            Platforms[0].transform.position = new Vector2(transform.position.x, -4.0f);
        }
        else if (PlatformSelector == 1)
        {
            transform.position = new Vector3(transform.position.x + Width[(PlatformSelector)]/*(Platforms[8].GetComponent<BoxCollider2D>().size.x) / 3*/ + DistanceBetweenSpawn, transform.position.y, transform.position.z);
            Platforms[0].transform.position = new Vector2(transform.position.x, -5.0f);
        }
        var gob = Platforms[0];
        gob.SetActive(true);
        GameObject temp = Platforms[0];
        Platforms.RemoveAt(0);
        Platforms.Add(temp);
    }

    public void backtolist(GameObject obj1)
    {
        obj1.SetActive(false);
        Platforms.Add(obj1);
    }
}
