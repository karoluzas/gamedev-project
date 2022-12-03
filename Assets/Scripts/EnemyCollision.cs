using System.Collections;
using UnityEngine;

public class EnemyCollision : MonoBehaviour
{
    public float damageOnHit = 1f;
    public float hitCooldown = 0.1f;

    private float timeLeft;
    private bool canDamage;

    private GameObject player;
    private HealthController healthController;
    private SpriteRenderer sprite;

    private void Start()
    {
        player = GameObject.Find("Player");
        if (player){
            healthController = player.GetComponent<HealthController>();
            sprite = player.GetComponent<SpriteRenderer>();
        }
    }

    private void OnCollisionStay2D(Collision2D collision)
    {
        if (collision.collider.CompareTag("Player"))
        {
            if (healthController)
            {
                if (canDamage)
                {
                    healthController.DecreaseHealth(damageOnHit);
                    StartCoroutine(FlashRed());
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

    public IEnumerator FlashRed(){
        sprite.color = Color.red;
        yield return new WaitForSeconds(0.5f);
        sprite.color = Color.white;
    }
}
