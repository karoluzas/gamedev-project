using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParticleScript : MonoBehaviour
{
    public void OnTriggerEnter2D(Collider2D collider)
    {
        if(collider.tag == "Slash"){
            GetComponent<ParticleSystem>().Play();
        }
    }
}
