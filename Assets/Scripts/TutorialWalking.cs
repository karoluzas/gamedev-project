using UnityEngine;

public class TutorialWalking : MonoBehaviour
{   
    public GameObject combatText;
    public GameObject tutorialEnemy;
    public GameObject gatheringText;
    public GameObject tutorialRock;
    public GameObject craftingText;
    public GameObject tutorialStation;
    public GameObject tutorialSpaceship;
    private bool afterFirstRoom = false;
    private bool afterSecondRoom = false;
    private bool afterThirdRoom = false;


    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.tag == "Player")
        {
            var walkingText = GameObject.Find("WalkingText");
            Destroy(walkingText);
            
            combatText.SetActive(true);
            tutorialEnemy.SetActive(true);

            afterFirstRoom = true;
        }
    }

    private void Update()
    {
        if(afterFirstRoom && GameObject.Find("Mammon") == null && !afterSecondRoom)
        {
            Destroy(combatText);

            gatheringText.SetActive(true);
            tutorialRock.SetActive(true);

            afterSecondRoom = true;
        }
        if(afterSecondRoom && GameObject.FindWithTag("Rock") == null && !afterThirdRoom)
        {
            Destroy(gatheringText);

            tutorialStation.SetActive(true);
            tutorialSpaceship.SetActive(true);

            afterThirdRoom = true;
        }
    }
}
