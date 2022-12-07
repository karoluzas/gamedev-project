using UnityEngine;

public class SlashCollisions : MonoBehaviour
{
    private float damageOnHit = 5f;
    private float slashLifetime = 0.15f;

    [SerializeField]
    private Transform damagePopupPrefab;
    public float DamageOnHit
    {
        set { damageOnHit = value; }
    }

    public float SlashLifetime
    {
        get { return slashLifetime; }
        set { slashLifetime = value; }
    }

    private void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.tag == "Enemy_Sathanas")
        {
            GameObject enemy = collider.gameObject;
            if (enemy)
            {
                Transform damagePopupTransform = Instantiate(damagePopupPrefab, new Vector3(transform.position.x + 0.25f, transform.position.y + Random.Range(-0.1f, 0.1f), 0), Quaternion.identity);
                print(transform.position.x + " " + transform.position.y);
                DamagePopupScript damagePopup = damagePopupTransform.GetComponent<DamagePopupScript>();
                damagePopup.Setup(damageOnHit);
                var healthController = enemy.GetComponent<HealthController>();
                healthController.DecreaseHealth(damageOnHit);
            }
        }

        if(collider.tag == "Rock" || collider.tag == "Demon Altar" || collider.tag == "Demon Egg")
        {
            GameObject gatherable = collider.gameObject;
            if (gatherable)
            {
                var healthController = gatherable.GetComponent<HealthController>();
                healthController.DecreaseHealth(damageOnHit);
            }
        }
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
