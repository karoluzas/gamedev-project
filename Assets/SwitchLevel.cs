using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SwitchLevel : MonoBehaviour
{
    public int sceneBuildIndex;
    public Animator transition;
    public float transitionTime;
    private void OnTriggerEnter2D(Collider2D other){
        if(other.tag == "Player"){
            StartCoroutine(LoadLevel(sceneBuildIndex));
        }
    }

    IEnumerator LoadLevel(int levelIndex){
        transition.SetTrigger("Start");
        yield return new WaitForSeconds(1);
        SceneManager.LoadScene(sceneBuildIndex, LoadSceneMode.Single);            
    }
}
