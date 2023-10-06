using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class coordinateLineSyest : MonoBehaviour
{
    public GameObject prefabC;
    public GameObject prefabD;
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

    public int distance = 50;
    public int dotNumber = 10;

    public float noiseMultiplier = 0.1f;
    public float scaleMultiplier = 2;


    private GameObject containerC;
    private GameObject containerD;

    //pulsing code
    public float _pulseSize = 1.15f;
    public float _returnSpeed = 5f;
    private Vector3 _startSize;

    //beat manager code
    public float _bpm = 136f;
    public float _steps = 1f;

    private float pulseInterval;
    private float nextPulseTime;

    // Start is called before the first frame update
    void Start()
    {
        //initialize containers first 
        containerC = new GameObject("containerC");
        containerD = new GameObject("containerD");

        //start size of the blue dots
        _startSize = containerC.transform.localScale;

        //calculate pulse interval based on BPM
        pulseInterval = 60f / (_bpm*_steps);

        //Initiate next pulse time
        nextPulseTime = Time.deltaTime + pulseInterval;

        listOfArray = new List<GameObject[,]>();
        List<List<GameObject>> dotComplement = new List<List<GameObject>>();

        for (int h = 0; h < HIGHT; h++)
        {
            //create each list (layer)
            GameObject[,] layer = new GameObject[ROWS, COLS];
            //create each list (complementary dots' layer)
            List<GameObject> dots = new List<GameObject>();
            for(int r = 0; r < ROWS; r++)
            {
                for(int c = 0; c < COLS; c++)
                {
                    //construct the coordinate system 
                    GameObject go = Instantiate(prefabC, containerC.transform);
                    int goX = c * distance+PositionX;
                    int goY = h * distance+PositionY;
                    int goZ = r * distance+PositionZ;
                    go.transform.localPosition = new Vector3(goX, goY, goZ);

                    //add each coordinate system object to the array
                    layer[r,c] = go;
                    //blueDotList.Add(go);

                    //construct the dots in between
                    for (int i = 0; i < dotNumber; i++)
                    {
                        //dot horizon
                        int gap = distance/(dotNumber+1);
                        GameObject goDot1 = Instantiate(prefabD, containerD.transform);
                        int goDotX1 = goX + (i + 1) * gap;
                        int goDotY1 = goY;
                        int goDotZ1 = goZ;
                        //put the dots into dotslist
                        goDot1.transform.localPosition = new Vector3(goDotX1, goDotY1, goDotZ1);
                        dots.Add(goDot1);

                        //dot verticle
                        GameObject goDot2 = Instantiate(prefabD, containerD.transform);
                        int goDotX2 = goX;
                        int goDotY2 = goY;
                        int goDotZ2 = goZ + (i + 1) * gap;
                        //put the dots into dotslist
                        goDot2.transform.localPosition = new Vector3(goDotX2, goDotY2, goDotZ2);
                        dots.Add(goDot2);                      
                    }

                }
            }
            //add it to the list of lists
            listOfArray.Add(layer);
            dotComplement.Add(dots);
        }

        //center the container, moving all the pyramids inside
        containerC.transform.position = new Vector2(-COLS*distance/2, -10);
        containerD.transform.position = new Vector2(-COLS*distance/2, -10);

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

                    go.transform.localScale = Vector3.Lerp(go.transform.localScale, _startSize, Time.deltaTime * _returnSpeed);

                    if (Time.deltaTime >= nextPulseTime)
                    {
                        go.transform.localScale = _startSize * _pulseSize;
                        nextPulseTime += pulseInterval;
                    }

                }
            }
        }
    }

}
