using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicController : MonoBehaviour
{
    public IEnumerator StartFade(float duration, float targetVolume)
    {
        float currentTime = 0;
        AudioSource audioSrc = this.gameObject.GetComponent<AudioSource>();
        if(audioSrc)
        {
            float start = audioSrc.volume;
            while (currentTime < duration)
            {
                currentTime += Time.deltaTime;
                audioSrc.volume = Mathf.Lerp(start, targetVolume, currentTime / duration);
                yield return null;
            }
            yield break;
        }    
    }
}
