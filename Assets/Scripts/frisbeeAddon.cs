using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class frisbeeAddon : MonoBehaviour
{

    private Rigidbody rb;
    private bool goalHit;
    // Start is called before the first frame update
    
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

     void OnCollisionEnter(Collision collision)
    {
        Debug.Log("Target was Hit!");
        basicGoal goal = collision.gameObject.GetComponent<basicGoal>();
        goal.goalHitEvent();
        rb.isKinematic = true;
        transform.SetParent(collision.transform);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
