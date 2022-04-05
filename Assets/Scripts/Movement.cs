using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{

    // Set in Editor
    public float speed = 20.0f;
    public float jumpSpeed = 1500.0f;
    public float gravity = 2.0f;

    //Player distance to floor
    public float toFloor = 1.1f;

    //Raycast for touching floor
    public RaycastHit floorCast;

    // Direction player moves
    private Vector3 moveDirection = Vector3.zero;

    // These will be set to Unity's Input system
    private float xMove;
    private float yMove;
    private bool jump;

    private void FixedUpdate()
    {
        //Floor ray cast
        Ray floorRay = new Ray(transform.position, Vector3.down);

        // Apply gravity + Movement
        moveDirection = new Vector3(xMove * speed, gameObject.GetComponent<Rigidbody>().velocity.y - gravity, yMove * speed);

        //Allows player to jump if raycast is touching ground
        if (Physics.Raycast(floorRay, out floorCast, toFloor))
        { 
           if (jump)
            {
                GetComponent<Rigidbody>().AddForce(Vector3.up * jumpSpeed);
            }
        }
        gameObject.GetComponent<Rigidbody>().velocity = moveDirection;
    }

    //Update move and jump to unity Input which is WASD + Space
    void Update()
    {
        xMove = Input.GetAxis("Horizontal");
        yMove = Input.GetAxis("Vertical");
        jump = Input.GetButton("Jump");
    }
}
