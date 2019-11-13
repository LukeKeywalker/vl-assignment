using UnityEngine;
using UnityEngine.SceneManagement;

public class GameStart : MonoBehaviour
{
    public GameOver gameOver;
    public void StartGame()
    {
        SceneManager.LoadScene("CoreUI");
        SceneManager.LoadScene("GameArena", LoadSceneMode.Additive);
        gameOver.value = false;
    }
}
