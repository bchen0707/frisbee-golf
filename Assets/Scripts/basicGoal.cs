using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class basicGoal : MonoBehaviour
{
    [SerializeField] private AudioSource audioSource;
    [SerializeField] private string dialogue;
    [SerializeField] private ParticleSystem particleFX;
    [SerializeField] private SpriteRenderer dialogueBubble;
    public GameObject UncoloredPanel;
    public GameObject ColoredPanel;
    public AudioClip panelVO;
    public bool hit;
    
    public void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Disc"))
        {
            goalHitEvent();
        }
    }

    public void goalHitEvent()
    {
        // audio
        
        audioSource.Play();
        // visual fx
        
        particleFX.Play();
        // dialogue
        
        Debug.Log("dialogue");
        // VO
        if (SoundManager.Instance.VOSource.isPlaying)
        {
            SoundManager.Instance.VOSource.Stop();
        }
        SoundManager.Instance.StopVO();
        SoundManager.Instance.VOSource.clip = (panelVO);
        
        SoundManager.Instance.VOSource.Play();
        // switch out Panel prefab to Colored
        UncoloredPanel.SetActive(false);
        ColoredPanel.SetActive(true);
        this.GetComponent<Collider>().enabled = false;
        
        // this.child."name".gameobject.setactive = true or smth LOL
        //DialogueManager.DisplayDialogue(dialogue); -> takes the string dialogue and pops it into the respective UI area
        //Destroy(gameObject);
    }
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
