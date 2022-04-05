using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraScript : MonoBehaviour
{
    public GameObject player;


    // Simple camera script that follows the player with added float values on top
    void Update()
    {
        transform.position = new Vector3(player.transform.position.x, player.transform.position.y + 7.36f, player.transform.position.z - 6.5f);
    }
}
