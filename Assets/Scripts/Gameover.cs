using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Gameover : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(timer());
    }

    private IEnumerator timer()
    {
        yield return new WaitForSeconds(3);
        UnityEngine.SceneManagement.SceneManager.LoadScene(0, LoadSceneMode.Single);

    }
}
