using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

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
    private GameObject healthGUI;

    private void Start()
    {
        sprite = gameObject.GetComponent<SpriteRenderer>();
        var player = GameObject.Find("Player");
        if (player)
            inventoryController = player.GetComponent<InventoryController>();
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
            }
            //Hurt Animation/Particles?
        }
        else
        {
            if(gameObject.tag == "Enemy_Sathanas")
            {
                if (enemyDeathSound)
                    Instantiate(enemyDeathSound);
                inventoryController.AddDemonBlood(Random.Range(4, 5));
            }
            if(gameObject.tag == "Player")
            {
                if (playerDeathSound)
                    Instantiate(playerDeathSound);
                EndGame();
                return;
            }
            if(gameObject.tag == "Rock")
            {
                if (rockBreakSound)
                    Instantiate(rockBreakSound);
                inventoryController.AddRocks(Random.Range(5, 10), Random.Range(2, 5), Random.Range(2, 4));
            }
            if (gameObject.tag == "Demon Egg")
            {
                if (rockBreakSound)
                    Instantiate(rockBreakSound);
                inventoryController.AddBushes(Random.Range(5, 10), Random.Range(2, 5), Random.Range(2, 4));
            }
            if (gameObject.tag == "Demon Altar")
            {
                if (rockBreakSound)
                    Instantiate(rockBreakSound);
                inventoryController.AddAltairs(Random.Range(5, 10), Random.Range(2, 5), Random.Range(2, 4));
            }
            Destroy(gameObject, 0.1f);
 
        }
    }

    private void EndGame(){
        Destroy(gameObject);
        UnityEngine.SceneManagement.SceneManager.LoadScene(7, LoadSceneMode.Single);
        CarryOverScene.Reset();
    }

    private IEnumerator FlashRed()
    {
        sprite.color = Color.red;
        yield return new WaitForSeconds(flashDuration);
        sprite.color = Color.white;
    }
}
