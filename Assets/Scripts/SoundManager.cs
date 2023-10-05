using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    public static SoundManager Instance;

    public AudioSource musicSource;
    public AudioSource VOSource;
    void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame  
    void Update()
    {
        
    }

    public void PlayPanelVO(AudioClip panelVO)
    {
        VOSource.clip = panelVO;
        VOSource.Play();
    }

    public void StopVO()
    {
        Debug.Log("stop vo");
        VOSource.Stop();
    }
    public static class FadeAudioSource {
        public static IEnumerator StartFade(AudioSource audioSource, float duration, float targetVolume)
        {
            float currentTime = 0;
            float start = audioSource.volume;
            while (currentTime < duration)
            {
                currentTime += Time.deltaTime;
                audioSource.volume = Mathf.Lerp(start, targetVolume, currentTime / duration);
                yield return null;
            }
            yield break;
        }
    }
    public void FadeSounds()
    {
        StartCoroutine(FadeAudioSource.StartFade(musicSource, 3.5f,  0));
    }
}
