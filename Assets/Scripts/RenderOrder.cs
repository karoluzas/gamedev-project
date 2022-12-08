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
        smallerOrder = GetComponent<Renderer>().sortingOrder;
        biggerOrder = smallerOrder + 3;
    }

    private void Update()
    {
        if (tags.Contains(gameObject.tag))
        {
            float objectPositionOnYAxis = gameObject.transform.position.y;
            float playerPositionOnYAxis = player.transform.position.y;
            if (objectPositionOnYAxis > playerPositionOnYAxis)
            {
                GetComponent<Renderer>().sortingOrder = smallerOrder;
            }
            else
            {
                GetComponent<Renderer>().sortingOrder = biggerOrder;
            }
                
        }
    }
}
