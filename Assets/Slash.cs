using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Slash : MonoBehaviour
{
    float slashLifetime = 0.3f;
    float timeLeft;

    void Start()
    {
        timeLeft = slashLifetime;

    }

    //bool slashExists = false;
    void OnCollisionEnter2D(Collision2D collision)
    {
        //Damage here over time (slashLifetime) it stays on screen
    }

    void Update()
    {
        if(timeLeft > 0)
        {
            timeLeft -= Time.deltaTime;
        }
        else
        {
            Destroy(gameObject);
        }
    }
}
