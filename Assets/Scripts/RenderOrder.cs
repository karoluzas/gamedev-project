using System.Linq;
using UnityEngine;

public class RenderOrder : MonoBehaviour
{
    private GameObject player;
    private int biggerOrder;
    private int smallerOrder;
    private string[] tags = new[] { "Upgrade Station", "Demon Altar", "Spaceship", "Rock", "Demon Egg" };

    private void Start()
    {
        player = GameObject.FindWithTag("Player");
        biggerOrder = GetComponent<Renderer>().sortingOrder + 1;
        smallerOrder = GetComponent<Renderer>().sortingOrder - 1;
    }

    private void Update()
    {
        if (tags.Contains(gameObject.tag))
        {
            Vector3 currentScale = gameObject.transform.localScale;
            Vector3 playerScale = player.transform.localScale;
            if (currentScale.y > playerScale.y)
            {
                GetComponent<Renderer>().sortingOrder = biggerOrder;
            }
            else
            {
                GetComponent<Renderer>().sortingOrder = smallerOrder;
            }
                
        }
    }
}
