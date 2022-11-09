using UnityEngine;

public class EnemyBulletCollision : MonoBehaviour
{
    public float damageOnHit = 5f;

    private GameObject player;
    private HealthController healthController;

    private void Start()
    {
        player = GameObject.Find("Player");
        if (player)
            healthController = player.GetComponent<HealthController>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            if (healthController)
            {
                healthController.DecreaseHealth(damageOnHit);
            }
        }
        Destroy(gameObject);
    }

}
