using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class HomeButton : MonoBehaviour
{
    public Button home;

    private void Start()
    {
        home.onClick.AddListener(BackToMainMenu);
    }

    public void BackToMainMenu()
    {
        SceneManager.LoadScene("StartMenu");
    }
}
