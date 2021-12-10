using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    public float speed;
    private Rigidbody2D rbBullet;
    public float lifeTime;
    public float distance;
    public LayerMask whatIsSolid;
    [SerializeField] float damage;
    //public GameObject destroyEffect;
    private bool hit = false;
    // Start is called before the first frame update
    void Start()
    {
        rbBullet = GetComponent<Rigidbody2D>();
        rbBullet.velocity = transform.up * speed;

        Invoke("DestroyProjectile", lifeTime);
            
    }

    //// Update is called once per frame
    //void Update()
    //{
    //    hit = Physics2D.Raycast(transform.position, transform.up, distance, whatIsSolid);
    //    //if (hitInfo.collider.CompareTag("Balloon"))
    //    //{
    //    //    Debug.Log("Balloon Poped");
    //    //    hitInfo.collider.GetComponent<Balloons>().TakeDamage(damage);
    //    //}
    //    if (hit)
    //    {
    //        RaycastHit2D lol = Physics2D.Raycast(transform.position, transform.up, distance, whatIsSolid);
    //        if (lol.collider.CompareTag("Balloon"))
    //        {
    //            lol.collider.GetComponent<Balloons>().TakeDamage(damage);
                
    //            Debug.Log("Balloon Poped");
    //        }
    //    }

    //}

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Balloon"))
        {
            Tags(collision);
            //Instantiate(destroyEffect, transform.position, Quaternion.identity);
            Destroy(gameObject);
        }
    }

    public void Tags(Collider2D collision)
    {
        if (collision.name == "Yellow Balloon")
        {
            collision.GetComponent<Yellow>().TakeDamage(damage);

        }
        if (collision.name == "Red Balloon")
        {
            collision.GetComponent<Red>().TakeDamage(damage);

        }
        if (collision.name == "Green Balloon")
        {
            collision.GetComponent<Green>().TakeDamage(damage);

        }
    }

    void DestroyProjectile()
    {
        //Instantiate(destroyEffect, transform.position, Quaternion.identity);
        Destroy(gameObject);
    }
}
