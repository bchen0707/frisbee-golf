using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RecordXRI : MonoBehaviour
{
    public Material[] materials;
    public Transform launchPosition;
    public float launchSpeed = 10;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    public void resetMaterials()
    {
        this.GetComponent<MeshRenderer>().materials = materials;
    }

    public void launchDisc()
    {
        GameObject spawnedDisc = Instantiate(this.gameObject);
        spawnedDisc.transform.position = launchPosition.position;
        spawnedDisc.GetComponent<Rigidbody>().velocity = launchPosition.forward * launchSpeed;
    }
}
