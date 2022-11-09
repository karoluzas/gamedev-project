using UnityEngine;

public class SlashCollisions : MonoBehaviour
{
    private float damageOnHit = 5f;
    private float slashLifetime = 0.15f;

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
    private void OnTriggerEnter2D(Collider2D collider) {
        //TODO - Damage if(other.gameOjbect.tag == "enemy") here over the time (slashLifetime) it stays on screen
        //check for only one damage event
        if (collider.tag == "Enemy"){
            
        }
        //{
        //    if (enemyController)
        //    {
        //        enemyController.DecreaseHealth(damageOnHit);
        //    }
        //}
        //Destroy(gameObject);
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
