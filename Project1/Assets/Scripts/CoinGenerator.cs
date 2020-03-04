using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinGenerator : MonoBehaviour {

    public float CoinGenerationTime;
    public GameObject[] CoinPreFabs;
    float timer;
    int Selector;
    float GenerationPoint;
	// Use this for initialization
	void Start () {
        timer = CoinGenerationTime;
	}

    // Update is called once per frame
    void Update()
    {
        Selector = Random.Range(0, CoinPreFabs.Length);
        GenerationPoint = Random.Range(-0.5f, 1.4f);
        Vector2 Position = new Vector2(transform.position.x, GenerationPoint);
        if (timer > 0)
            timer -= Time.deltaTime;
        else
        {
            Instantiate(CoinPreFabs[Selector], Position, Quaternion.identity);
            timer = CoinGenerationTime;
        }

    }
}
