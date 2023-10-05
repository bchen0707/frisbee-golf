using System.Collections;
using System.Collections.Generic;
using Unity.XR.CoreUtils;
using UnityEngine;

public class recorderSpin : MonoBehaviour
{
    public float rotateSpeed = 10f;
    public float handleSpeed = 2f;
    public float offset = 1f;
    private bool hasEnteredTriggerZone = false;
    private Transform cubeTransform;
    private Vector3 newLocation;
    private Quaternion desiredOrientation;
    private bool hasReachedDesiredOrientation;

    [SerializeField] private GameObject grammaphone;
    [SerializeField] private GameObject handle;
    private float rotationSmoothing = 2f; // Adjust this value for smoother or faster rotation

    // Start is called before the first frame update
    void Start()
    {
        cubeTransform = grammaphone.transform;
        newLocation = new Vector3(cubeTransform.position.x, cubeTransform.position.y + offset, cubeTransform.position.z);
        Debug.Log("new location: " + newLocation);
        // Set the desired Euler angles in degrees.
        Vector3 desiredRotationEulerAngles = new Vector3(-89.5f, -69.56f, 71.86f);

        // Create a Quaternion from the desired Euler angles.
        desiredOrientation = Quaternion.Euler(desiredRotationEulerAngles);

    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("TriggerZone") && hasEnteredTriggerZone == false)
        {
            hasEnteredTriggerZone = true;
        }
    }

    void Update()
    {
        if(hasEnteredTriggerZone)
        {
            //update location
            transform.position = newLocation;
            newLocation = new Vector3(cubeTransform.position.x, cubeTransform.position.y + offset, cubeTransform.position.z);
            //disable gravity
            GameObject.FindGameObjectWithTag("Disc").GetComponent<Rigidbody>().useGravity = false;

            if (!hasReachedDesiredOrientation)
            {
                // Rotate disc towards the target rotation smoothly
                transform.rotation = Quaternion.Slerp(transform.rotation, desiredOrientation, Time.deltaTime * rotationSmoothing);

                if(Quaternion.Angle(transform.rotation, desiredOrientation) < 0.1f)
                {
                    hasReachedDesiredOrientation = true;
                }

            }
            else
            {
                // Calculate the angular velocity to keep rotating around the z-axis
                float zRotationVelocity = rotateSpeed * Mathf.Deg2Rad;

                // Apply angular velocity to rotate around the local z-axis
                transform.Rotate(Vector3.forward * zRotationVelocity, Space.Self);

                // Rotate the grammaphone handle in the local x-axis
                handle.transform.Rotate(Vector3.right * handleSpeed, Space.Self);
            }

        }
    }
}
