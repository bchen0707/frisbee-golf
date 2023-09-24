using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class haveAtry : MonoBehaviour
{
    public GameObject prefabA;
    public GameObject prefabB;

    //for tunnel A
    public GameObject[] colorChanging;
    public Material[] changingMaterials;

    public List<GameObject> objectList;
    public List<List<GameObject>> listOfLists;
    public float frequency = 1;
    public float amplitude = 2;
    public float phase = 10;
    public int SIDES = 10;
    public int DEPTH = 20;
    
    public float radius = 5;
    public float ringDistance = 2;
    public float counter = 0;

    private GameObject containerA;

    /*
    //for tunnel B
    public List<GameObject> movingTunnel;

    //rotational symmety example
    public float radius2 = 10;
    public float ringDistance2 = 3;
    public float tunnelSpeed = 10;
    public float tunnelRotationSpeed = 10;

    public Material alternativeMaterial;

    private GameObject containerB;
    */

    void Start()
    {
        containerA = new GameObject("containerA");

        //the static "tunnel"
        //create an empty list of lists
        listOfLists = new List<List<GameObject>>();

        for (int r = 0; r < DEPTH; r++)
        {
            //create each list (ring)
            List<GameObject> ring = new List<GameObject>();

            //populate the list
            for (int s = 0; s < SIDES; s++)
            {
                GameObject go = Instantiate(prefabA, containerA.transform);
                ring.Add(go);
                //the positioning happens in the update
            }

            //add it to the list of lists
            listOfLists.Add(ring);
        }

        /*

        containerB = new GameObject("containerB");
        movingTunnel = new List<GameObject>();
        for (int r = 0; r < DEPTH; r++)
        {

            //populate the list
            for (int s = 0; s < SIDES; s++)
            {
                //put it in a different container
                GameObject go = Instantiate(prefabB, containerB.transform);

                float angDelta = 360f / SIDES;
                float angle = s * angDelta + Random.Range(-angDelta/2, angDelta/2);

                float x = Mathf.Cos(angle * Mathf.Deg2Rad) * radius2;
                float y = Mathf.Sin(angle * Mathf.Deg2Rad) * radius2;

                float z = r * ringDistance2;

                go.transform.localPosition = new Vector3(x, z, y);

                go.transform.rotation = Quaternion.Euler(0, angle, 0);
                //add a rotation in local space to make them face the center
                go.transform.Rotate(0,  0, 90, Space.Self);

                //i can use the same prefab but change the material
                go.GetComponent<Renderer>().material = alternativeMaterial;

                movingTunnel.Add(go);
            }
        }
        */


    }
    
    // Update is called once per frame
    void Update()
    {
        //go through the list
        //Count is same as Length but for lists 
        for(int i=0; i< objectList.Count; i++)
        {
            GameObject go = objectList[i];

            //scale according to the time (increasing linearily) and the position
            float oscillation = (Mathf.Sin(Time.time * frequency + i*phase)+1) * amplitude;
            
            //phase is the difference in oscillation between each ring
            //1 so it's always bigger than 1
            float scale = 1 + oscillation;

            go.transform.localScale= new Vector3(scale, scale, 1);
        }

        //the tunnel with quads
        //positions and rotations are recalculated every frame
        counter += Time.deltaTime;

        //every 0.5 seconds reset
        if (counter > 0.5f)
            counter = 0;

        for (int r = 0; r < listOfLists.Count; r++)
        {
            List<GameObject> ring = listOfLists[r];

            for(int s = 0; s<ring.Count; s++)
            {
                GameObject go = ring[s];
                //360/SIDES is the angular dist between object arranged in a circle
                float angle = s * 360f / SIDES; //+ Time.time*r*3; //add this for a spiral effect
                //Mathf.Deg2Rad converts degrees in radians - necessary for trigonometric ops
                float x = Mathf.Cos(angle * Mathf.Deg2Rad) * radius;
                float y = Mathf.Sin(angle * Mathf.Deg2Rad) * radius;

                float z = r * ringDistance;

                go.transform.localPosition = new Vector3(x, z, y);

                go.transform.rotation = Quaternion.Euler(0, angle, 0);
                //add a rotation in local space to make them face the center
                go.transform.Rotate(0, 0, 90, Space.Self);

                //if it's 0 it has been reset so it's every 0.5 seconds
                if (counter == 0)
                {
                    float scale = Random.Range(0.5f, 1f);
                    go.transform.localScale = new Vector3(scale, scale, scale);
                }
            }
        }

        /*
        //moving tunnel 
        //the positions are updated incrementally
        foreach(GameObject quad in movingTunnel)
        {
            quad.transform.Translate(0, tunnelSpeed * Time.deltaTime, 0, Space.World);
            
            //if the position goes below 0 (behind the camera) push it at the end of the tunnel 
            if(quad.transform.position.z < -ringDistance2)
            {
                Vector3 pos = quad.transform.position;
                pos.z += ringDistance2 * DEPTH;
                quad.transform.position = pos;
            }
        }

        //I can manipulate the container
        containerB.transform.Rotate(0, 0, Time.deltaTime * tunnelRotationSpeed);
        */
        
    }

}
