using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class basicGoal : MonoBehaviour
{
    [SerializeField] private AudioSource audioSource;
    [SerializeField] private string dialogue;
    [SerializeField] private ParticleSystem particleFX = null;
    
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
