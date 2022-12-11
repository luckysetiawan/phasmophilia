using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public void PlayCity()
    {
        SceneManager.LoadScene("City");
    }
    public void PlayLab()
    {
        SceneManager.LoadScene("Lab");
    }

    public void ExitGame()
    {
        Application.Quit();
    }
}
