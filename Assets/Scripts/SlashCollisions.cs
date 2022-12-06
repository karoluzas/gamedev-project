using UnityEngine;

public class SlashCollisions : MonoBehaviour
{
    private float damageOnHit = 5f;
    private float slashLifetime = 0.15f;
    private InventoryController inventoryController;
    private GameObject player;
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

    private void Start()
    {
        player = GameObject.Find("Player");
        if (player)
            inventoryController = player.GetComponent<InventoryController>();
    }

    private void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.tag == "Enemy_Sathanas")
        {
            //Destroy(gameObject);
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
        if(collider.tag == "Rock"){
            GameObject rock = collider.gameObject;
            if(rock){
                var healthController = rock.GetComponent<HealthController>();
                healthController.DecreaseHealth(damageOnHit);
            }

            inventoryController.AddRocks(Random.Range(1,10), Random.Range(0,2), Random.Range(0,4));
        }
        if(collider.tag == "Demon Altar"){
            GameObject demonAltar = collider.gameObject;
            if(demonAltar){
                var healthController = demonAltar.GetComponent<HealthController>();
                healthController.DecreaseHealth(damageOnHit);
            }

            inventoryController.AddAltairs(Random.Range(1,10), Random.Range(0,2), Random.Range(0,4));
        }
        if(collider.tag == "Demon Egg"){
            GameObject demonEgg = collider.gameObject;
            if(demonEgg){
                var healthController = demonEgg.GetComponent<HealthController>();
                healthController.DecreaseHealth(damageOnHit);
            }

            inventoryController.AddBushes(Random.Range(1,10), Random.Range(0,2), Random.Range(0,4));
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
