using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyCollision : MonoBehaviour
{
    public float damageOnHit = 1f;
    public float hitCooldown = 0.1f;

    float timeLeft;
    bool canDamage;

    GameObject player;
    PlayerController playerController;

    private void Start()
    {
        player = GameObject.Find("Player");
        if(player)
            playerController = player.GetComponent<PlayerController>();
    }

    private void OnCollisionStay2D(Collision2D collision)
    {
        if(collision.collider.CompareTag("Player"))
        { 
            if(playerController)
            {
                if (canDamage)
                {
                    playerController.DecreaseHealth(damageOnHit);
                    canDamage = false;
                }
            }
        }
    }

    private void Update()
    {
        if (timeLeft < 0f)
        {
            canDamage = true;
            timeLeft = hitCooldown;
        }
        else
        {
            timeLeft -= Time.deltaTime;
        }
    }
}
