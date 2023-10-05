using System.Collections;
using System.Collections.Generic;
using UnityEditor.SceneManagement;
using UnityEngine;
using UnityEngine.SceneManagement;


public class GameManager : MonoBehaviour
{
    private static GameManager _instance;
    public static GameManager Instance => _instance;
    public int panelHitCount;
    public GameObject grammpahone;
    private void Awake() {
        if (_instance != null && _instance != this) {
            Destroy(this.gameObject);
        } else {
            _instance = this;
            DontDestroyOnLoad(this);
        }
    }

   
    // Start is called before the first frame update
    void Start()
    {
        panelHitCount = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if (panelHitCount >= 8)
        {
            grammpahone.SetActive(true);
        }
    }
}
