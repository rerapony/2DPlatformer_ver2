using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySlug : MonoBehaviour
{
    private float targetX;
    public Transform leftSpot;
    public Transform rightSpot;
    public float speed;

    private float distanceRight;
    private float distanceLeft;
    

    private void Start()
    {
        targetX = leftSpot.position.x;
    }

    void Update()
    {
        distanceRight = Vector2.Distance(transform.position, rightSpot.position);
        distanceLeft = Vector2.Distance(transform.position, leftSpot.position);

        if (distanceRight < .5f)
        {
            targetX = leftSpot.position.x;
            Flip();
        }
        else if (distanceLeft < .5f)
        {
            targetX = rightSpot.position.x;
            Flip();
        }

        transform.position = Vector2.MoveTowards(transform.position, new Vector3(targetX, transform.position.y), speed * Time.deltaTime);
        
    }

    void Flip()
    {
        Vector3 Scaler = transform.localScale;
        Scaler.x *= -1;
        transform.localScale = Scaler;
    }

}
