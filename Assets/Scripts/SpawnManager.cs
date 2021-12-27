using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    public GameObject[] balloonPrefabs;
    public float spawnPosX = 9.50f;
    public float spawnPosZ = 9.50f;
    public float spawnPosY = 5.0f;
    public float startDelay = 2.0f;
    public float startInterval = 1.5f;

    [SerializeField]float delayAndSpawnRate = 2;
    [SerializeField]float timeUntilSpawnRateIncrease = 30;

    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("BalloonSpawnChance", startDelay, Random.Range(3f, 5f));
        //StartCoroutine(SpawnObject(delayAndSpawnRate));
    }

    // Update is called once per frame
    void Update()
    {
   
    }

    /*IEnumerator SpawnObject(float firstDelay)
    {
        float spawnRateCountdown = timeUntilSpawnRateIncrease;
        float spawnCountdown = firstDelay;
        while (true)
        {
            yield return null;
            spawnRateCountdown -= Time.deltaTime;
            spawnCountdown -= Time.deltaTime;

            // Should a new object be spawned?
            if (spawnCountdown < 0)
            {
                spawnCountdown += delayAndSpawnRate;
                Instantiate(balloonPrefabs[0], new Vector2(Random.Range(-9.5f, 9.5f), 5), Quaternion.identity);
                Instantiate(balloonPrefabs[1], new Vector2(Random.Range(-9.5f, 9.5f), 5), Quaternion.identity);
                Instantiate(balloonPrefabs[2], new Vector2(Random.Range(-9.5f, 9.5f), 5), Quaternion.identity);
            }

            // Should the spawn rate increase?
            if (spawnRateCountdown < 0 && delayAndSpawnRate > 1)
            {
                spawnRateCountdown += timeUntilSpawnRateIncrease;
                delayAndSpawnRate -= 0.1f;
            }
        }
    }*/


    /*void SpawnRandomBalloon()
    {
        int balloonIndex = Random.Range(0, balloonPrefabs.Length);
        Vector3 spawnPos = new Vector3(Random.Range(spawnPosX, -spawnPosX), spawnPosY, spawnPosZ);

        Instantiate(balloonPrefabs[balloonIndex], spawnPos, balloonPrefabs[balloonIndex].transform.rotation);
    }*/

    public void BalloonSpawnChance()
    {
        if (Random.value > 0.5) //%50 percent chance
        {//code here
            int balloonIndex = Random.Range(0, balloonPrefabs.Length);
            Vector3 spawnPos = new Vector3(Random.Range(spawnPosX, -spawnPosX), spawnPosY, spawnPosZ);

            Instantiate(balloonPrefabs[0], spawnPos, balloonPrefabs[balloonIndex].transform.rotation);
            return;
        }

        if (Random.value > 0.2) //%80 percent chance (1 - 0.2 is 0.8)
        { //code here
            int balloonIndex = Random.Range(0, balloonPrefabs.Length);
            Vector3 spawnPos = new Vector3(Random.Range(spawnPosX, -spawnPosX), spawnPosY, spawnPosZ);

            Instantiate(balloonPrefabs[1], spawnPos, balloonPrefabs[balloonIndex].transform.rotation);
            return;
        }

        if (Random.value > 0.7) //%30 percent chance (1 - 0.7 is 0.3)
        { //code here
            int balloonIndex = Random.Range(0, balloonPrefabs.Length);
            Vector3 spawnPos = new Vector3(Random.Range(spawnPosX, -spawnPosX), spawnPosY, spawnPosZ);

            Instantiate(balloonPrefabs[2], spawnPos, balloonPrefabs[balloonIndex].transform.rotation);
            return;
        }
    }
}
