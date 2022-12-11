using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    bool gameEnded = false;

    public float restartDelay = 2f;

    public void CompleteGame()
    {
        Debug.Log("WIN");
    }

    public void EndGame()
    {
        if (!gameEnded)
        {
            gameEnded = true;
            Debug.Log("GAME OVER");

            Invoke("Restart", restartDelay);
        }
    }

    void Restart()
    {
        string currentLevel = SceneManager.GetActiveScene().name;

        SceneManager.LoadScene(currentLevel);
    }
}
