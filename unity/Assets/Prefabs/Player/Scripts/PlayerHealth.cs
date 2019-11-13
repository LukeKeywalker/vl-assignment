
using System;
using UnityEngine;

[Serializable]
[CreateAssetMenu (fileName = "PlayerHealth", menuName = "Core Gameplay/PlayerHealth")]
public class PlayerHealth : ScriptableObject
{
    [SerializeField]
    public GameOver gameOver;

    [SerializeField]
    public float normalizedValue;

    public void SetNormalizedHealth(float value)
    {
        normalizedValue = value;
        if (normalizedValue <= 0) 
            gameOver.value = true;
    }
}