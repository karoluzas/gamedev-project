using UnityEngine;

public class CarryOverScene : MonoBehaviour
{
    void Awake(){
         GameObject[] objs = GameObject.FindGameObjectsWithTag("Player");
        if (objs.Length > 1)
        {
            Destroy(this.gameObject);
        }
        DontDestroyOnLoad(this.gameObject);
    }
}
