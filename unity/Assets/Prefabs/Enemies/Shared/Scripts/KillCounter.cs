using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KillCounter : MonoBehaviour
{
    public EnemyCounter enemyCounter;
    // Start is called before the first frame update

    private bool isTitan;

    void Awake()
    {
        isTitan = GetComponent<TitanCubeBrain>() != null;
    }

    void OnDestroy()
    {
        if (isTitan)
        {
            enemyCounter.KillTitan();
        }
        else
        {
            enemyCounter.Decrement();
        }
    }
}
