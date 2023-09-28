using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class coordinateSyestem : MonoBehaviour
{
    public GameObject prefabA;
    public List<GameObject> objectList;
    public List<List<GameObject>> listOfLists;
    public GameObject[,] objectArray;
    public List<GameObject[,]> listOfArray;

    public int PositionX = 0;
    public int PositionY = 0;
    public int PositionZ = 0;

    public int ROWS = 20;
    public int COLS = 20;
    public int HIGHT = 20;

    public float distance = 2;
    public float noiseMultiplier = 0.1f;
    public float scaleMultiplier = 2;

    private GameObject containerA;

    // Start is called before the first frame update
    void Start()
    {
        containerA = new GameObject("containerA");

        listOfArray = new List<GameObject[,]>();
        for (int h = 0; h < HIGHT; h++)
        {
            //create each list (layer)
            GameObject[,] layer = new GameObject[ROWS, COLS];
            for(int r = 0; r < ROWS; r++)
            {
                for(int c = 0; c < COLS; c++)
                {
                    GameObject go = Instantiate(prefabA, containerA.transform);
                    go.transform.localPosition = new Vector3(c * distance+PositionX, h * distance+PositionY, r * distance+PositionZ);

                    //add each object to the array
                    layer[r,c] = go;
                }
            }
            //add it to the list of lists
            listOfArray.Add(layer);
        }

        //center the container, moving all the pyramids inside
        containerA.transform.position = new Vector2(-COLS*distance/2, -10);
    }

    // Update is called once per frame
    void Update()
    {
         //iterate through the array
        for (int h = 0; h < HIGHT; h++)
        {
            GameObject[,] layerCut = listOfArray[h];
            for (int r = 0; r < ROWS; r++)
            {
                for(int c = 0; c < COLS; c++)
                {
                    GameObject go = layerCut[r, c];

                    //noise sampling moves linearly
                    float noiseOffset = Time.time;
                
                    //sample the noise relative to the position
                    float noise = Mathf.PerlinNoise(r * noiseMultiplier+ noiseOffset, c * noiseMultiplier);
                
                    //change the z scale (pointy axis)
                    Vector3 scale = go.transform.localScale;
                    scale.z = noise * scaleMultiplier;
                    go.transform.localScale = scale;
                }
            }
        }
        
    }
}
