using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{
    public float gameTime = 60f;
    public float timeLeft;
    public bool isTimeUp;
    public bool win;

    private void Start()
    {
        timeLeft = gameTime; // set initial time left
    }

    private void Update()
    {
        if (timeLeft > 0f)
        {
            timeLeft -= Time.deltaTime; // subtract time
        }
        else
        {
            timeLeft = 0f; // timer is up
            isTimeUp = true;
        }
    }
    //Detect when the player passes through the finish line
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            win = true;
        }
    }

}
