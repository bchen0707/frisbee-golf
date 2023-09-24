using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class recorderSpin : MonoBehaviour
{
    public float rotateSpeed = 10f;
    public float offset = 1f;
    private bool hasEnteredTriggerZone = false;
    //private bool hasCollided = false;
    private Transform cubeTransform;
    private Vector3 newLocation;
    // Start is called before the first frame update
    void Start()
    {
        cubeTransform = GameObject.FindGameObjectWithTag("Cube").transform;
        newLocation = new Vector3(cubeTransform.position.x, offset, cubeTransform.position.y);
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("TriggerZone") && hasEnteredTriggerZone == false)
        {
            Debug.Log("TriggerZoneDetected");
            hasEnteredTriggerZone = true;
        }
    }

    void Update()
    {
        if(hasEnteredTriggerZone)
        {
            Debug.Log("yay");
            //update location
            transform.position = newLocation;
            //disable gravity
            GameObject.FindGameObjectWithTag("Cube").GetComponent<Rigidbody>().useGravity = false;
            //rotate disk
            transform.Rotate(0f, rotateSpeed * Time.deltaTime, 0f, Space.Self);
        }
    }
}
