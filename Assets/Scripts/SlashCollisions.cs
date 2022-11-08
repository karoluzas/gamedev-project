using UnityEngine;

public class SlashCollisions : MonoBehaviour
{
    private float damageOnHit = 5f;
    private float slashLifetime = 0.2f;

    public float DamageOnHit
    {
        set { damageOnHit = value; }
    }

    public float SlashLifetime
    {
        get { return slashLifetime; }
        set { slashLifetime = value; }
    }

    //GameObject enemy;
    //EnemyController enemyController;

    private void Start()
    {
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

    private void Update()
    {
        if (slashLifetime > 0)
        {
            slashLifetime -= Time.deltaTime;
        }
        else
        {
            Destroy(gameObject);
        }
    }
}
