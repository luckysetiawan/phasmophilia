using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    bool gameEnded = false;

    public float delay = 0f;
    public float restartDelay = 0f;

    private void Update()
    {
        if (Input.GetKey(KeyCode.Escape))
        {
            CompleteGame();
        }
    }

    public void CompleteGame()
    {
        if (!gameEnded)
        {
            gameEnded = true;

            Invoke("ReturnToMainMenu", delay);
        }
    }

    public void EndGame()
    {
        if (!gameEnded)
        {
            gameEnded = true;

            Invoke("Restart", restartDelay);
        }
    }

    void ReturnToMainMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }

    void Restart()
    {
        string currentLevel = SceneManager.GetActiveScene().name;

        SceneManager.LoadScene(currentLevel);
    }
}
