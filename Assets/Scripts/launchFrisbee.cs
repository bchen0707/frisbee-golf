using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR;
using TMPro;

public class launchFrisbee : MonoBehaviour
{
    public Transform cam;
    public Transform attackPoint;
    public GameObject frisbee;

    public int totalThrows;
    public float throwCool;

    public KeyCode throwKey = KeyCode.Mouse0;
    public float throwForce;
    public float upwardForce;

    bool readyToThrow;

    private void Start()
    {
        readyToThrow = true;
    }

    private void Update()
    {
        

        /*bool value;
        if (UnityEngine.XR.InputDevices.GetDeviceAtXRNode(XRNode.RightHand).TryGetFeatureValue(new("TriggerTouch"), out value))
        {
            hand.triggerTouch = value;
        }
        if (value && readyToThrow)
        {
            Throw();
        }*/
        if (Input.GetKeyDown(throwKey) && readyToThrow)
        {
            Throw();
        }
    }



    private void Throw()
    {
        readyToThrow = false;
        totalThrows++;
        Quaternion qb = new Quaternion(0, 0, 0, 1);
        GameObject frisbeeObject = Instantiate(frisbee, attackPoint.position, Quaternion.identity);
        Rigidbody frisbeeRb = frisbeeObject.GetComponent<Rigidbody>();
        //frisbeeRb.rotation = qb;
        frisbeeRb.isKinematic = false;
        // frisbeeRb.useGravity = true;
        Vector3 frisbeeArc = cam.transform.forward;
        RaycastHit hit;
        if(Physics.Raycast(cam.position, cam.forward, out hit, 50f))
        {
            frisbeeArc = (hit.point-attackPoint.position).normalized;
        }

        Vector3 addedForce = frisbeeArc * throwForce + transform.up * upwardForce;
        frisbeeRb.AddForce(addedForce, ForceMode.Impulse);
        Debug.Log("ok");
        Invoke(nameof(ResetThrow), throwCool);
    }

    private void ResetThrow()
    {
        readyToThrow = true;
    }

    private void OnCollisionEnter(Collision collision)
    {
        Debug.Log(collision.transform.name);
    }
}