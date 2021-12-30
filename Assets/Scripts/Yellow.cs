using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Yellow : Balloons
{
    public GameObject smallBalloonsPrefab;
    public GameObject splitfirePrefab;

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
            GameObject lol = Instantiate(smallBalloonsPrefab, transform.position + new Vector3(0.5f, 0, 0), transform.rotation);
            lol.GetComponent<Rigidbody2D>().AddForce(transform.right * Random.Range(2f, 4f), ForceMode2D.Impulse);
            lol = Instantiate(smallBalloonsPrefab, transform.position + new Vector3(-0.5f, 0, 0), transform.rotation);
            lol.GetComponent<Rigidbody2D>().AddForce(-transform.right * Random.Range(2f, 4f), ForceMode2D.Impulse);
            Instantiate(splitfirePrefab, transform.position, transform.rotation);
            gameManager.UpdateScore(pointValue);
            Destroy(gameObject);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.tag == "Ground")
        {
            FindObjectOfType<GameManager>().GameOver();
        }

    }
}
