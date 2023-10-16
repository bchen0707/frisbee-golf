using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    public static SoundManager instance;
    public AudioSource musicSource;

    public AudioSource VOSource;

    private void Awake()
    {
        instance = this;
    }

    public void PlayPanelVO(AudioClip panelVO)
    {
        VOSource.Stop();
        VOSource.clip = panelVO;
        VOSource.Play();
    }
}
