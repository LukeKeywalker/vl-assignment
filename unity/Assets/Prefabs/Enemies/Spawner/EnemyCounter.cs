
using System;
using UnityEngine;

[Serializable]
[CreateAssetMenu (fileName = "EnemyCounter", menuName = "Core Gameplay/EnemyCounter")]
public class EnemyCounter : ScriptableObject
{
    [SerializeField]
    public GameOver gameOver;

    [SerializeField]
    public int enemiesAlive;

    [SerializeField]
    public int enemiesKilled;

    public bool isTitanAlive;

    public void Init()
    {
        enemiesAlive = 0;
        enemiesKilled = 0;
        isTitanAlive = false;
    }

    public void Increment()
    {
        enemiesAlive++;
    }

    public void Decrement()
    {
        enemiesAlive--;
        enemiesKilled++;
    }

    public void AddTitan()
    {
        Increment();
        isTitanAlive = true;
    }

    public void KillTitan()
    {
        Decrement();
        isTitanAlive = false;
        if (gameOver != null)
            gameOver.value = true;
        Init();
    }
}