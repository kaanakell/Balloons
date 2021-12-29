using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SmallScore :   Balloons
{
    private GameManager gameManager;

    public int pointValue;

    void Start()
    {
        gameManager = GameObject.Find("Game Manager").GetComponent<GameManager>();
    }

    public virtual void TakeDamage(float damage)
    {
        health -= damage;
        if (health <= 0)
        {

            gameManager.UpdateScore(pointValue/2);

            Destroy(gameObject);

        }
    }
}
