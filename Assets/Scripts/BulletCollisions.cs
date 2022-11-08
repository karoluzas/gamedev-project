using UnityEngine;

//TODO - uncomment relevant places and update, when enemies are implemented
public class BulletCollisions : MonoBehaviour
{
    private float damageOnHit = 5f;
    private float bulletRange = 1f;
    private Vector3 lastPosition;

    public float DamageOnHit { set => damageOnHit = value; }
    public float BulletRange { set => bulletRange = value; }

    //GameObject enemy;
    //EnemyController enemyController;

    private void Start()
    {
        //enemy = GameObject.Find("Enemy");
        //if (enemy)
        //    enemyController = enemy.GetComponent<EnemyController>();
    }

    private void OnCollisionEnter2D(Collision2D collision)
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

    private void Awake()
    {
        lastPosition = transform.position;
    }

    private void Update()
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
