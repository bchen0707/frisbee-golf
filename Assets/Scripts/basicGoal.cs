using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class basicGoal : MonoBehaviour
{
    [SerializeField] private AudioSource audioSource;
    [SerializeField] private AudioSource hitSFX;
    [SerializeField] private GameObject dialogue;
    [SerializeField] private ParticleSystem particleFX;
    [SerializeField] private SpriteRenderer dialogueBubble;
    public GameObject UncoloredPanel;
    public GameObject ColoredPanel;
    public GameObject[] musicCubes;

    public float delayInSeconds = 8.0f;

    public bool hit;

    [SerializeField] private AudioClip panelVO;

    public void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Disc") && this.CompareTag("Panel"))
        {
            //GameManager.Instance.panelHitCount += 1;
            goalHitEvent();
            
        }
    }

    public void goalHitEvent()
    {
        // audio
        audioSource.Play();
        // hit sfx
        hitSFX.Play();
        // visual fx
        particleFX.Play();
        // dialogue
        dialogue.SetActive(true);
        StartCoroutine(DisableObjectAfterDelay());
        // switch out Panel prefab to Colored
        UncoloredPanel.SetActive(false);
        ColoredPanel.SetActive(true);
        //dialogue VO
        SoundManager.instance.PlayPanelVO(panelVO);

        this.GetComponent<BoxCollider>().enabled = false;
    }

    IEnumerator DisableObjectAfterDelay()
    {
        yield return new WaitForSeconds(delayInSeconds);

        // Disable the GameObject after the specified delay
        if (dialogue != null)
        {
            dialogue.SetActive(false);
        }
    }

}
