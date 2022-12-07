using System.Linq;
using UnityEngine;

public class RenderOrder : MonoBehaviour
{
    private GameObject player;
    private string[] tags = new[] { "Upgrade Station", "Demon Altar", "Spaceship", "Rock", "Demon Egg" };

    private void Start()
    {
        player = GameObject.FindWithTag("Player");
    }

    private void Update()
    {
        if (tags.Contains(gameObject.tag))
        {

        }
    }
}
