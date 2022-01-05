using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    private Rigidbody2D rbBullet;
    public float lifeTime;
    public float distance;
    public LayerMask whatIsSolid;
    [SerializeField] float damage;
    //public GameObject destroyEffect;
    //private bool hit = false;
    // Start is called before the first frame update

    [SerializeField] int speed = 10;

    [SerializeField] bool towards_mouse = true;

    void Start()
    {
        rbBullet = GetComponent<Rigidbody2D>();

        if (towards_mouse)
        {
            Vector3 mousepos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            Vector2 moveDirection = (mousepos - transform.position);
            moveDirection.Normalize();
            rbBullet.rotation = Mathf.Atan2(moveDirection.y, moveDirection.x) * Mathf.Rad2Deg;
            rbBullet.velocity = moveDirection * speed;
        }
        else
        {
            Vector2 moveDirection = (transform.GetChild(0).position - transform.position);
            moveDirection.Normalize();
            rbBullet.velocity = moveDirection * speed;
        }

        Destroy(gameObject, lifeTime);
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Red"))
        {
            collision.GetComponent<Red>().TakeDamage(damage);
            Destroy(gameObject);
            //Instantiate(destroyEffect, transform.position, Quaternion.identity);
        }
        else if (collision.CompareTag("Yellow"))
        {
            collision.GetComponent<Yellow>().TakeDamage(damage);
            Destroy(gameObject);
        }
        else if (collision.CompareTag("Green"))
        {
            collision.GetComponent<Green>().TakeDamage(damage);
            Destroy(gameObject);
        }
        else if (collision.CompareTag("Small"))
        {
            collision.GetComponent<SmallScore>().TakeDamage(damage);
            Destroy(gameObject);
        }
    }


    void DestroyProjectile()
    {
        //Instantiate(destroyEffect, transform.position, Quaternion.identity);
        Destroy(gameObject);
    }

    private void OnBecameInvisible()
    {
        Destroy(gameObject);
    }
}
