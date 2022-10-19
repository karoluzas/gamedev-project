using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Slash : MonoBehaviour
{
    float slashLifetime = 0.3f; 

    void Start()
    {
        slashLifetime = 0.3f;
    }
    private void OnTriggerEnter2D(Collider2D other) {
        //Damage if(other.gameOjbect.tag == "enemy") here over the time (slashLifetime) it stays on screen
    }
    
    void Update()
    {
        if(slashLifetime > 0)
        {
            slashLifetime -= Time.deltaTime;
        }
        else
        {
            Destroy(gameObject);
        }
    }
}
