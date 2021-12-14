using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Powerup : MonoBehaviour
{
    public GameObject pickupEffect;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            PickUp(other);
        }
    }

    void PickUp(Collider2D player)
    {
        //Spawn Effect
        Instantiate(pickupEffect, transform.position, pickupEffect.transform.rotation);

        //Apply effect to player
        player.GetComponent<Player>().Change_Power("threeway", 3f);


        //Destroy power up object
        Destroy(gameObject);
    }
}
