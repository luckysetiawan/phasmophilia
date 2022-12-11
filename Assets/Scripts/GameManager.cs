using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    bool gameEnded = false;

    public float restartDelay = 2f;

    private void Update()
    {
        if (Input.GetKey(KeyCode.Escape))
        {
            CompleteGame();
        }
    }

    public void CompleteGame()
    {
        SceneManager.LoadScene("MainMenu");
    }

    public void EndGame()
    {
        if (!gameEnded)
        {
            gameEnded = true;

            Invoke("Restart", restartDelay);
        }
    }

    void Restart()
    {
        string currentLevel = SceneManager.GetActiveScene().name;

        SceneManager.LoadScene(currentLevel);
    }
}
