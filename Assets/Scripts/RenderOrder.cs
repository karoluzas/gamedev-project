using System.Linq;
using UnityEngine;

public class RenderOrder : MonoBehaviour
{
    private GameObject player;
    private string[] tags = new[] { "Upgrade Station", "Demon Altar", "Spaceship", "Rock", "Demon Egg" };
    private int biggerLayer;
    private int smallerLayer;

    private void Start()
    {
        player = GameObject.FindWithTag("Player");
        biggerLayer = gameObject.layer + 1;
        smallerLayer = gameObject.layer - 1;
    }

    private void Update()
    {
        if (tags.Contains(gameObject.tag))
        {
            Vector3 currentScale = gameObject.transform.localScale;
            Vector3 playerScale = player.transform.localScale;
            if (currentScale.y > playerScale.y)
            {
                gameObject.layer += 1;
            }
                
        }
    }
}
