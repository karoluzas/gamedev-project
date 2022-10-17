using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float moveSpeed;
    public Rigidbody2D rb;
    Vector2 movement;
    bool facingRight = true;

    void Start(){
        rb = GetComponent<Rigidbody2D>();
    }


    void FixedUpdate(){
        float movementHorizontal = Input.GetAxisRaw("Horizontal");
        float movementVertical = Input.GetAxisRaw("Vertical");

        movement = new Vector2(movementHorizontal, movementVertical).normalized;
        rb.velocity = movement * moveSpeed;

        if(movementHorizontal > 0 && !facingRight){
            Flip();
        }
        if(movementHorizontal < 0 && facingRight){
            Flip();
        }
    }

    void Flip(){
        Vector3 currentScale = gameObject.transform.localScale;
        currentScale.x *= -1;
        gameObject.transform.localScale = currentScale;
        facingRight = !facingRight;
    }

}
