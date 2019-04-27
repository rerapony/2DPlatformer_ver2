using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyEagle : MonoBehaviour
{
    public Transform firePoint;
    public GameObject bullet;
    public float timeMin;
    public float timeMax;

    public float timeBtwShots;
    private float startTimeBtwShots;
    private GameManagerScript gm;
    private bool facingRight = false;

    private void Start()
    {
        gm = GameObject.FindGameObjectWithTag("GameManager").GetComponent<GameManagerScript>();
        timeBtwShots = Random.Range(timeMin, timeMax);
    }

    void Update()
    {
        float startTimeBtwShots = Random.Range(timeMin, timeMax);

        if (timeBtwShots <= 0)
        {
            Shoot();
            timeBtwShots = startTimeBtwShots;
        }
        else
        {
            timeBtwShots -= Time.deltaTime;
        }
        if (gm.isKey == true && facingRight == false)
        {
            facingRight = true;
            Flip();
        }

    }

    void Shoot()
    {
        Instantiate(bullet, firePoint.position, firePoint.rotation);
    }

    void Flip()
    {
        Vector3 eagleVector = transform.localScale;
        eagleVector.x *= -1;
        transform.localScale = eagleVector;

        Vector3 fireVector = firePoint.localScale;
        fireVector.x *= -1;
        firePoint.localScale = fireVector;

        Quaternion fireRotation = firePoint.transform.rotation;
        firePoint.rotation = fireRotation * Quaternion.Euler(0, 180f, 0);
    }
}
