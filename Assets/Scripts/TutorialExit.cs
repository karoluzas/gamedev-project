using UnityEngine;

public class TutorialExit : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            //TODO: exit to main menu
        }
    }
}
