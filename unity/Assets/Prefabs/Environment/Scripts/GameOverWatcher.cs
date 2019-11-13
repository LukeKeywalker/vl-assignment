using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOverWatcher : MonoBehaviour
{
    public GameOver gameOver;

    // Update is called once per frame
    void Update()
    {
        if (gameOver.value)
        {
            SceneManager.LoadScene("MainMenu");
        }
    }
}
