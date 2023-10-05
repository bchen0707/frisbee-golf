using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateHandle : MonoBehaviour
{
    private bool hasEnteredTriggerZone = false;
    
    public float rotationSpeed = 10f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("TriggerZone") && hasEnteredTriggerZone == false)
        {
            hasEnteredTriggerZone = true;
        }
    }

    // Update is called once per frame
    void Update()
    {
        transform.Rotate(Vector3.right * rotationSpeed, Space.Self);
    }

}
