using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Grammaphone : MonoBehaviour
{
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
            Debug.Log("disc hit");
            if (SceneManager.GetActiveScene().name == "StartRoom")
            {
                Debug.Log("transition to candyroom");
                CanvasManager.Instance.TransitionToScene(1);
            }
            if(SceneManager.GetActiveScene().name == "CandyRoomFinal")
            {
                CanvasManager.Instance.TransitionToScene(2);
            }

        }
    }
}
