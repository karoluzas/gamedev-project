using UnityEngine;

//TODO - uncomment relevant places and update, when enemies are implemented
public class BulletCollisions : MonoBehaviour
{
    public float damageOnHit = 5f;
    public float bulletRange = 1f;
    Vector3 lastPosition;

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

    void Awake()
    {
        lastPosition = transform.position;
    }

    void Update()
    {
        if (bulletRange > 0)
        {
            float traveledRange = Vector3.Distance(transform.position, lastPosition);
            bulletRange -= traveledRange;
            lastPosition = transform.position;
        }

        if (bulletRange <= 0) {
            Destroy(gameObject);
        }
    }
}
