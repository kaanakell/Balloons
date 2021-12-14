using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Balloon
{
    public string name;

    public GameObject prefab;
    [Range(0f, 100f)]public float chance = 100f;

    [HideInInspector]public double _weight;
}


public class BalloonSpawner : MonoBehaviour
{
    [SerializeField] private Balloon[] balloons;

    private double accumulatedWeights;
    private System.Random rand = new System.Random();

    private void Awake()
    {
        CalculateWeights();
    }

    private void Start()
    {
        for (int i = 0; i < 20; i++)
            SpawnRandomBalloon(new Vector2(Random.Range(-3f, 3f), Random.Range(-4f, 4f)));
    }

    private void SpawnRandomBalloon(Vector2 position)
    {
        Balloon randomBalloon = balloons[GetRandomBalloonIndex()];

        Instantiate(randomBalloon.prefab, position, Quaternion.identity, transform);

        Debug.Log("<color=" + randomBalloon.name + "></color> Chance: <b>" + randomBalloon.chance + "</b>%");
    }

    private int GetRandomBalloonIndex()
    {
        double r = rand.NextDouble() * accumulatedWeights;

        for (int i = 0; i < balloons.Length; i++)
            if (balloons[i]._weight >= r)
                return i;
        return 0;
        
    }

    private void CalculateWeights()
    {
        accumulatedWeights = 0f;
        foreach(Balloon balloon in balloons)
        {
            accumulatedWeights += balloon.chance;
            balloon._weight = accumulatedWeights;
        }
    }
}
