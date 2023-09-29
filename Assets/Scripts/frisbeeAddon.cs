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

    // Update is called once per frame
    void Update()
    {
        
    }
}
