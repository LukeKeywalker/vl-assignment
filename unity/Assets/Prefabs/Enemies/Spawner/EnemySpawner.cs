using System.Collections;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public GameOver gameOver;

    public Transform[] enemyPrefabs;

    public EnemyCounter enemyCounter;

    public Transform entryPoint;

    public PlayerHealth playerHealth;

    private int rotationDirection = 1;


    void Start()
    {
        Init();
    }

    void Init ()
    {
        StopAllCoroutines();
        enemyCounter.Init();
        StartCoroutine(ChangeDirectionsCoroutine());
        StartCoroutine(SpawningCoroutine());
    }

    void Update()
    {
        transform.Rotate(0, (float)rotationDirection * Time.deltaTime * 10.0f, 0);
    }

    IEnumerator ChangeDirectionsCoroutine()
    {
        while (true && (gameOver == null || gameOver.value == false))
        {
            yield return new WaitForSeconds(1);
            int r = Random.Range(0, 10);
            if (r == 0)
            {
                rotationDirection *= -1;
            }
        }
    }

    IEnumerator SpawningCoroutine()
    {
        while (true && (gameOver == null || gameOver.value == false)) 
        {
            yield return new WaitForSeconds(1);

            if (enemyCounter.isTitanAlive || enemyCounter.enemiesAlive > 30) continue;

            if (enemyCounter.isTitanAlive == false && enemyCounter.enemiesKilled > 20)
            {
                Instantiate(enemyPrefabs[enemyPrefabs.Length - 1], entryPoint.position, Quaternion.identity);
                enemyCounter.AddTitan();                
            }
            else {
                int r1 = Random.Range(0, 11);
                if (r1 > 0)
                {
                    int r2 = Random.Range(0, enemyPrefabs.Length - 1);
                    Instantiate(enemyPrefabs[r2], entryPoint.position, Quaternion.identity);
                    enemyCounter.Increment();
                }
            }
        }
    }
}
