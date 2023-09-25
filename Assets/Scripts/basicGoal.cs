using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class basicGoal : MonoBehaviour
{
    public bool hit;

    public void goalHitEvent()
    {
        Debug.Log("yay goal!!!");
        Destroy(gameObject);
    }

    // Start is called before the first frame update
    void Start()
    {
        Debug.Log("yay goal");
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
