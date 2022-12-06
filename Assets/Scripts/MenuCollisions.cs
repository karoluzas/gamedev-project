using UnityEngine;

public class MenuCollisions : MonoBehaviour
{
    public bool IsMenuAvailable { get; private set; } = false;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            IsMenuAvailable = true;
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            IsMenuAvailable = false;
        }
    }
}

