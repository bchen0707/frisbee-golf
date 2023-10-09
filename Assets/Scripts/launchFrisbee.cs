using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;
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

    public InputHelpers.Button button;

    private void Start()
    {
        readyToThrow = true;
    }

    private void Update()
    {
        if ((Input.GetKeyDown(throwKey)) && readyToThrow)
        {
            Throw();
        }
    }



    public void Throw()
    {
        readyToThrow = false;
        totalThrows++;
        Quaternion qb = Quaternion.Euler(90, 0, 0);
        GameObject frisbeeObject = Instantiate(frisbee, attackPoint.position, Quaternion.identity);
        Rigidbody frisbeeRb = frisbeeObject.GetComponent<Rigidbody>();
        frisbeeRb.rotation = qb;
        frisbeeRb.isKinematic = false;
        // frisbeeRb.useGravity = true;
        Vector3 frisbeeArc = cam.transform.forward;
        RaycastHit hit;
        if(Physics.Raycast(cam.position, cam.forward, out hit))
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