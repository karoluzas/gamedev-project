using UnityEngine;

//TODO - uncomment relevant places and update, when enemies are implemented
public class BulletCollisions : MonoBehaviour
{
    private float damageOnHit = 5f;
    private float bulletRange = 1f;
    private Vector3 lastPosition;

    public float DamageOnHit { set => damageOnHit = value; }
    public float BulletRange { set => bulletRange = value; }

    public GameObject hitSound;
    [SerializeField]
    private Transform damagePopupPrefab;

    private void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.tag == "Enemy_Sathanas")
        {
            Transform damagePopupTransform = Instantiate(damagePopupPrefab, new Vector3(transform.position.x + 0.25f, transform.position.y + Random.Range(-0.1f, 0.1f), 0), Quaternion.identity);
            print(transform.position.x + " " + transform.position.y);
            DamagePopupScript damagePopup = damagePopupTransform.GetComponent<DamagePopupScript>();
            damagePopup.Setup(damageOnHit);

            Instantiate(hitSound);
            Destroy(gameObject);
            GameObject enemy = collider.gameObject;
            if (enemy)
            {
                var healthController = enemy.GetComponent<HealthController>();
                healthController.DecreaseHealth(damageOnHit);
            }
        }
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

        if (bulletRange <= 0)
        {
            Destroy(gameObject);
        }
    }
}
