using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RecordXRI : MonoBehaviour
{
    public Material[] materials;
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
}
