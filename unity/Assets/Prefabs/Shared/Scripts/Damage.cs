
using System;
using UnityEngine;

[Serializable]
[CreateAssetMenu (fileName = "Damage", menuName = "Core Gameplay/Damage")]
public class Damage : ScriptableObject
{
    [SerializeField]
    public float value;
}

