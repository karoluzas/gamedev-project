using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Flashing : MonoBehaviour
{
    [SerializeField]
    private SpriteRenderer sprite;
    [SerializeField]
    private float duration = 0.1f;


    public void OnTriggerEnter2D(Collider2D collider){
        if(collider.tag == "Bullet" || collider.tag == "Slash"){
            StartCoroutine(FlashRed());
        }
    }

    public IEnumerator FlashRed(){
        sprite.color = Color.red;
        yield return new WaitForSeconds(duration);
        sprite.color = Color.white;
    }
}
