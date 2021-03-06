using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Green : Balloons
{
    public GameObject smallBalloonsPrefab;
    public GameObject threewayPrefab;

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
            Instantiate(threewayPrefab, transform.position, transform.rotation);
            Instantiate(deathEffect, transform.position, Quaternion.identity);
            FindObjectOfType<AudioManager>().Play("Death");
            FindObjectOfType<AudioManager>().Play("Green");
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
