using UnityEngine;

public class EnemyBulletCollision : MonoBehaviour
{
    public float damageOnHit = 5f;

    private GameObject player;
    private PlayerController playerController;

    private void Start()
    {
        player = GameObject.Find("Player");
        if (player)
            playerController = player.GetComponent<PlayerController>();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.CompareTag("Player") || collision.otherCollider.CompareTag("Player"))
        {
            if (playerController)
            {
                playerController.DecreaseHealth(damageOnHit);
            }
        }
        Destroy(gameObject);
    }

}
