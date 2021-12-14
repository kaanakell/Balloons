using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    public GameObject[] balloonPrefabs;
    public float spawnPosX = 20.0f;
    public float spawnPosZ = 20.0f;
    public float startDelay = 2.0f;
    public float startInterval = 1.5f;

    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("SpawnRandomBalloon", startDelay, Random.Range(3f, 5f));
    }

    // Update is called once per frame
    void Update()
    {

    }

    void SpawnRandomBalloon()
    {
        int balloonIndex = Random.Range(0, balloonPrefabs.Length);
        Vector3 spawnPos = new Vector3(Random.Range(spawnPosX, -spawnPosX), 0, spawnPosZ);

        Instantiate(balloonPrefabs[balloonIndex], spawnPos, balloonPrefabs[balloonIndex].transform.rotation);
    }
}
