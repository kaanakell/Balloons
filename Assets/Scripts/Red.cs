using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Red : Balloons
{
    public GameObject smallBalloonsPrefab;



    public virtual void TakeDamage(float damage)
    {
        health -= damage;
        if (health <= 0)
        {
             GameObject lol = Instantiate(smallBalloonsPrefab, transform.position + new Vector3(0.2f, 0, 0), transform.rotation);
             lol.GetComponent<Rigidbody2D>().AddForce(transform.right * Random.Range(0.5f, 1f), ForceMode2D.Impulse);
             lol = Instantiate(smallBalloonsPrefab, transform.position + new Vector3(-0.2f, 0, 0), transform.rotation);
            lol.GetComponent<Rigidbody2D>().AddForce(-transform.right * Random.Range(0.5f, 1f), ForceMode2D.Impulse);
            Debug.Log("smol");
             Destroy(gameObject);
        }
    }
}
