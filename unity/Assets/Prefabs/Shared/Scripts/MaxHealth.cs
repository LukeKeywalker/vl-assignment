
using System;
using UnityEngine;

[Serializable]
[CreateAssetMenu (fileName = "MaxHealth", menuName = "Core Gameplay/MaxHealth")]
public class MaxHealth : ScriptableObject
{
    [SerializeField]
    public float value;
}

