using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    void OnCollisionEnter2D(Collision2D collision)
    {
        //Damage enemy here once
        Destroy(gameObject);
         Debug.Log("hits");
    }
}
