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
<<<<<<< Updated upstream
    
=======
    public GameObject[] musicCubes;
    public GameObject dialoguePic1;
    public GameObject dialoguePic2;
    public GameObject dialoguePic3;
    public GameObject dialoguePic4;


>>>>>>> Stashed changes
    public bool hit;

    public void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Disc") && (this.CompareTag("Panel")))
        {
            GameManager.Instance.panelHitCount += 1;
            goalHitEvent();
        }
    }

    public IEnumerable TriggerDialogue(GameObject go)
    {
        if (go != null) 
        {
            go.SetActive(true);
            yield return new WaitForSeconds(1f);
            go.SetActive(false);
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
        // switch out Panel prefab to Colored
        UncoloredPanel.SetActive(false);
        ColoredPanel.SetActive(true);

        // this.child."name".gameobject.setactive = true or smth LOL
        //DialogueManager.DisplayDialogue(dialogue); -> takes the string dialogue and pops it into the respective UI area
        //Destroy(gameObject);
<<<<<<< Updated upstream
=======

        
        if (musicCubes != null)
        {
            foreach (GameObject musicCube in musicCubes)
            {
                musicCube.active = true;
            }
        }

        //Dialogue Picture
        TriggerDialogue(dialoguePic1);
        TriggerDialogue(dialoguePic2);
        TriggerDialogue(dialoguePic3);
        TriggerDialogue(dialoguePic4);
        
>>>>>>> Stashed changes
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
