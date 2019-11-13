using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOverCondition : MonoBehaviour
{
    public PlayerHealth playerHealth;
    // Start is called before the first frame update

    // Update is called once per frame
    void Update()
    {
        if (playerHealth.normalizedValue <= 0)
        {
            SceneManager.LoadScene("MainMenu");
            Destroy(gameObject);
        }
    }
}
