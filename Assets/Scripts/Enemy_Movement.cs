using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_Movement : MonoBehaviour
{
    //Determines how often enemy switches directions
    public float swapFrequency;

    //Enemy speed 
    public int EnemySpeed;

    //Which way the enemy is facing 
    public int XMoveDirection;

    //The enemy will Instantiate this game object 
    public GameObject EnemyBit;

    void Start()
    { 
        StartCoroutine(switchDirectionRecursive());
    }


    void Update()
    {
        gameObject.GetComponent<Rigidbody>().velocity = new Vector3(XMoveDirection, 0, 0) * EnemySpeed;
    }
    IEnumerator switchDirectionRecursive()
    {
        //After an amount of seconds have passed, switch move directions
        yield return new WaitForSeconds(swapFrequency);
        Flip();
        StartCoroutine(switchDirectionRecursive());
    }

    //This code switches the current movement direction
    void Flip()
    {
        if (XMoveDirection > 0)
        {
            XMoveDirection = -1;
        }
        else { XMoveDirection = 1; }
    }

    //When colliding with the player, it will destroy the object
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.name == "Capsule")
        {
            Destroyed();
            gameObject.SetActive(false);
        }
    }

    void Destroyed()
    {
        //The enemy will explode into 40 pieces
        for (int i = 0; i < 40; i++) { 
        Instantiate(EnemyBit, transform.position, Quaternion.identity);
        }
    }

}
