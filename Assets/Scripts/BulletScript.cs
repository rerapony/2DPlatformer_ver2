using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletScript : MonoBehaviour
{
    public float speed = 5f;
    private Rigidbody2D rb;
    private GameManagerScript gm;
    private PlayerController player;
    // Update is called once per frame
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        rb.velocity = -transform.right * speed;
        gm = GameObject.FindGameObjectWithTag("GameManager").GetComponent<GameManagerScript>();
        player = GameObject.Find("Player").GetComponent<PlayerController>();
 
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            rb.velocity = Vector3.zero;
            rb.constraints = RigidbodyConstraints2D.FreezeAll;
            player.Die();
            Destroy(gameObject);
        }
        else if (other.CompareTag("Coin")) { }
        else
        {
            Destroy(gameObject);
        }
    }
}
