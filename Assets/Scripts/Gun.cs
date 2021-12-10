using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gun : MonoBehaviour
{
    public float offset;

    public GameObject projectilePrefab;
    public Transform shotPoint;

    private float timeBetweenShots;
    public float startTimeBetweenShots;

    // Update is called once per frame
    void Update()
    {
        Vector3 difference = Camera.main.ScreenToWorldPoint(Input.mousePosition) - transform.position;
        float rotZ = Mathf.Atan2(difference.y, difference.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(0f, 0f, rotZ + offset);

        if(timeBetweenShots <= 0)
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                Instantiate(projectilePrefab, shotPoint.position, transform.rotation);
            }
        }
        else
        {
            timeBetweenShots -= Time.deltaTime;
        }
        

    }
}
