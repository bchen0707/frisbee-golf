using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class CanvasManager : MonoBehaviour
{
    private static CanvasManager _instance;
    public static CanvasManager Instance => _instance;

    public float fadeDuration = 2.5f;
    
    public Image image;
    private Color color;

    private void Awake()
    {
        color = image.color;

        if (_instance != null && _instance != this)
        {
            Destroy(this.gameObject);
        }
        else
        {
            _instance = this;
            DontDestroyOnLoad(this);
        }
    }
    // Start is called before the first frame update
    void Start()
    {
        color.a = 0;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void TransitionToScene(int sceneIndex)
    {
        FadeIn();
        SceneManager.LoadScene(sceneIndex);
        FadeOut();
    }

    public void FadeIn()
    {
        Fade(0, 255);
    }

    public void FadeOut()
    {
        Fade(255, 0);
    }
    public void Fade(float alphaIn, float alphaOut)
    {
        StartCoroutine((FadeRoutine(alphaIn, alphaOut)));
    }

    public IEnumerator FadeRoutine(float alphaIn, float alphaOut)
    {
        float timer = 0;
        while (timer <= fadeDuration)
        {
            color.a = Mathf.Lerp(alphaIn, alphaOut, timer / fadeDuration);

            timer += Time.deltaTime;
            yield return null;
            Debug.Log("yield return");
        }
        color.a = alphaOut;
    }

}
