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
            if (SceneManager.GetActiveScene().name == "StartRoomThrow" || SceneManager.GetActiveScene().name == "StartRoom")
            {
                Debug.Log("invoke");
                Invoke(nameof(GoToCandyRoom), 3.0f);
            }
            if(SceneManager.GetActiveScene().name == "CandyRoomFinal")
            {
                Invoke(nameof(GoToCredits), 3.0f);
            }

        }
    }

    public void GoToCandyRoom()
    {
        sceneTM.GoToScene(1);
        Debug.Log("go candy");
    }

    public void GoToCredits()
    {
        sceneTM.GoToScene(2);
    }
}
