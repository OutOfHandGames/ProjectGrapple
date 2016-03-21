using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class MainMenu : MonoBehaviour {

    public void onPlayClicked()
    {
        SceneManager.LoadScene("MainScene");
    }

    public void onQuitClicked()
    {
        Application.Quit();
    }
}
