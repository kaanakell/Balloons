using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Yellow : Balloons
{
    public GameObject smallBalloonsPrefab;

    public virtual void TakeDamage(float damage)
    {
        health -= damage;
        if (health <= 0)
        {
            Instantiate(smallBalloonsPrefab, transform.position, transform.rotation);
            Debug.Log("smol kak");
            Destroy(gameObject);
        }
    }
}
