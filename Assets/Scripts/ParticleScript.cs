using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParticleScript : MonoBehaviour
{
    // private void OnCollisionEnter2D(Collision2D collision){
    //     Debug.Log(collision.collider.tag);
    //     GetComponent<ParticleSystem>().Play();
    //     //GetComponent<SpriteRenderer>().enabled = false;
    // }

    public void OnTriggerEnter2D(Collider2D collider){
        if(collider.tag == "Slash"){
            print("DAUZOM");
            GetComponent<ParticleSystem>().Play();
        }
    }
}
