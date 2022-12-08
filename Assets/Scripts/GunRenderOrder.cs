using UnityEngine;

public class GunRenderOrder : MonoBehaviour
{
    private GameObject player;

    private void Start()
    {
        player = GameObject.FindWithTag("Player");
    }

    private void Update()
    {
        GetComponent<Renderer>().sortingOrder = player.GetComponent<Renderer>().sortingOrder + 1;
    }
}
