using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class Player : MonoBehaviour
{
    [SerializeField] GameObject obj_bullet;

    private Camera cam;

    private Rigidbody2D playerRb;

    private Transform _transform_gun;



    public bool hasPowerup = false;

    [SerializeField] private float speed = 5f, rate_of_fire = 0.1f, xRange = 8f;

    private bool canAttack = true;

    private string power = "none";

    private void Awake()
    {
        //_gun = GetComponentInChildren<Gun>();
        _transform_gun = transform.GetChild(0);
        cam = Camera.main;
        
    }

    void Start()
    {
        playerRb = GetComponent<Rigidbody2D>();
        
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 diff = cam.ScreenToWorldPoint(Input.mousePosition) - transform.position;
        float rotZ = Mathf.Atan2(diff.y, diff.x) * Mathf.Rad2Deg;
        _transform_gun.rotation = Quaternion.Euler(0f, 0f, rotZ + 90);

        if (Input.GetKey(KeyCode.A))
        {
            transform.Translate(Vector2.left * speed * Time.deltaTime);
        }

        if (Input.GetKey(KeyCode.D))
        {
            transform.Translate(Vector2.right * speed * Time.deltaTime);
        }

        if (Input.GetKeyDown(KeyCode.Space) && canAttack)
        {
            Check_Power();
            StartCoroutine(Cooldown_Attack());
        }

        MovementBoundries();
        
    }

    public void Change_Power(string _power, float timer)
    {
        power = _power;

        switch (power)
        {
            case "splitfire":
                rate_of_fire = 0.3f;
                break;
            case "threeway":
                rate_of_fire = 0.4f;
                break;
        }

        StartCoroutine(Reset_Power(timer));
    }

    private void Check_Power()
    {
        Vector3 lookDir = cam.ScreenToWorldPoint(Input.mousePosition) - _transform_gun.position;
        float zRot = Mathf.Atan2(lookDir.y, lookDir.x) * Mathf.Rad2Deg;

        switch (power)
        {
            case "splitfire":
                Instantiate(obj_bullet, _transform_gun.position, Quaternion.Euler(0, 0, zRot - 10));
                Instantiate(obj_bullet, _transform_gun.position, Quaternion.Euler(0, 0, zRot + 10));
                break;
            case "threeway":
                Instantiate(obj_bullet, _transform_gun.position, Quaternion.Euler(0, 0, zRot));
                Instantiate(obj_bullet, _transform_gun.position, Quaternion.Euler(0, 0, zRot - 25));
                Instantiate(obj_bullet, _transform_gun.position, Quaternion.Euler(0, 0, zRot + 25));
                break;
            default:
                Instantiate(obj_bullet, _transform_gun.position, Quaternion.Euler(0, 0, zRot));
                break;
        }
    }

    public void MovementBoundries()
    {
        if (transform.position.x < -xRange)
        {
            transform.position = new Vector2(-xRange, transform.position.y);
        }

        if(transform.position.x > xRange)
        {
            transform.position = new Vector2(xRange, transform.position.y);
        }
    }

    IEnumerator Cooldown_Attack()
    {
        canAttack = false;
        yield return new WaitForSeconds(rate_of_fire);
        canAttack = true;
    }

    IEnumerator Reset_Power(float timer)
    {
        yield return new WaitForSeconds(timer);
        power = "none";
        rate_of_fire = 0.1f;
    }

}
