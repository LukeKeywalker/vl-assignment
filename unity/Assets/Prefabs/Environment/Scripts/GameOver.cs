
using System;
using UnityEngine;

[Serializable]
[CreateAssetMenu (fileName = "GameOverCondition", menuName = "Core Gameplay/GameOver Condition")]
public class GameOver : ScriptableObject
{
    [SerializeField]
    public bool value;
}