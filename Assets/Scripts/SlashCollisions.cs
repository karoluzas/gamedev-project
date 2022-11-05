using UnityEngine;

public class SlashCollisions : MonoBehaviour
{
    float damageOnHit;
    float slashLifetime;

    public float DamageOnHit
    {
        set { damageOnHit = value; }
    }

    //GameObject enemy;
    //EnemyController enemyController;

    void Start()
    {
        damageOnHit = 5f;
        slashLifetime = 0.2f;
        //enemy = GameObject.Find("Enemy");
        //if (enemy)
        //    enemyController = enemy.GetComponent<EnemyController>();

    }
    private void OnTriggerEnter2D(Collider2D other) {
        //TODO - Damage if(other.gameOjbect.tag == "enemy") here over the time (slashLifetime) it stays on screen
        //if (collision.collider.CompareTag("Enemy") || collision.otherCollider.CompareTag("Enemy"))
        //{
        //    if (enemyController)
        //    {
        //        enemyController.DecreaseHealth(damageOnHit);
        //    }
        //}
        Destroy(gameObject);
    }
    
    void Update()
    {
        if(slashLifetime > 0)
        {
            slashLifetime -= Time.deltaTime;
        }
        else
        {
            Destroy(gameObject);
        }
    }
}
