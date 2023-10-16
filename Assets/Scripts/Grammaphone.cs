using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Grammaphone : MonoBehaviour
{
    public SceneTransitionManager sceneTM;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Disc"))
        {
            if (SceneManager.GetActiveScene().name == "StartRoomThrow" || SceneManager.GetActiveScene().name == "StartRoom")
            {
                Debug.Log("invoke");
                Invoke(nameof(GoToCandyRoom), 3.5f);
            }
            if(SceneManager.GetActiveScene().name == "CandyRoomFinal")
            {
                Invoke(nameof(GoToCredits), 4.0f);
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
