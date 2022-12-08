using System.Collections;
using UnityEngine;

public class HealthController : MonoBehaviour
{
    public float health = 0f;
    public float flashDuration = 0.1f;
    public GameObject enemyDeathSound;
    public GameObject playerDeathSound;
    public GameObject playerHurtSound;
    public GameObject rockBreakSound;
    private SpriteRenderer sprite;
    private InventoryController inventoryController;
    private HealthUIManager _healthUIManager;

    private void Start()
    {
        sprite = gameObject.GetComponent<SpriteRenderer>();
        var player = GameObject.Find("Player");
        if (player)
        {
            inventoryController = player.GetComponent<InventoryController>();
        }
            
    }

    private void Update()
    {
        if (_healthUIManager == null)
            _healthUIManager = GameObject.Find("HealthParent").GetComponent<HealthUIManager>();
    }

    public void DecreaseHealth(float amount)
    {
        if (health > 0)
        {
            health -= amount;
            if (gameObject.tag == "Player" || gameObject.tag == "Enemy_Sathanas")
            {
                if (flashDuration > 0f)
                    StartCoroutine(FlashRed());
            }
            if(gameObject.tag == "Player")
            {
                if (playerHurtSound)
                    Instantiate(playerHurtSound);

                _healthUIManager.UpdateHealth((int)health >= 0 ? (int)health : 0);
            }
            //Hurt Animation/Particles?
        }
        else
        {
            if(gameObject.tag == "Enemy_Sathanas")
            {
                if (enemyDeathSound)
                    Instantiate(enemyDeathSound);
                inventoryController.AddDemonBlood(Random.Range(1, 5));
            }
            if(gameObject.tag == "Player")
            {
                if (playerDeathSound)
                    Instantiate(playerDeathSound);
            }
            if(gameObject.tag == "Rock")
            {
                if (rockBreakSound)
                    Instantiate(rockBreakSound);
                inventoryController.AddRocks(Random.Range(1, 10), Random.Range(0, 2), Random.Range(0, 4));
            }
            if (gameObject.tag == "Demon Egg")
            {
                if (rockBreakSound)
                    Instantiate(rockBreakSound);
                inventoryController.AddBushes(Random.Range(1, 10), Random.Range(0, 2), Random.Range(0, 4));
            }
            if (gameObject.tag == "Demon Altar")
            {
                if (rockBreakSound)
                    Instantiate(rockBreakSound);
                inventoryController.AddAltairs(Random.Range(1, 10), Random.Range(0, 2), Random.Range(0, 4));
            }
            Destroy(gameObject, 0.1f);
        }
    }

    private IEnumerator FlashRed()
    {
        sprite.color = Color.red;
        yield return new WaitForSeconds(flashDuration);
        sprite.color = Color.white;
    }
}
