using UnityEngine;

public class EnemyCollision : MonoBehaviour
{
    public float damageOnHit = 1f;
    public float hitCooldown = 0.1f;

    private float timeLeft;
    private bool canDamage;

    private GameObject player;
    private HealthController healthController;

    private void Start()
    {
        player = GameObject.Find("Player");
        if (player)
            healthController = player.GetComponent<HealthController>();
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
