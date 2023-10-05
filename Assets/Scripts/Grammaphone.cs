using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Grammaphone : MonoBehaviour
{
    public SceneTransitionManager sceneTM;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Disc"))
        {
            if (SceneManager.GetActiveScene().name == "StartRoom")
            {
                Debug.Log("transition to candyroom");
                sceneTM.GoToScene(1);
            }
            if(SceneManager.GetActiveScene().name == "CandyRoomFinal")
            {
                sceneTM.GoToScene(2);
            }

        }
    }
}
