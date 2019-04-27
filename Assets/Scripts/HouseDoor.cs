using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HouseDoor : MonoBehaviour
{

    private GameManagerScript gm;

    public Animator animator;
    private GameObject player;
    private PlayerController pc;
    public bool isOpen = false;

    void Start()
    {
        gm = GameObject.FindGameObjectWithTag("GameManager").GetComponent<GameManagerScript>();
        //animator = GetComponent<Animator>();
    }

    void Update()
    {
        player = GameObject.Find("Player");
        pc = player.GetComponent<PlayerController>();
        GetComponent<Animator>().SetBool("open", isOpen);
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        Debug.Log("COLLISION");
        if (other.CompareTag("Player"))
        {
            if (gm.isKey == true)
            {
                isOpen = true;
                gm.GameComplited();
            }
        }
    }
 }
