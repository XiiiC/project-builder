using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LavaController : MonoBehaviour
{
    public bool playerDead = false;

    //If the player collides with tag lava it will destroy the player
    private void OnTriggerEnter(Collider other)
    {
        playerDead = true;
    }
}
