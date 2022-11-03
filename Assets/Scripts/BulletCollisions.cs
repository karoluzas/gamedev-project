using UnityEngine;

//TODO - uncomment relevant places and update, when enemies are implemented
public class BulletCollisions : MonoBehaviour
{
    public float damageOnHit = 5f;
    public float bulletRange = 0.2f; //TODO - change this to range

    //GameObject enemy;
    //EnemyController enemyController;

    //void Start()
    //{
    //    enemy = GameObject.Find("Enemy");
    //    if (enemy)
    //        enemyController = enemy.GetComponent<EnemyController>();
    //}

    void OnCollisionEnter2D(Collision2D collision)
    {
        //TODO - Damage enemy here once
        if(collision.gameObject.tag == "Player"){
            return;
        }
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
        if (bulletRange > 0)
        {
            bulletRange -= Time.deltaTime;
        }
        else
        {
            Destroy(gameObject);
        }
    }
}
